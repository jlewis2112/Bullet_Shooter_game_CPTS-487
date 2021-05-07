using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Xna.Framework.Audio;
using System.Numerics;
using System.Text;

namespace project
{
    class Grid : Game1
    {

        public List<objectClient> enemyList;
        public List<objectClient> enemyBossList;
        public List<objectClient> enemyBulletList;
        public List<PlayerBullet> playerBulletList;
        public Player myPlayer;

        public int score;

        bool midBoss = true;

        List<SoundEffect> sounds;

        public Vector2 GetCoordinates(Vector2 position)
        {
            return GetCoordinates(position.X, position.Y);
        }

        public Vector2 GetCoordinates(float x, float y)
        {
            Vector2 vec = new Vector2();
            return vec;
        }

        public Grid()
        {
            this.sounds = new List<SoundEffect>();
            sounds.Add(Content.Load<SoundEffect>("PlayerDamage"));
            sounds.Add(Content.Load<SoundEffect>("PlayerDeath"));
            sounds.Add(Content.Load<SoundEffect>("EnemyDeath"));
            sounds.Add(Content.Load<SoundEffect>("MidBossDeath"));
            sounds.Add(Content.Load<SoundEffect>("FinalBossDeath"));           
        }

        // Check all collisions
        public void CheckCollisions(List<objectClient> newEnemyList, List<objectClient> newEnemyBossList, List<objectClient> newEnemyBulletList, List<PlayerBullet> newPlayerBulletList, Player newMyPlayer)
        {
            this.enemyList = newEnemyList;
            this.enemyBulletList = newEnemyBulletList;
            this.playerBulletList = newPlayerBulletList;
            this.enemyBossList = newEnemyBossList;
            this.myPlayer = newMyPlayer;
            CheckPlayerEnemyBulletsCollision();
            CheckPlayerEnemyCollision();
            CheckPlayerBulletEnemyCollision();
            CheckPlayerBossCollision();
            CheckPlayerBulletBossCollision();
        }


        // Check player - enemy bullets
        public void CheckPlayerEnemyBulletsCollision()
        {
            foreach (objectClient enemyBullet in this.enemyBulletList)
            {
                float enemyBulletX = enemyBullet.GetBulletCenterCoordinates().X;
                float enemyBulletY = enemyBullet.GetBulletCenterCoordinates().Y;

                float playerX = myPlayer.GetCenterCoordinates().X;
                float playerY = myPlayer.GetCenterCoordinates().Y;

                if (((enemyBulletX >= (playerX - (myPlayer.hitBoxRadius / 3)) && (enemyBulletX <= (playerX + (myPlayer.hitBoxRadius / 3)))) && ((enemyBulletY >= (playerY - (myPlayer.hitBoxRadius / 2))) && (enemyBulletY <= (playerY + (myPlayer.hitBoxRadius / 2))))))
                {
                    if (myPlayer.RespawnTime <= 0 && myPlayer.CheatMode == false)
                    {
                        if (myPlayer.GetHealth() >= 0)
                        {
                            SoundEffect.MasterVolume = 0.07f;
                            sounds[0].Play();
                        }
                        else
                        {
                            sounds[0].Dispose();
                        }
                        myPlayer.ResetPosition();
                        myPlayer.DamageHealth(1);
                        myPlayer.RespawnTime = 60;
                    }
                    enemyBullet.DespawnBullet();
                }
            }
        }

        // Check enemy - player

        public void CheckPlayerEnemyCollision()
        {
            foreach (objectClient enemy in this.enemyList)
            {
                float enemyX = enemy.GetEnemyCenterCoordinates().X;
                float enemyY = enemy.GetEnemyCenterCoordinates().Y;

                float playerX = myPlayer.GetCenterCoordinates().X;
                float playerY = myPlayer.GetCenterCoordinates().Y;

                if (((enemyX >= (playerX - (myPlayer.hitBoxRadius / 2)) && (enemyX <= (playerX + (myPlayer.hitBoxRadius / 2)))) && ((enemyY >= (playerY - myPlayer.hitBoxRadius)) && (enemyY <= (playerY + myPlayer.hitBoxRadius)))))
                {
                    if (myPlayer.RespawnTime <= 0 && myPlayer.CheatMode == false)
                    {
                        if (myPlayer.GetHealth() >= 0)
                        {
                            SoundEffect.MasterVolume = 0.07f;
                            sounds[0].Play();
                        }
                        else
                        {
                            sounds[0].Dispose();
                        }
                        myPlayer.ResetPosition();
                        myPlayer.DamageHealth(1);
                        myPlayer.RespawnTime = 60;
                    }
                }
            }
        }

