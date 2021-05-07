using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    /*
     * This is the Enemy Bullet Class
     * Represents the bullets from a basic Enemy A or B
     */
    class EnemyBullet : Bullet, abstractBullet
    {
        public EnemyBullet(int Dm, Vector2 V, Vector2 cord) : base()
        {
            this.Sprite = Game1.getTexture("BasicBullet");
            this.damage = Dm;
            this.position = cord;
            this.velocity = V;
        }


        //Update function will need to be implemented later
        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            if (gameTime.TotalGameTime.TotalSeconds < 120)
            {
                this.position.X += 1 * this.velocity.X;
                this.position.Y += 1 * this.velocity.Y;
            }
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
        public void draw(SpriteBatch spriteBatch, Color color)
        {
            base.draw(spriteBatch);
            spriteBatch.Draw(this.Sprite, position, color);
        }
    }
}
