using Adventure.Model;
using Microsoft.Xna.Framework;
using System.Linq;
using System;
using System.Collections.Generic;
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

            Area area = new Area(2, 30, 20);
            World.Areas.Add(area);

            for (int x = 0; x < area.Width; x++)
            {
                for (int y = 0; y < area.Height; y++)
                {
                    area.Layers[0].Tiles[x, y] = new Tile();
                    area.Layers[1].Tiles[x, y] = new Tile();

                    if (x == 0 || y == 0 || x == area.Width - 1 || y == area.Height - 1)
                        area.Layers[0].Tiles[x, y].Blocked = true;
                }
            }

            Player = new Player() { Position = new Vector2(15, 10), Raduis = 0.25f };
            area.Items.Add(Player);

            Diamant diamant = new Diamant() { Position = new Vector2(10, 10), Raduis = 0.25f };            
            area.Items.Add(diamant);

        }

        public override void Update(GameTime gameTime)
        {
            #region Player Input

            Player.Velocity = game.Input.Movement * 10f;

            #endregion


            #region Character Movement

            foreach (var area in World.Areas)
            {
                foreach(var character in area.Items.OfType<Character>())
                {
                    character.Position += character.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            #endregion

            base.Update(gameTime);
        }
    }
}
