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
        
        //Mario Iddle Sprite
        public int _mario_sprite_X = 12;
        public int _mario_sprite_Y = 18;
        public int _mario_sprite_width = 72;
        public int _mario_sprite_height = 96;

        //Mario Jump Sprite
        public int _mario_jump_sprite_X = 450;
        public int _mario_jump_sprite_Y = 18;
        public int _mario_jump_sprite_width = 96;
        public int _mario_jump_sprite_height = 96;

        //Mario Running Sprite_1
        public int _mario_running_1_sprite_X = 294;
        public int _mario_running_1_sprite_Y = 18;
        public int _mario_running_1_sprite_width = 72;
        public int _mario_running_1_sprite_height = 96;

        //Mario Running Sprite_2
        public int _mario_running_2_sprite_X = 186;
        public int _mario_running_2_sprite_Y = 18;
        public int _mario_running_2_sprite_width = 96;
        public int _mario_running_2_sprite_height = 96;


        //Jump variables declaration and initialization
        Vector2 position = new Vector2(1, 250); //Initial Position Mario
        Vector2 velocity;

        int counter = 1;

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
                MarioSprite.PointX = _mario_sprite_X;
                MarioSprite.PointY= _mario_sprite_Y;
                MarioSprite.Width= _mario_sprite_width;
                MarioSprite.Height= _mario_sprite_height;
                MarioSprite.Draw(spriteBatch, MarioPosition);
            }
            else if (MarioState == MarioState.JumpingUp)
            {
                MarioSprite.PointX = _mario_jump_sprite_X;
                MarioSprite.PointY = _mario_jump_sprite_Y;
                MarioSprite.Width = _mario_jump_sprite_width;
                MarioSprite.Height = _mario_jump_sprite_height;

                MarioSprite.Draw(spriteBatch, MarioPosition);
            }
            else if (MarioState == MarioState.Running)
            {
                if (counter > 30)
                {
                    counter = 1;
                }
                else if (counter >= 20)
                {
                    MarioSprite.PointX = _mario_running_1_sprite_X;
                    MarioSprite.PointY = _mario_running_1_sprite_Y;
                    MarioSprite.Width = _mario_running_1_sprite_width;
                    MarioSprite.Height = _mario_running_1_sprite_height;

                    MarioSprite.Draw(spriteBatch, MarioPosition);
                }
                else if (counter >= 10 && counter < 20)
                {
                    MarioSprite.PointX = _mario_sprite_X;
                    MarioSprite.PointY = _mario_sprite_Y;
                    MarioSprite.Width = _mario_sprite_width;
                    MarioSprite.Height = _mario_sprite_height;
                    MarioSprite.Draw(spriteBatch, MarioPosition);
                }
                else if (counter < 10)
                {
                    MarioSprite.PointX = _mario_running_2_sprite_X;
                    MarioSprite.PointY = _mario_running_2_sprite_Y;
                    MarioSprite.Width = _mario_running_2_sprite_width;
                    MarioSprite.Height = _mario_running_2_sprite_height;

                    MarioSprite.Draw(spriteBatch, MarioPosition);
                }
                counter++;
            }
        }

        public void Update(GameTime gameTime)
        {
            Jump();

        }

        public void Jump()
        {
            // Jumping Rules
            position += velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && MarioState != MarioState.JumpingUp)
            {
                position.Y -= 10f;
                velocity.Y = -8f;
                MarioState = MarioState.JumpingUp;
            }

            if (MarioState == MarioState.JumpingUp)
            {
                velocity.Y += 0.15f;
            }

            if (position.Y + MarioSprite.Height >= 350)
            {
                MarioState = MarioState.Running;
            }

            if (MarioState == MarioState.Running)
            {
                velocity.Y = 0f;
            }

            MarioPosition = position;
        }
        public void Stop()
        {
            MarioState = MarioState.NotActive;
        }

    }
}
