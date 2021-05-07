using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project
{
    /*
     * Basic Enemy B class
     * 
     * This is inherited by Enemy.
     */
    class BasicEnemyB : Enemy, abstractEnemy
    {
        //draw the enemy shape in a random spot here.
        //If it moves make a function here.
        //No attributes other than the sprite details.
        //Were going to need to be creative.

        int screenWidth;
        int screenHeight;
        private GraphicsDevice _graphicsDevice;

        //construct Enemy 
        public BasicEnemyB(GraphicsDevice graphicsDevice, int Hp, float V, Vector2 cord, int newAttackPattern) : base()
        {
            this._graphicsDevice = graphicsDevice;
            this.screenWidth = this._graphicsDevice.Viewport.Width;
            this.screenHeight = this._graphicsDevice.Viewport.Height;
            this.Sprite = Game1.getTexture("EnemyB");
            this.health = Hp;
            this.position = cord;
            this.velocity = V;
            this.attackPattern = newAttackPattern;
        }

        //Update function will need to be implemented later
        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            if (this.IsInWindow() && attackPattern == 1)
            {
                if (gameTime.TotalGameTime.TotalSeconds >= 24 && gameTime.TotalGameTime.TotalSeconds < 30)
                {
                    this.position.X += 1 * this.velocity;
                    this.position.Y += 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds >= 30 && gameTime.TotalGameTime.TotalSeconds < 36)
                {
                    this.position.X -= 1 * this.velocity;
                    this.position.Y += 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds >= 36 && gameTime.TotalGameTime.TotalSeconds < 42)
                {
                    this.position.X -= 1 * this.velocity;
                    this.position.Y -= 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds >= 42 && gameTime.TotalGameTime.TotalSeconds < 48)
                {
                    this.position.X += 1 * this.velocity;
                    this.position.Y -= 1 * this.velocity;
                }
            }

            // attackPattern 2
            if (this.IsInWindow() && attackPattern == 2)
            {
                if (gameTime.TotalGameTime.TotalSeconds >= 24 && gameTime.TotalGameTime.TotalSeconds < 30)
                {
                    this.position.X -= 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds >= 30 && gameTime.TotalGameTime.TotalSeconds < 36)
                {
                    this.position.X += 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds >= 36 && gameTime.TotalGameTime.TotalSeconds < 42)
                {
                    this.position.X -= 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds >= 42 && gameTime.TotalGameTime.TotalSeconds < 48)
                {
                    this.position.X += 1 * this.velocity;
                }
            }
        }

        //draw the sprite
        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            if (this.IsAlive)
            {
                spriteBatch.Draw(this.Sprite, position, Microsoft.Xna.Framework.Color.White);
            }
        }
    }
}
