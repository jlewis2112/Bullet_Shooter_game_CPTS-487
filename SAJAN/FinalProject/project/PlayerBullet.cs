using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    /*
     * The player bullet class
     * representing the players bullet
     */
    class PlayerBullet : Bullet
    {
        public bool isVisible;
        public int bulletDelay;

        public PlayerBullet(Texture2D texture)
        {
            this.Sprite = texture;
            this.damage = 25;
        }

        //Update function will need to be implemented later
        public override void update(GameTime gameTime)
        {
            moveUp(10f);
            base.update(gameTime);
        }

        //draw the sprite
        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            if (IsInWindow())
            {
                spriteBatch.Draw(this.Sprite, position, Color.White);                
            }
        }

        public void shoot()
        {
            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }
            //If bullet delay is at 0 then create new bullet at player position and visiblt it. Add that bullet to the list
            if (bulletDelay <= 0)
            {
                PlayerBullet bullets = new PlayerBullet(Game1.getTexture("PlayerBullet"));
                bullets.Position = new Vector2(position.X + 32 - bullets.Sprite.Width / 2, position.Y + 30);
                bullets.isVisible = true;
            }

            if (bulletDelay == 0)
            {
                bulletDelay = 20;
            }
        }

    }
}
