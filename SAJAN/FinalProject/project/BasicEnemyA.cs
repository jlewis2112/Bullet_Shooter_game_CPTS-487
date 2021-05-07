using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace project
{
    
    class BasicEnemyA : Enemy, abstractEnemy 
    {

        //construct Enemy A
        private GraphicsDevice _graphicsDevice;
        
        public BasicEnemyA()
        {

        }

        public BasicEnemyA(GraphicsDevice graphicsDevice, int Hp, Vector2 V, Vector2 cord, int newAttackPattern) : base()
        {
            this._graphicsDevice = graphicsDevice;
            this.Sprite = Game1.getTexture("EnemyA");
            this.health = Hp;
            this.position = cord;
            this.velocity = V;
            this.attackPattern = new Pattern(newAttackPattern);
        }

        //Update function will need to be implemented later
        public override void update(GameTime gameTime)
        {
            base.update(gameTime);
            this.position = attackPattern.Move(gameTime, this.position, this.velocity, 1, this.sprite);  
        }

        public void ChangeLocation(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        //draw the sprite
        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            spriteBatch.Draw(this.Sprite, position, Color.White);
        }

        public void draw(SpriteBatch spriteBatch, Color color)
        {
            base.draw(spriteBatch);
            spriteBatch.Draw(this.Sprite, position, color);
        }
    }
}
