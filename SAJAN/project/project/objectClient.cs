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

        public void clientEnemy(abstractEnemyFactory factory, GraphicsDevice graphicsDevice, int Hp, float V, Vector2 cord, int newAttackPattern)
        {
            productEnemy = factory.getEnemy(graphicsDevice, Hp, V, cord, newAttackPattern);
        }

        public void clientBoss(abstractBossFactory factory, int Hp, float V, Vector2 cord)
        {
            productBoss = factory.getBoss(Hp, V, cord);
        }

        public void clientBullet(abstractBulletFactory factory, int Dm, float V, Vector2 cord)
        {
            productBullet = factory.getBullet(Dm, V, cord);
        }
        
    }
}
