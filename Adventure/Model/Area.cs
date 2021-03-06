﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Model
{
    internal class Area
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

        public Layer [] Layers
        {
            get;
            set;
        }

        public Tile[,] Tiles
        {
            get;
            private set;
        }

        public List<Item> Items
        {
            get;
            private set;
        }

        public Area(int layers, int width, int height)
        {
            if (width < 5)
                throw new ArgumentException("Spielbereich muss mindestens 5 Zellen breit sein");
            if (height < 5)
                throw new ArgumentException("Spielfeld muss mindestens 5 Zellen hoch sein");

            Width = width;
            Height = height;

            Layers = new Layer[layers];
            for (int l = 0; l < layers; l++)
                Layers[l] = new Layer(width, height);
            

            Tiles = new Tile[width,height];
            Items = new List<Item>();
        }
    }
}
