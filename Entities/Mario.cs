using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RunnerByMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerByMarioGame.Entities
{
    internal class Mario : IMarioRunnerEntity
    {
        public int _mario_sprite_X = 12;
        public int _mario_sprite_Y = 18;
        public int _mario_sprite_width = 72;
        public int _mario_sprite_height = 96;
        Vector2 position = new Vector2(1, 250); //Initial Position Mario
        Vector2 velocity;

        public SpriteDimensions MarioSprite { get; set; }
        public Vector2 MarioPosition { get; set; }
        public MarioState MarioState { get; set; }
        public bool isActive { get; set; }
        public float SpeedMoviment { get; set; }
        public int DrawPriority { get; set; }
        

        public Mario(Texture2D marioSprite, Vector2 marioPosition)
        {
            MarioSprite = new SpriteDimensions(marioSprite, _mario_sprite_X, _mario_sprite_Y, _mario_sprite_width, _mario_sprite_height);
            MarioPosition = marioPosition;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (MarioState == MarioState.Idle)
            {
                MarioSprite.Draw(spriteBatch, MarioPosition);
            }
            else if (MarioState == MarioState.JumpingUp)
            {
                MarioSprite.Draw(spriteBatch, MarioPosition);
            }
           
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && MarioState != MarioState.JumpingUp)
            {
                position.Y -= 10f;
                velocity.Y = -7f;
                MarioState = MarioState.JumpingUp;
            }

            if (MarioState == MarioState.JumpingUp)
            {
                velocity.Y += 0.15f;
            }

            if (position.Y + MarioSprite.Height >= 350)
            {
                MarioState = MarioState.Idle;
            }

            if (MarioState == MarioState.Idle)
            {
                velocity.Y = 0f;
            }

            MarioPosition = position;


        }

        public bool Jump()
        {
            if (MarioState == MarioState.JumpingUp || MarioState == MarioState.FallingDown)
            {
                return false;
            }
            return true;
        }
    }
}
