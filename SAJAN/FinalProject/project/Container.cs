using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DirectWrite;
using SharpDX.MediaFoundation;

namespace project
{
    class Container 
    {
        //GraphicsDevice GraphicsDevice;
        // Hold all object clients
        public List<objectClient> enemyList;
        public List<objectClient> enemyBossList;
        
        public List<objectClient> enemyBulletList;
        public List<PlayerBullet> playerBulletList;

        Vector2 left = new Vector2(100, 50);
        Vector2 middle = new Vector2(250, 50);
        Vector2 right = new Vector2(400, 50);

        public int score;
        public int bombScore;

        // Player
        public Player myPlayer;
        private GameTime gameTime;
        private Grid gameBoard;
        private GraphicsDevice graphicsDevice;

        public Container(GraphicsDevice updateGraphicsDevice)
        {
            //this.gameTime = time;
            this.enemyList = new List<objectClient>();
            this.enemyBossList = new List<objectClient>();

            this.enemyBulletList = new List<objectClient>();
            this.playerBulletList = new List<PlayerBullet>();
            gameBoard = new Grid();
            Vector2 V = new Vector2(1, 1);//you need to construct player
            Vector2 C = new Vector2(350, 600);
            myPlayer = new Player(8, V, C, updateGraphicsDevice);           
        }

        public int getBossHealth()
        {
            int result = 0;
            foreach (objectClient client in enemyBossList)
            {
                result = result + client.getBossHealth();
            }
            return result;
        }

        //free despawns
        //used to remove the element out of the list that got sent out of the map
        public void freeDespawns()
        {
            for(int x = 0; x < enemyBulletList.Count; x++)
            {
                Vector2 cords = enemyBulletList[x].GetBulletCenterCoordinates();
                if (cords.X < 0)
                {
                    enemyBulletList.RemoveAt(x);
                }
                else if (cords.Y < 0)
                {
                    enemyBulletList.RemoveAt(x);
                }
            }

            for (int x = 0; x < enemyList.Count; x++)
            {
                Vector2 cords = enemyList[x].GetEnemyCenterCoordinates();
                if (cords.X < 0)
                {
                    enemyList.RemoveAt(x);
                }
                else if (cords.Y < 0)
                {
                    enemyList.RemoveAt(x);
                }
            }

            for (int x = 0; x < enemyBossList.Count; x++)
            {
                Vector2 cords = enemyBossList[x].GetBossCenterCoordinates();
                if (cords.X < 0)
                {
                    enemyBossList.RemoveAt(x);
                }
                else if (cords.Y < 0)
                {
                    enemyBossList.RemoveAt(x);
                }
            }

        }

        //Clear the enemies after a stage
        public void clearEnemies()
        {
            this.enemyList.Clear();
            this.enemyBossList.Clear();
        }

        //clear the enemy bullets after a stage
        public void clearEnemyBullets()
        {
            this.enemyBulletList.Clear();
        }

        //add the player to the container
        public void addPlayerObject(Player newPlayer)
        {
            this.myPlayer = newPlayer;
        }

        public void addEnemy(string type, int hp, Vector2 position, int attackPattern)
        {
            switch (type)
            {
                case "BasicEnemyA":
                    addEnemyA(hp, position, attackPattern);
                    break;
                case "BasicEnemyB":
                    addEnemyB(hp, position, attackPattern);
                    break;
                case "MidBoss":
                    addMidBoss(hp, position, attackPattern);
                    break;
                case "FinalBoss":
                    addFinalBoss(hp, position, attackPattern);
                    break;
                default:
                    break;
            }
        }

        // Adds new enemy A to list
        public void addEnemyA(int hp, Vector2 position, int attackPattern)
        {
            abstractEnemyFactory BlueBug1 = new concreteEnemyA();
            objectClient newClient = new objectClient();
            newClient.clientEnemy(BlueBug1, this.graphicsDevice, hp, new Vector2(.3f, .3f), position, attackPattern);
            this.enemyList.Add(newClient);
        }
        
