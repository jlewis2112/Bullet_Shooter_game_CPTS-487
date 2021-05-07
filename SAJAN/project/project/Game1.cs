using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //for score board
        private KeyboardState previousState;
        private SpriteFont font;
        private Texture2D heart;
        private int score;
        //enemy art
        private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        private Texture2D enemyA;
        private Texture2D enemyB;
        private Texture2D midBoss;
        private Texture2D finalBoss;
        private Texture2D basicBullet;
        private Texture2D midBossBullet;
        private Texture2D finalBossBullet;

        private Player myPlayer;
        private BasicEnemyA blueBug1;
        private BasicEnemyA blueBug2;
        private BasicEnemyB greenBug1;
        private BasicEnemyB greenBug2;
        private MidBoss mediumBoss;
        private FinalBoss lastBoss;

        // Bullets
        private EnemyBullet blueBugBullet1;
        private EnemyBullet blueBugBullet2;
        private EnemyBullet blueBugBullet3;
        private EnemyBullet blueBugBullet4;

        private EnemyBullet greenBugBullet1;
        private EnemyBullet greenBugBullet2;
        private EnemyBullet greenBugBullet3;
        private EnemyBullet greenBugBullet4;

        private MidBossBullet midBossBullet1;

        private FinalBossBullet finalBossBullet1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.score = 0;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }



        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            loadTextures();//load textures to the dictionary.
            //not needed
            font = Content.Load<SpriteFont>("Name");
            heart = Content.Load<Texture2D>("Heart");
            enemyA = Content.Load<Texture2D>("EnemyA");
            enemyB = Content.Load<Texture2D>("EnemyB");
            midBoss = Content.Load<Texture2D>("MidBoss");
            finalBoss = Content.Load<Texture2D>("FinalBoss");
            basicBullet = Content.Load<Texture2D>("BasicBullet");
            midBossBullet = Content.Load<Texture2D>("MidBullet");
            finalBossBullet = Content.Load<Texture2D>("FinalBullet");

            //not needed ends
            myPlayer = new Player(GraphicsDevice);
            blueBug1 = new BasicEnemyA(GraphicsDevice, 100, .3f, new Vector2(100, 50), 1);
            greenBug1 = new BasicEnemyB(GraphicsDevice, 100, .3f, new Vector2(200, 50), 1);
            blueBug2 = new BasicEnemyA(GraphicsDevice, 100, .3f, new Vector2(200, 50), 2);
            greenBug2 = new BasicEnemyB(GraphicsDevice, 100, .3f, new Vector2(100, 50), 2);
            mediumBoss = new MidBoss(100, .5f, new Vector2(300, 50));
            lastBoss = new FinalBoss(100, .7f, new Vector2(400, 50));

            blueBugBullet1 = new EnemyBullet(1, 2, blueBug1.Position); // Fire on spawn
            blueBugBullet2 = new EnemyBullet(1, 2, blueBug2.Position); // Fire halfway
            blueBugBullet3 = new EnemyBullet(1, 2, blueBug1.Position); // Fire on spawn 
            blueBugBullet4 = new EnemyBullet(1, 2, blueBug2.Position); // Fire halfway

            greenBugBullet1 = new EnemyBullet(1, 2, blueBug1.Position); // Fire on spawn
            greenBugBullet2 = new EnemyBullet(1, 4, blueBug2.Position); // Fire halfway
            greenBugBullet3 = new EnemyBullet(1, 4, blueBug1.Position); // Fire on spawn
            greenBugBullet4 = new EnemyBullet(1, 4, blueBug2.Position); // Fire halfway

            midBossBullet1 = new MidBossBullet(1, 5, mediumBoss.Position); // Fire on spawn

            finalBossBullet1 = new FinalBossBullet(1, 6, lastBoss.Position); // Fire on spawn



            //Load Content inside the player class
            myPlayer.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        //load textures into a dictionary
        public void loadTextures()
        {
            textures["PlayerBullet"] = Content.Load<Texture2D>("PlayerBullet");
            textures["FinalBullet"] = Content.Load<Texture2D>("FinalBullet");
            textures["MidBullet"] = Content.Load<Texture2D>("MidBullet");
            textures["BasicBullet"] = Content.Load<Texture2D>("BasicBullet");
            textures["Heart"] = Content.Load<Texture2D>("Heart");
            textures["EnemyA"] = Content.Load<Texture2D>("EnemyA");
            textures["EnemyB"] = Content.Load<Texture2D>("EnemyB");
            textures["MidBoss"] = Content.Load<Texture2D>("MidBoss");
            textures["FinalBoss"] = Content.Load<Texture2D>("FinalBoss");
        }

        //get a texture for a class
        public static Texture2D getTexture(string textureName)
        {
            return textures[textureName];
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _graphics.ToggleFullScreen();

            // TODO: Add your update logic here

            previousState = Keyboard.GetState();

            myPlayer.Update();
            blueBug1.update(gameTime);
            greenBug1.update(gameTime);
            blueBug2.update(gameTime);
            greenBug2.update(gameTime);
            mediumBoss.update(gameTime);
            lastBoss.update(gameTime);

            blueBugBullet1.update(gameTime);
            blueBugBullet2.update(gameTime);
            blueBugBullet3.update(gameTime);
            blueBugBullet4.update(gameTime);

            greenBugBullet1.update(gameTime);
            greenBugBullet2.update(gameTime);
            greenBugBullet3.update(gameTime);
            greenBugBullet4.update(gameTime);

            midBossBullet1.update(gameTime);

            finalBossBullet1.update(gameTime);

            //BasicEnemyA blueBug = new BasicEnemyA(100, 10, new Vector2(0, 0));
            //blueBug.Move();
            //base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            //not needed
            _spriteBatch.DrawString(font, "Debug Bullet", new Vector2(515, 20), Color.Black);
            _spriteBatch.DrawString(font, "Score:" + this.score, new Vector2(515, 40), Color.Black);
            _spriteBatch.Draw(heart, new Vector2(525, 60), Color.White);
            _spriteBatch.Draw(heart, new Vector2(535, 60), Color.White);
            _spriteBatch.Draw(heart, new Vector2(545, 60), Color.White);
            _spriteBatch.Draw(heart, new Vector2(555, 60), Color.White);
            _spriteBatch.Draw(heart, new Vector2(565, 60), Color.White);
            _spriteBatch.Draw(heart, new Vector2(575, 60), Color.White);
            _spriteBatch.Draw(heart, new Vector2(585, 60), Color.White);
            _spriteBatch.Draw(heart, new Vector2(595, 60), Color.White);
            _spriteBatch.Draw(heart, new Vector2(605, 60), Color.White);
            //_spriteBatch.Draw(enemyA, new Vector2(100, 100), Color.White);
            //_spriteBatch.Draw(enemyB, new Vector2(150, 100), Color.White);
            //_spriteBatch.Draw(midBoss, new Vector2(200, 100), Color.White);
            //_spriteBatch.Draw(finalBoss, new Vector2(300, 100), Color.White);
            //_spriteBatch.Draw(basicBullet, new Vector2(350, 110), Color.White);

            //Draw the player on the GUI
            myPlayer.Draw(_spriteBatch);

            if (gameTime.TotalGameTime.TotalSeconds < 24)
            {/*
                blueBug.draw(_spriteBatch);
                blueBug2.draw(_spriteBatch);
                blueBugBullet.draw(_spriteBatch); */
                updateColors(Color.White, 1, gameTime);
            }
            if (gameTime.TotalGameTime.TotalSeconds >= 24 && gameTime.TotalGameTime.TotalSeconds < 48)
            {
                updateColors(Color.Yellow, 2, gameTime);
                //greenBug.draw(_spriteBatch);
                //draw(_spriteBatch);
            }
            if (gameTime.TotalGameTime.TotalSeconds >= 48 && gameTime.TotalGameTime.TotalSeconds < 75)
            {
                updateColors(Color.Gray, 3, gameTime);
                //mediumBoss.draw(_spriteBatch);
            }
            if (gameTime.TotalGameTime.TotalSeconds >= 75 && gameTime.TotalGameTime.TotalSeconds < 92)
            {
                updateColors(Color.White, 0, gameTime);
            }
            if (gameTime.TotalGameTime.TotalSeconds >= 92 && gameTime.TotalGameTime.TotalSeconds < 120)
            {
                updateColors(Color.Red, 4, gameTime);
                //lastBoss.draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // newColor = color value, stage (1 - 4)
        public void updateColors(Color newColor, int stage, GameTime gameTime)
        {
            if (stage == 1)
            {
                GraphicsDevice.Clear(newColor);

                // Enemy & Bullets

                blueBug1.draw(_spriteBatch);
                blueBug2.draw(_spriteBatch);
                blueBugBullet1.draw(_spriteBatch);
                blueBugBullet2.draw(_spriteBatch);

                if (gameTime.TotalGameTime.TotalSeconds == 12)
                {
                    blueBugBullet3.Position = blueBug1.Position;
                    blueBugBullet4.Position = blueBug2.Position;
                    blueBugBullet3.draw(_spriteBatch);
                    blueBugBullet4.draw(_spriteBatch);
                }
                if (gameTime.TotalGameTime.TotalSeconds >= 12)
                {
                    blueBugBullet3.draw(_spriteBatch);
                    blueBugBullet4.draw(_spriteBatch);
                }
            }
            else if (stage == 2)
            {
                GraphicsDevice.Clear(newColor);
                greenBug1.draw(_spriteBatch);
                greenBug2.draw(_spriteBatch);
                greenBugBullet1.draw(_spriteBatch);
                greenBugBullet2.draw(_spriteBatch);
            }
            else if (stage == 3)
            {
                GraphicsDevice.Clear(newColor);
                mediumBoss.draw(_spriteBatch);
                midBossBullet1.draw(_spriteBatch);
            }
            else if (stage == 0)
            {
                GraphicsDevice.Clear(newColor);
            }
            else if (stage == 4)
            {
                GraphicsDevice.Clear(newColor);
                lastBoss.draw(_spriteBatch);
                finalBossBullet1.draw(_spriteBatch);
            }
        }
    }
}
