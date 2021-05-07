using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;
using Color = Microsoft.Xna.Framework.Color;
using Microsoft.Xna.Framework.Input;


namespace project
{
    //standard player class
    class Player : Object
    {
        protected int health;
        int screenWidth;
        int screenHeight;
        private GraphicsDevice _graphicsDevice;
        private Vector2 _recPos = new Vector2(30, 40);
        protected Texture2D _rectangleTexture;
        public int bulletDelay;
        public List<PlayerBullet> bulletList;

        private int respawnTime;
        private bool cheatMode;

        //need to creat fire function
        public Rectangle Rectangle
        {
            get { return new Rectangle(0, 0, 0, 0); }
        }

        public bool ShowRectangle { get; set; }

        public bool CheatMode { get; set; }


        public Player(int Hp, Vector2 V, Vector2 cord, GraphicsDevice graphicsDevice) : base()
        {
            this.Sprite = Game1.getTexture("bolong");
            this.health = Hp;
            this.position = cord;
            this.velocity = V;
            _graphicsDevice = graphicsDevice;
            screenWidth = _graphicsDevice.Viewport.Width;
            screenHeight = _graphicsDevice.Viewport.Height;
            ShowRectangle = false;
            SetRectangleTexture(Sprite);
            bulletList = new List<PlayerBullet>();
            bulletDelay = 20;
            respawnTime = 0;
            cheatMode = false;
        }

        public int RespawnTime
        {
            get { return this.respawnTime; }
            set { respawnTime = value; }
        }
                
        /// <summary>
        /// Reference this youtube video https://www.youtube.com/watch?v=Nmmy0lSyg7M
        /// </summary>
        /// <param name="texture"></param>
        private void SetRectangleTexture(Texture2D texture)
        {
            var colors = new List<Color>();

            for (int y = 0; y < ((texture.Height/2)-20); y++)
            {
                for (int x = 0; x < ((texture.Width/2)-20); x++)
                {
                    if (y == 0 || // On the top
                        x == 0 || // On the left
                        y == (texture.Height-1) || // on the bottom
                        x == ((texture.Width-1))) // on the right
                    {
                        colors.Add(new Color(255, 255, 255, 255)); 
                    }
                    else
                    {
                        colors.Add(new Color(300, 300, 300, 300)); 
                    }
                }
            }

            _rectangleTexture = new Texture2D(_graphicsDevice, ((texture.Width/2)-20), ((texture.Height/2)-20));
            _rectangleTexture.SetData<Color>(colors.ToArray());
        }

        public override void update(GameTime gameTime)
        {
            base.update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                ShowRectangle = true;
                if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    if (IsInYDown() == true)
                    {
                        this.moveDown(1f);
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    if (IsInYUp() == true)
                    {
                        this.moveUp(1f);
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    if (IsInXLeft() == true)
                    {
                        this.moveLeft(1f);
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    if (IsInXRight() == true)
                    {
                        this.moveRight(1f);
                    }
                }
                
                //UpdateBullets();
            }
            else
            {
                ShowRectangle = false;
                if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    if (IsInYDown() == true)
                    {
                        this.moveDown(5f);
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    if (IsInYUp() == true)
                    {
                        this.moveUp(5f);
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    if (IsInXLeft() == true)
                    {
                        this.moveLeft(5f);
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    if (IsInXRight() == true)
                    {
                        this.moveRight(5f);
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Shoot();
                }
                UpdateBullets();
            }
            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.Y <= 0)
            {
                position.Y = 0;
            }

            //Not letting the player go beyond screen width
            if (position.X + sprite.Width >= screenWidth)
            {
                position.X = screenWidth - sprite.Width;
            }

            //Not letting the player go beyond screen height
            if (position.Y + sprite.Height >= screenHeight)
            {
                position.Y = screenHeight - sprite.Height;
            }
        }

        public void DamageHealth(int hearts)
        {
            health -= hearts;
        }

        public override void draw(SpriteBatch spriteBatch)
         {
                spriteBatch.Draw(this.Sprite, position, Color.White);
                foreach (PlayerBullet b in bulletList) {
                   b.draw(spriteBatch);
                }
                if (ShowRectangle)
                {
                    if (_rectangleTexture != null)
                        spriteBatch.Draw(_rectangleTexture, (position + _recPos), Color.White);
                }
        }

        public int GetHealth()
        {
            return this.health;
        }

        public void ResetPosition()
        {
            this.position = new Vector2(350, 800);
        }

        //Shoot method
        public void Shoot()
        {

        }

        public void UpdateBullets() {
            //for each bullet in the list, update the movement and if the bullets hits
            // the top of the screen remove it from the list
            foreach (PlayerBullet b in bulletList) {
                //b.moveUp(10f);
             }
        }
    }

}