        // Adds new enemy B to the list
        public void addEnemyB(int hp, Vector2 position, int attackPattern)
        {
            abstractEnemyFactory GreenBug1 = new concreteEnemyB();
            objectClient newClient = new objectClient();
            newClient.clientEnemy(GreenBug1, this.graphicsDevice, hp, new Vector2 (.3f, .3f), position, attackPattern);
            this.enemyList.Add(newClient);
        }

        public void addMidBoss(int hp, Vector2 position, int attackPattern)
        {
            abstractBossFactory midBoss = new concreteMidBoss();
            objectClient newClient = new objectClient();
            newClient.clientBoss(midBoss, hp, position, new Vector2(300, 50), attackPattern);
            this.enemyBossList.Add(newClient);
        }

        public void addMidBoss()
        {
            abstractBossFactory midBoss = new concreteMidBoss();
            objectClient newClient = new objectClient();
            newClient.clientBoss(midBoss, 200, new Vector2(.5f, .5f), new Vector2(300, 50), 1);
            this.enemyBossList.Add(newClient);
        }

        public void addFinalBoss(int hp, Vector2 position, int attackPattern)
        {
            abstractBossFactory finalBoss = new concreteFinalBoss();
            objectClient newClient = new objectClient();
            newClient.clientBoss(finalBoss, hp, new Vector2(.7f, .7f), position, attackPattern);
            this.enemyBossList.Add(newClient);
        }

        // Enemy shoots bullet at current position
        public void AddEnemyBullet(objectClient client)
        {
            abstractBulletFactory Bullet1 = new concreteEnemyBullet();
            objectClient newClient1 = new objectClient();
            newClient1.clientBullet(Bullet1, 105, new Vector2(0, .9f), client.GetEnemyDetails().GetPosition());
            this.enemyBulletList.Add(newClient1);
        }

        // All basic enemies shoot at the same time at current position
        public void BasicEnemyShoot()
        {
            foreach (objectClient client in enemyList)
            {
                AddEnemyBullet(client);
            }
        }

        // Midboss shoots bullet at current position
        public void AddMidBossBullet(objectClient client)
        {
            abstractBulletFactory Bullet1 = new concreteMidBossBullet();
            objectClient newClient1 = new objectClient();
            newClient1.clientBullet(Bullet1, 105, new Vector2(0, 2f), client.GetBossCenterCoordinates());
            objectClient newClient2 = new objectClient();
            newClient2.clientBullet(Bullet1, 105, new Vector2(1.50f, 1.50f), client.GetBossCenterCoordinates());
            objectClient newClient3 = new objectClient();
            newClient3.clientBullet(Bullet1, 105, new Vector2(-1.50f, 1.50f), client.GetBossCenterCoordinates());
            objectClient newClient4 = new objectClient();
            newClient4.clientBullet(Bullet1, 105, new Vector2(-1.50f, -1.50f), client.GetBossCenterCoordinates());
            objectClient newClient5 = new objectClient();
            newClient5.clientBullet(Bullet1, 105, new Vector2(0, -2f), client.GetBossCenterCoordinates());
            objectClient newClient6 = new objectClient();
            newClient6.clientBullet(Bullet1, 105, new Vector2(-2f, 0), client.GetBossCenterCoordinates());
            objectClient newClient7 = new objectClient();
            newClient7.clientBullet(Bullet1, 105, new Vector2(2f, 0), client.GetBossCenterCoordinates());
            objectClient newClient8 = new objectClient();
            newClient8.clientBullet(Bullet1, 105, new Vector2(1.50f, -1.50f), client.GetBossCenterCoordinates());
            this.enemyBulletList.Add(newClient1);
            this.enemyBulletList.Add(newClient2);
            this.enemyBulletList.Add(newClient3);
            this.enemyBulletList.Add(newClient4);
            this.enemyBulletList.Add(newClient5);
            this.enemyBulletList.Add(newClient6);
            this.enemyBulletList.Add(newClient7);
            this.enemyBulletList.Add(newClient8);
        }

        // All Midbosses shoot at the same time at current position
        public void MidBossShoot()
        {
            foreach (objectClient client in enemyBossList)
            {
                AddMidBossBullet(client);
            }
        }

