using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    /*
     * Enemy Class
     * This is a Super class
     */
    class Enemy : Object
    {
        protected int health;
        protected bool isAlive;
        public int attackPattern;
        //add a bullet factory here

        public Enemy() : base()
        {
            this.isAlive = true;
            //initailize the bullet factory
        }

        //get and set for is alive
        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = value;
            }
        }

        //enemy life decreasing by 1
        public void hitEnemy(int damage)
        {
            this.health -= damage;
            if (this.health <= 0)
            {
                this.isAlive = false;
            }
        }


        //Update the enemies details
        public override void update(GameTime gameTime) { }

        //Draw the enemy
        public override void draw(SpriteBatch spritBatch) { }


        //need to have a basic attack function. Can be moved to the subclasses if it is to difficult.
        public void basicAttack()
        {
            //add a bullet factory call and place it at
        }
    }
}
