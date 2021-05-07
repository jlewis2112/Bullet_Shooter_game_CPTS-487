using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace project
{
    class concreteMidBoss : abstractBossFactory
    {
        public abstractBoss getBoss(int Hp, float V, Vector2 cord)
        {
            return new MidBoss(Hp, V, cord);
        }
    }
}
