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
    class Player
    {
        private int locx;
        private int locy;
        private Hitbox box = new Hitbox();

        private GraphicsDevice _graphicsDevice;
        private Texture2D _texture;
        private Vector2 _position = new Vector2(350, 600);
        private Vector2 _recPos = new Vector2(30, 40);
        private Vector2 velocity = new Vector2(0.0f, 0.0f);
        int screenWidth;
        int screenHeight;
        protected Texture2D _rectangleTexture;

        public int Locx
        {
            get
            {
                return this.locx;
            }

            set
            {
                this.locx = value;
            }
        }

        public int Locy
        {
            get
            {
                return this.locy;
            }

            set
            {
                this.locy = value;
            }
        }

        //need to creat fire function
        public Rectangle Rectangle
        {
            get { return new Rectangle(0, 0, 0, 0); }
        }

        public bool ShowRectangle { get; set; }
        //Player constructor 
        public Player()
        {
            _texture = null;
            ShowRectangle = false;
        }
        public Player(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;

        }

        public void LoadContent(ContentManager Content)
        {
            //Load the player sprite
            _texture = Content.Load<Texture2D>("bolong");
            //Get the current screenwidth & height so pl1yer would not go off screen
            screenWidth = _graphicsDevice.Viewport.Width;
            screenHeight = _graphicsDevice.Viewport.Height;
            SetRectangleTexture(_texture);
        }

        /// <summary>
        /// Reference this youtube video https://www.youtube.com/watch?v=Nmmy0lSyg7M
        /// </summary>
        /// <param name="texture"></param>
        private void SetRectangleTexture(Texture2D texture)
        {
            var colors = new List<Color>();

            for (int y = 0; y < ((texture.Height / 2) - 20); y++)
            {
                for (int x = 0; x < ((texture.Width / 2) - 20); x++)
                {
                    if (y == 0 || // On the top
                        x == 0 || // On the left
                        y == (texture.Height - 1) || // on the bottom
                        x == ((texture.Width - 1))) // on the right
                    {
                        colors.Add(new Color(255, 255, 255, 255));
                    }
                    else
                    {
                        colors.Add(new Color(300, 300, 300, 300));
                    }
                }
            }

            _rectangleTexture = new Texture2D(_graphicsDevice, ((texture.Width / 2) - 20), ((texture.Height / 2) - 20));
            _rectangleTexture.SetData<Color>(colors.ToArray());
        }

        //Move the player in directions and update
        public void Update()
        {
            box.Locx = (int)_position.X;
            box.Locy = (int)_position.Y;

            //Swtich to slow speed
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                ShowRectangle = true;
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    _position.Y += 1;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    _position.Y -= 1;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    _position.X -= 1;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    _position.X += 1;
                }
            }

            //Normal Speed
            else
            {
                ShowRectangle = false;
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    _position.Y += 5;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    _position.Y -= 5;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    _position.X -= 5;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    _position.X += 5;
                }
            }

            if (_position.X <= 0)
            {
                _position.X = 0;
            }
            if (_position.Y <= 0)
            {
                _position.Y = 0;
            }

            //Not letting the player go beyond screen width
            if (_position.X + _texture.Width >= screenWidth)
            {
                _position.X = screenWidth - _texture.Width;
            }

            //Not letting the player go beyond screen height
            if (_position.Y + _texture.Height >= screenHeight)
            {
                _position.Y = screenHeight - _texture.Height;
            }
        }


        public void Draw(SpriteBatch sprit)
        {
            //box.draw(sprit);
            sprit.Draw(_texture, _position, Color.White);
            if (ShowRectangle)
            {
                if (_rectangleTexture != null)
                    sprit.Draw(_rectangleTexture, (_position + _recPos), Color.White);
            }

        }

    }

}

