using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace project
{
    interface abstractEnemy
    {
        public void update(GameTime gameTime);
        
        public void draw(SpriteBatch spriteBatch);
    }
}
