using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    interface abstractBulletFactory
    {
        abstractBullet getBullet(int Dm, Vector2 V, Vector2 cord);
    }
}
