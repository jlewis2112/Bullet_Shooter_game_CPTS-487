using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace project
{
    /*
     * Basic Enemy A class
     * 
     * This is inherited by Enemy.
     */
    class BasicEnemyA : Enemy, abstractEnemy 
    {
        //draw the enemy shape in a random spot here.
        //If it moves make a function here.
        //No attributes other than the sprite details.
        //Were going to need to be creative here

        //construct Enemy A
        public BasicEnemyA(GraphicsDevice graphicsDevice, int Hp, float V, Vector2 cord, int newAttackPattern) : base()
        {
            this.Sprite = Game1.getTexture("EnemyA");
            this.health = Hp;
            this.position = cord;
            this.velocity = V;
            this.attackPattern = newAttackPattern; // 1 = Diamond, 2 = Lateral
        }

        //Update function will need to be implemented later
        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            if (this.IsInWindow() && attackPattern == 1)
            {
                if (gameTime.TotalGameTime.TotalSeconds < 6)
                {
                    this.position.X += 1 * this.velocity;
                    this.position.Y += 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 12)
                {
                    this.position.X -= 1 * this.velocity;
                    this.position.Y += 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 18)
                {
                    this.position.X -= 1 * this.velocity;
                    this.position.Y -= 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 24)
                {
                    this.position.X += 1 * this.velocity;
                    this.position.Y -= 1 * this.velocity;
                }
            }
            if (this.IsInWindow() && attackPattern == 2)
            {
                if (gameTime.TotalGameTime.TotalSeconds < 6)
                {
                    this.position.X -= 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 12)
                {
                    this.position.X += 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 18)
                {
                    this.position.X -= 1 * this.velocity;
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 24)
                {
                    this.position.X += 1 * this.velocity;
                }
            }



        }

        public void ChangeLocation(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        public void Move()
        {
            int i = 0;
            while (i < 20)
            {
                ChangeLocation(100, 100);
                ChangeLocation(100, 50);
                ChangeLocation(50, 50);
                ChangeLocation(50, 100);
                i++;
            }
        }


        //draw the sprite
        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);/*
            if (this.IsAlive)
            {
                int newX = 0;
                int newY = 0;
                int i = 0;
                while (i < 10000)
                {                    
                    ChangeLocation(100+newX, 100+newY);
                    spriteBatch.Draw(this.Sprite, position, Color.White);
                    newX += 10;
                    newY += 10;
                    i++;
                }*/
            spriteBatch.Draw(this.Sprite, position, Color.White);

        }
        public void draw(SpriteBatch spriteBatch, Color color)
        {
            base.draw(spriteBatch);
            spriteBatch.Draw(this.Sprite, position, color);
        }
    }
}
