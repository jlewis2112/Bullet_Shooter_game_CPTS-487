using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    class concreteEnemyB : abstractEnemyFactory
    {
        public abstractEnemy getEnemy(GraphicsDevice graphicsDevice, int Hp, Vector2 V, Vector2 cord, int newAttackPattern)
        {
            return new BasicEnemyB(graphicsDevice, Hp, V, cord, newAttackPattern);
        }
    }
}
