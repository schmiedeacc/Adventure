﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    internal class InputComponent : GameComponent
    {
        private readonly Adventure game;

        public Vector2 Movement { get; private set; }

        public InputComponent(Adventure game) : base (game)
        {
            this.game = game;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 movement = Vector2.Zero;

            //Gamepad Steuerung
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            movement += gamePad.ThumbSticks.Left * new Vector2(1f,-1f);

            //Tastatur Steuerung
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Left))
                movement += new Vector2(-1f, 0f);
            if (keyboard.IsKeyDown(Keys.Right))
                movement += new Vector2(1f, 0f);
            if (keyboard.IsKeyDown(Keys.Up))
                movement += new Vector2(0f, -1f);
            if (keyboard.IsKeyDown(Keys.Down))
                movement += new Vector2(0f, 1f);
            if (keyboard.IsKeyDown(Keys.Escape))
                game.Exit();

            if (movement.Length() > 1f)
                movement.Normalize();

            Movement = movement;


            base.Update(gameTime);
        }
    }
}
