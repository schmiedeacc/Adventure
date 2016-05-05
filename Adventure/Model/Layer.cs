using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Model
{
    internal class Layer
    {

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public Tile[,] Tiles
        {
            get;
            private set;
        }

        public Layer(int width, int height)
        {

            if (width < 5)
                throw new ArgumentException("Spielbereich muss mindestens 5 Zellen breit sein");
            if (height < 5)
                throw new ArgumentException("Spielfeld muss mindestens 5 Zellen hoch sein");

            Width = width;
            Height = height;

            Tiles = new Tile[width, height];
        }
    }
}
