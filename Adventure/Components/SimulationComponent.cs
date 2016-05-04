using Adventure.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    internal class SimulationComponent : GameComponent
    {
        private readonly Adventure game;

        public World World
        {
            get;
            private set;
        }

        public Player Player
        {
            get;
            private set;
        }

        public SimulationComponent (Adventure game) : base(game)
        {
            this.game = game;

            NewGaem();

        }

        public void NewGaem()
        {
            World = new World();

            Area area = new Area(30, 20);
            for (int x = 0; x < area.Width; x++)
            {
                for (int y = 0; y < area.Height; y++)
                {
                    area.Tiles[x, y] = new Tile();
                }
            }

            Player = new Player() { Position = new Vector2(15, 10), Raduis = 0.25f };
            Diamant diamant = new Diamant() { Position = new Vector2(10, 10), Raduis = 0.25f };

            area.Items.Add(Player);
            area.Items.Add(diamant);

            World.Areas.Add(area);
        }
    }
}
