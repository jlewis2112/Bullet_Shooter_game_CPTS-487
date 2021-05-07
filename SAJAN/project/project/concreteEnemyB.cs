using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    class concreteEnemyB : abstractEnemyFactory
    {
        public abstractEnemy getEnemy(GraphicsDevice graphicsDevice, int Hp, float V, Vector2 cord, int newAttackPattern)
        {
            return new BasicEnemyA(graphicsDevice, Hp, V, cord, newAttackPattern);
        }
    }
}
