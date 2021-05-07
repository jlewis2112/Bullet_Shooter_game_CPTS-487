using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    interface abstractBullet
    {
        public void update(GameTime gameTime);

        public void draw(SpriteBatch spriteBatch);

        public Vector2 GetPosition();

        public Vector2 GetCenterCoordinates();

        public void Despawn();
    }
}
