using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace project
{
    class concreteMidBoss : abstractBossFactory
    {
        public abstractBoss getBoss(int Hp, Vector2 V, Vector2 cord, int newAttackPattern)
        {
            return new MidBoss(Hp, V, cord, newAttackPattern);
        }
    }
}
