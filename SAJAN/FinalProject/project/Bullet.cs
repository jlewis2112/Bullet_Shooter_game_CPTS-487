using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    /*
     * The bullet superclass
     */
    class Bullet : Object
    {
        protected int damage;


        //get the damage value of a bullet
        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                this.damage = value;
            }
        }

        //Update the bullets details
        public override void update(GameTime gameTime) { }

        //Draw the bullet detials
        public override void draw(SpriteBatch spritBatch) { }



    }
}
