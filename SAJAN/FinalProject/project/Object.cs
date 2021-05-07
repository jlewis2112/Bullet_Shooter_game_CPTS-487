using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//this is the object class
namespace project
{

    class Object
    {
        protected Texture2D sprite;
        public double hitBoxRadius;
        public Vector2 position;
        protected Vector2 velocity;


        public Object() : base()
        {

        }

        //get and set the movement speed of an enemy
        public Vector2 Velocity
        {
            get { return this.velocity; }
            set { this.velocity = value; }
        }

        //get and set the postion of the enemy
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Vector2 GetPosition()
        {
            return this.position;
        }

        //get and set the sprite
        public virtual Texture2D Sprite
        {
            get { return this.sprite; }
            set
            {
                this.sprite = value;
                this.hitBoxRadius = sprite.Width;
            }
        }

        //get the center of the enemy
        public virtual Vector2 GetCenterCoordinates()
        {
            return new Vector2(this.Position.X + (float)this.Sprite.Width / 2, this.Position.Y + this.Sprite.Height / 2);
        }

        public void Despawn()
        {
            this.position = new Vector2(-10000, -10000);
        }

        //determine if the enemy is in the window.FLAG may be adjusted
        public bool IsInWindow()
        {
            return IsInX() && IsInY();
        }

        //determine if the enemy is in the X coordinate
        public bool IsInX()
        {
            if (sprite == null) return false;
            float adjustedWidth = position.X + sprite.Width;
            if (adjustedWidth < 500 && adjustedWidth > -1)
            {
                return true;
            }
            return false;
        }

        public bool IsInXRight()
        {
            if (sprite == null) return false;
            float adjustedWidth = position.X + sprite.Width;
            if (adjustedWidth < 500)
            {
                return true;
            }
            return false;
        }

        public bool IsInXLeft()
        {
            if (sprite == null) return false;
            float adjustedWidth = position.X + sprite.Width;
            if (adjustedWidth > -1)
            {
                return true;
            }
            return false;
        }

        //determine if the enemy is in the Y coordinate
        public bool IsInY()
        {
            if (sprite == null) return false;
            float adjustedHeight = position.Y + sprite.Height;
            if (adjustedHeight < 500 && adjustedHeight > -1)
            {
                return true;
            }
            return false;
        }

        public bool IsInYUp()
        {
            if (sprite == null) return false;
            float adjustedHeight = position.Y + sprite.Height;
            if (adjustedHeight > -1)
            {
                return true;
            }
            return false;
        }

        public bool IsInYDown()
        {
            if (sprite == null) return false;
            float adjustedHeight = position.Y + sprite.Height;
            if (adjustedHeight < 500)
            {
                return true;
            }
            return false;
        }

        //move the enemy to the left
        public void moveLeft(float V)
        {
            this.position.X -= V;
        }

        //move the enemy to the right
        public void moveRight(float V)
        {
            this.position.X += V;
        }

        //move the enemy up
        public void moveUp(float V)
        {
            this.position.Y -= V;
        }

        //Move the enemy down
        public void moveDown(float V)
        {
            this.position.Y += V;
        }

        //Update the enemies details
        public virtual void update(GameTime gameTime) { }

        //Draw the enemy
        public virtual void draw(SpriteBatch spritBatch) { }

    }
}