        // Check boss - player
        public void CheckPlayerBossCollision()
        {
            foreach (objectClient enemy in this.enemyBossList)
            {
                float enemyX = enemy.GetBossCenterCoordinates().X;
                float enemyY = enemy.GetBossCenterCoordinates().Y;

                float playerX = myPlayer.GetCenterCoordinates().X;
                float playerY = myPlayer.GetCenterCoordinates().Y;

                if (((enemyX >= (playerX - (myPlayer.hitBoxRadius / 2)) && (enemyX <= (playerX + (myPlayer.hitBoxRadius / 2)))) && ((enemyY >= (playerY - myPlayer.hitBoxRadius)) && (enemyY <= (playerY + myPlayer.hitBoxRadius)))))
                {
                    if (myPlayer.RespawnTime <= 0 && myPlayer.CheatMode == false)
                    {
                        if (myPlayer.GetHealth() >= 0)
                        {
                            SoundEffect.MasterVolume = 0.07f;
                            sounds[0].Play();
                        }
                        else
                        {
                            sounds[0].Dispose();
                        }
                        myPlayer.ResetPosition();
                        myPlayer.DamageHealth(1);
                        myPlayer.RespawnTime = 60;
                    }

                }
            }
        }

        // Check player bullet - enemy
        public void CheckPlayerBulletEnemyCollision()
        {
            foreach (objectClient enemy in this.enemyList)
            {
                foreach (PlayerBullet playerBullet in this.playerBulletList)
                {
                    float enemyX = enemy.GetEnemyCenterCoordinates().X;
                    float enemyY = enemy.GetEnemyCenterCoordinates().Y;
                    float playerBulletX = playerBullet.GetCenterCoordinates().X;
                    float playerBulletY = playerBullet.GetCenterCoordinates().Y;

                    if (((enemyX >= (playerBulletX - 10) && (enemyX <= (playerBulletX + 10))) && ((enemyY >= (playerBulletY - 10)) && (enemyY <= (playerBulletY + 10)))))
                    {
                        enemy.EnemyLoseLife(playerBullet.Damage);
                        playerBullet.Despawn();
                        if (enemy.getEnemyHealth() <= 0)
                        {
                            SoundEffect.MasterVolume = 0.07f;
                            sounds[2].Play();
                            enemy.DespawnEnemy();
                            score += 100;
                        }
                        else
                        {
                            score += 10;
                        }
                    }
                }
            }
        }

        public void CheckPlayerBulletBossCollision()
        {
            foreach (objectClient enemy in this.enemyBossList)
            {
                foreach (PlayerBullet playerBullet in this.playerBulletList)
                {
                    float enemyX = enemy.GetBossCenterCoordinates().X;
                    float enemyY = enemy.GetBossCenterCoordinates().Y;
                    float playerBulletX = playerBullet.GetCenterCoordinates().X;
                    float playerBulletY = playerBullet.GetCenterCoordinates().Y;

                    if (((enemyX >= (playerBulletX - 20) && (enemyX <= (playerBulletX + 20))) && ((enemyY >= (playerBulletY - 20)) && (enemyY <= (playerBulletY + 20)))))
                    {
                        enemy.BossLoseLife(playerBullet.Damage);
                        playerBullet.Despawn();
                        if (enemy.getBossHealth() <= 0)
                        {
                            if (this.midBoss == true)
                            {
                                SoundEffect.MasterVolume = .70f;
                                sounds[3].Play();
                                this.midBoss = false;
                            }
                            else
                            {
                                SoundEffect.MasterVolume = .85f;
                                sounds[4].Play();
                            }
                            
                            enemy.DespawnBoss();
                            score += 500;
                        }
                        else
                        {
                            score += 10;
                        }
                    }
                }
            }
        }
    }
}
