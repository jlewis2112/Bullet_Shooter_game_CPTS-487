using System;
using System.Collections.Generic;
using System.Text;

namespace project
{
    /*
     * Hitbox Class For the player
     * 
     */
    class Hitbox
    {
        private int locx;
        private int locy;
        private int radius;

        public int Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                this.radius = value;
            }
        }

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
    }
}
