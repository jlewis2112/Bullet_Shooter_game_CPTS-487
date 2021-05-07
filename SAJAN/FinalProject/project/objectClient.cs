using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    /*
     * Client class for the odject factory. Your control the objects using this class
     * needed: list <enemies>(clientclass), list<bullets>(clientclass)
     */
    class objectClient
    {
        abstractEnemy productEnemy;
        abstractBoss productBoss;
        abstractBullet productBullet;

        public objectClient()
        {

        }

        public void clientEnemy(abstractEnemyFactory factory, GraphicsDevice graphicsDevice, int Hp, Vector2 V, Vector2 cord, int newAttackPattern)
        {
            productEnemy = factory.getEnemy(graphicsDevice, Hp, V, cord, newAttackPattern);
        }

        public void clientBoss(abstractBossFactory factory, int Hp, Vector2 V, Vector2 cord, int newAttackPattern)
        {
            productBoss = factory.getBoss(Hp, V, cord, newAttackPattern);
        }

        public void clientBullet(abstractBulletFactory factory, int Dm, Vector2 V, Vector2 cord)
        {
            productBullet = factory.getBullet(Dm, V, cord);            
        }

        public abstractEnemy GetEnemyDetails()
        {
            return this.productEnemy;
        }

        public abstractBullet GetEnemyBulletDetails()
        {
            return this.productBullet;
        }

        public abstractBoss GetBossDetails()
        {
            return this.productBoss;
        }

        public void UpdateEnemy(GameTime gameTime)
        {
            productEnemy.update(gameTime);
        }

        public void UpdateBoss(GameTime gameTime)
        {
            productBoss.update(gameTime);
        }

        public void UpdateBullet(GameTime gameTime)
        {
            productBullet.update(gameTime);
        }

        public void DrawEnemy(SpriteBatch spriteBatch)
        {
            productEnemy.draw(spriteBatch);
        }

        public void DrawBullet(SpriteBatch spriteBatch)
        {
            productBullet.draw(spriteBatch);
        }

        public void DrawBoss(SpriteBatch spriteBatch)
        {
            productBoss.draw(spriteBatch);
        }

        public Vector2 GetEnemyCenterCoordinates()
        {
            return productEnemy.GetCenterCoordinates();
        }

        public Vector2 GetBulletCenterCoordinates()
        {
            return productBullet.GetCenterCoordinates();
        }

        public Vector2 GetBossCenterCoordinates()
        {
            return productBoss.GetCenterCoordinates();
        }

        public void DespawnEnemy()
        {
            productEnemy.Despawn();
        }

        public void DespawnBoss()
        {
            productBoss.Despawn();
        }

        public void DespawnBullet()
        {
            productBullet.Despawn();
        }

        public void EnemyLoseLife(int damage)
        {
            productEnemy.hitEnemy(damage);
        }

        public void BossLoseLife(int damage)
        {
            productBoss.hitEnemy(damage);
        }

        public int getEnemyHealth()
        {
            return productEnemy.getHealth();
        }

        public int getBossHealth()
        {
            return productBoss.getHealth();
        }
    }
}
