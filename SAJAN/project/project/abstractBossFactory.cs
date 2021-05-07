using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    interface abstractBossFactory
    {
        abstractBoss getBoss(int Hp, float V, Vector2 cord);
    }
}
