using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    /*
     * This is the Mid boss class
     * Inherited by enemy
     */
    class MidBoss : Enemy, abstractBoss
    {
        //draw the enemy shape in a random spot here.
        //If it moves make a function here.
        //No attributes other than the sprite details.
        //We need to make the two attacks in the play through video.

        //construct Mid Boss
        public MidBoss(int Hp, float V, Vector2 cord) : base()
        {
            this.Sprite = Game1.getTexture("MidBoss");
            this.health = Hp;
            this.position = cord;
            this.velocity = V;
        }

        //Update function will need to be implemented later
        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            base.update(gameTime);
            if (gameTime.TotalGameTime.TotalSeconds >= 48 && gameTime.TotalGameTime.TotalSeconds < 55)
            {
                this.position.X += 1 * this.velocity;
                this.position.Y += 1 * this.velocity;
            }
            else if (gameTime.TotalGameTime.TotalSeconds >= 55 && gameTime.TotalGameTime.TotalSeconds < 62)
            {
                this.position.X -= 1 * this.velocity;
                this.position.Y += 1 * this.velocity;
            }
            else if (gameTime.TotalGameTime.TotalSeconds >= 62 && gameTime.TotalGameTime.TotalSeconds < 69)
            {
                this.position.X -= 1 * this.velocity;
                this.position.Y -= 1 * this.velocity;
            }
            else if (gameTime.TotalGameTime.TotalSeconds >= 69 && gameTime.TotalGameTime.TotalSeconds < 75)
            {
                this.position.X += 1 * this.velocity;
                this.position.Y -= 1 * this.velocity;
            }
        }

        //draw the sprite
        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            if (this.IsAlive)
            {
                spriteBatch.Draw(this.Sprite, position, Color.White);
            }
        }

        //unique attack
        public void MidAttack()
        {
            //create the bullets in the bullet factory and let them fly in the needed direction.
        }
    }
}
