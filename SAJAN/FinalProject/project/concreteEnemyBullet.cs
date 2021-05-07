using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    class concreteEnemyBullet : abstractBulletFactory
    {
        public abstractBullet getBullet(int Dm, Vector2 V, Vector2 cord)
        {
            return new EnemyBullet(Dm, V, cord);
        }
    }
}
