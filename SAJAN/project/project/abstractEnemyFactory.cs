using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    interface abstractEnemyFactory
    { 
        abstractEnemy getEnemy(GraphicsDevice graphicsDevice, int Hp, float V, Vector2 cord, int newAttackPattern);

    }
}
