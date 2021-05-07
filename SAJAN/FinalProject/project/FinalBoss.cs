using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    /*
     * This is the Final boss class
     * Inherited by enemy
     */
    class FinalBoss : Enemy, abstractBoss
    {
        //draw the enemy shape in a random spot here.
        //If it moves make a function here.
        //No attributes other than the sprite details.
        //add a unique mid boss attack

        //construct Final Boss
        public FinalBoss(int Hp, Vector2 V, Vector2 cord, int newAttackPattern) : base()
        {
            this.Sprite = Game1.getTexture("FinalBoss");
            this.health = Hp;
            this.position = cord;
            this.velocity = V;
            this.attackPattern = new Pattern(newAttackPattern);
        }

        //Update function will need to be implemented later
        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            base.update(gameTime);
            this.position = attackPattern.Move(gameTime, this.position, this.velocity, 1, this.sprite);
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
        public void FirstAttack()
        {
            //create the bullets in the bullet factory and let them fly in the needed direction.
        }

        //unique second Attack
        public void SecondAttack()
        {
            //create the bullets in the bullet factory and let them fly in the needed direction.
        }
    }
}
