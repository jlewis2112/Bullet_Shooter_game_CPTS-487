﻿using System;
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
        public PlayerBullet(int Dm, float V, Vector2 cord) : base()
        {
            this.Sprite = Game1.getTexture("PlayerBullet");
            this.damage = Dm;
            this.position = cord;
            this.velocity = V;
        }

        //Update function will need to be implemented later
        public override void update(GameTime gameTime)
        {
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
    }
}
