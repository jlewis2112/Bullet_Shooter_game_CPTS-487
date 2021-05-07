using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Text;

namespace project
{
    class Pattern
    {

        int selection;
        int screenWidth;
        int screenHeight;
        GraphicsDevice _graphicsDevice;
        public Pattern()
        {

        }

        public Pattern(int patternSelection)
        {
            //this._graphicsDevice = graphicsDevice;
            this.selection = patternSelection;
            //this.sprite = enemy;
            //this.screenWidth = _graphicsDevice.Viewport.Width;
            //this.screenHeight = _graphicsDevice.Viewport.Height;
            
        }


        public Vector2 Move(GameTime gameTime, Vector2 position, Vector2 velocity, int stage, Texture2D sprite)
        {
            float adjustedWidth = position.X + sprite.Width;
            float adjustedHeight = position.Y + sprite.Height;

            if (gameTime.TotalGameTime.TotalSeconds >= 24 && gameTime.TotalGameTime.TotalSeconds < 48)
            {
                stage = 2;
            }
            else if (gameTime.TotalGameTime.TotalSeconds >= 48 && gameTime.TotalGameTime.TotalSeconds < 72)
            {
                stage = 3;
            }
            else if (gameTime.TotalGameTime.TotalSeconds >= 72 && gameTime.TotalGameTime.TotalSeconds < 96)
            {
                stage = 4;
            }
            else if (gameTime.TotalGameTime.TotalSeconds >= 96 && gameTime.TotalGameTime.TotalSeconds < 120)
            {
                stage = 5;
            }

            if (this.selection == 1) // Diamond
            {
                if (gameTime.TotalGameTime.TotalSeconds < 3 * stage)
                {
                    if (adjustedWidth < 470)
                    {
                        position.X += 1 * velocity.X;
                    }

                    if (adjustedHeight < 470)
                    {
                        position.Y += 1 * velocity.Y;
                    }
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 6 * stage)
                {
                    if (adjustedWidth > 40)
                    {
                        position.X -= 1 * velocity.X;
                    }

                    if (adjustedHeight < 470)
                    {
                        position.Y += 1 * velocity.Y;
                    }
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 9 * stage)
                {
                    if (position.X > 40)
                    {
                        position.X -= 1 * velocity.X;
                    }

                    if (position.Y > 40)
                    {
                        position.Y -= 1 * velocity.Y;
                    }
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 12 * stage)
                {
                    if (adjustedWidth < 470)
                    {
                        position.X += 1 * velocity.X;
                    }


                    if (position.Y > 40)
                    {
                        position.Y -= 1 * velocity.Y;
                    }
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 15 * stage)
                {
                    if (adjustedWidth < 470)
                    {
                        position.X += 1 * velocity.X;
                    }

                    if (adjustedHeight < 470)
                    {
                        position.Y += 1 * velocity.Y;
                    }
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 18 * stage)
                {
                    if (adjustedWidth > 40)
                    {
                        position.X -= 1 * velocity.X;
                    }

                    if (adjustedHeight < 470)
                    {
                        position.Y += 1 * velocity.Y;
                    }
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 21 * stage)
                {
                    if (position.X > 40)
                    {
                        position.X -= 1 * velocity.X;
                    }

                    if (position.Y > 40)
                    {
                        position.Y -= 1 * velocity.Y;
                    }
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 24 * stage)
                {
                    if (adjustedWidth < 470)
                    {
                        position.X += 1 * velocity.X;
                    }


                    if (position.Y > 40)
                    {
                        position.Y -= 1 * velocity.Y;
                    }
                }
            }
            if (this.selection == 2) // Lateral
            {
                if (gameTime.TotalGameTime.TotalSeconds < 6 * stage)
                {
                    if (position.X > 40)
                    {
                        position.X -= 1 * velocity.X;
                    }
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 12 * stage)
                {
                    if (adjustedWidth < 470)
                    {
                        position.X += 1 * velocity.X;
                    }
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 18 * stage)
                {
                    if (position.X > 40)
                    {
                        position.X -= 1 * velocity.X;
                    }
                }
                else if (gameTime.TotalGameTime.TotalSeconds < 24 * stage)
                {
                    if (adjustedWidth < 470)
                    {
                        position.X += 1 * velocity.X;
                    }
                }
            }

            return position;
        }

    }
}