        public void Bomb()
        {
            foreach (objectClient enemy in this.enemyList)
            {
                this.bombScore += 100;
            }
            // Clear
            ClearBoard();
        }

        public void ClearBoard()
        {
            this.enemyList.Clear();
            this.enemyBossList.Clear();
            this.enemyBulletList.Clear();
        }

        // Midboss shoots bullet at current position
        public void AddFinalBossBullet(objectClient client)
        {
            abstractBulletFactory Bullet1 = new concreteMidBossBullet();
            objectClient newClient1 = new objectClient();
            newClient1.clientBullet(Bullet1, 105, new Vector2(0, 2f), client.GetBossCenterCoordinates());
            objectClient newClient2 = new objectClient();
            newClient2.clientBullet(Bullet1, 105, new Vector2(1.50f, 1.50f), client.GetBossCenterCoordinates());
            objectClient newClient3 = new objectClient();
            newClient3.clientBullet(Bullet1, 105, new Vector2(-1.50f, 1.50f), client.GetBossCenterCoordinates());
            objectClient newClient4 = new objectClient();
            newClient4.clientBullet(Bullet1, 105, new Vector2(-1.50f, -1.50f), client.GetBossCenterCoordinates());
            objectClient newClient5 = new objectClient();
            newClient5.clientBullet(Bullet1, 105, new Vector2(0, -2f), client.GetBossCenterCoordinates());
            objectClient newClient6 = new objectClient();
            newClient6.clientBullet(Bullet1, 105, new Vector2(-2f, 0), client.GetBossCenterCoordinates());
            objectClient newClient7 = new objectClient();
            newClient7.clientBullet(Bullet1, 105, new Vector2(2f, 0), client.GetBossCenterCoordinates());
            objectClient newClient8 = new objectClient();
            newClient8.clientBullet(Bullet1, 105, new Vector2(1.50f, -1.50f), client.GetBossCenterCoordinates());
            this.enemyBulletList.Add(newClient1);
            this.enemyBulletList.Add(newClient2);
            this.enemyBulletList.Add(newClient3);
            this.enemyBulletList.Add(newClient4);
            this.enemyBulletList.Add(newClient5);
            this.enemyBulletList.Add(newClient6);
            this.enemyBulletList.Add(newClient7);
            this.enemyBulletList.Add(newClient8);
        }

        // All Midbosses shoot at the same time at current position
        public void FinalBossShoot()
        {
            foreach (objectClient client in enemyBossList)
            {
                AddFinalBossBullet(client);
            }
        }

        // Adds new player bullet to list
        public void addPlayerBullet(PlayerBullet bullet)
        {
            this.playerBulletList.Add(bullet);
        }

        public void Update(GameTime time) // Add manager class to handle controller
        {
            this.gameTime = time;
            foreach (objectClient obj in enemyBulletList)
            {
                obj.UpdateBullet(this.gameTime);
            }
            foreach (objectClient obj in enemyList)
            {
                
                obj.UpdateEnemy(this.gameTime);
            }
            foreach (objectClient obj in enemyBossList)
            {
                obj.UpdateBoss(this.gameTime);
            }

            /*
            foreach (objectClient obj in BossBulletList)
            {
                obj.UpdateBullet(this.gameTime);
            }*/
            foreach (PlayerBullet obj in playerBulletList)
            {
                obj.update(this.gameTime);
            }

            //foreach (Object ob)

            myPlayer.update(this.gameTime);

            gameBoard.CheckCollisions(this.enemyList, this.enemyBossList,this.enemyBulletList, this.playerBulletList, this.myPlayer);
            this.score = gameBoard.score + bombScore;
        }

        public int GetScore()
        {
            return this.score;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (objectClient obj in enemyBulletList)
            {
                obj.DrawBullet(_spriteBatch);
            }
            foreach (objectClient obj in enemyList)
            {
                obj.DrawEnemy(_spriteBatch);
            }
            foreach(objectClient obj in enemyBossList)
            {
                obj.DrawBoss(_spriteBatch);
            }
            foreach (PlayerBullet obj in playerBulletList)
            {
                obj.draw(_spriteBatch);
            }

            this.myPlayer.draw(_spriteBatch);
        }
    }
}
