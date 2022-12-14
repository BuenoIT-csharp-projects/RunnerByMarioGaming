/*
 *  Class ID: Goomba
 *  Purpose: To create a Goomba enemy 
 *
 *  Revision history
 *      Guilherme Bueno, 2022.12.10: Created and implemented
 */

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using RunnerByMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RunnerByMarioGame.Entities
{
    internal class Goomba
    {
	    //Goomba Iddle Sprite
        public int _goomba_sprite_X = 215;
        public int _goomba_sprite_Y = 82;
        public int _goomba_sprite_width = 43;
        public int _goomba_sprite_height = 53;

        //Goomba Running Sprite_1
        public int _goomba_running_1_sprite_X = 53;
        public int _goomba_running_1_sprite_Y = 7;
        public int _goomba_running_1_sprite_width = 40;
        public int _goomba_running_1_sprite_height = 52;

        //Goomba Running Sprite_2
        public int _goomba_running_2_sprite_X = 267;
        public int _goomba_running_2_sprite_Y = 81;
        public int _goomba_running_2_sprite_width = 43;
        public int _goomba_running_2_sprite_height = 53;


        //Jump variables declaration and initialization
        Vector2 position = new Vector2(800, 290); //Initial Position Goomba
        Vector2 velocity;

        int counter = 1;

        public SpriteDimensions GoombaSprite { get; set; }
        //public Vector2 GoombaPosition { get; set; }
        public string GoombaStatus { get; set; }
        public Vector2 GoombaPosition { get; set; }
        public Rectangle GoombaRectangle { get; set; }

        public Goomba(Texture2D goombaSprite, Vector2 goombaPosition)
        {
            GoombaSprite = new SpriteDimensions(goombaSprite, _goomba_sprite_X, _goomba_sprite_Y, _goomba_sprite_width, _goomba_sprite_height);
            position = goombaPosition;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (GoombaStatus == "attack")
            {
                GoombaSprite.Draw(spriteBatch, position);

                if (counter >= 30)
                {
                    counter = 1;
                }
                else if (counter >= 20)
                {
                    GoombaSprite.PointX = _goomba_running_1_sprite_X;
                    GoombaSprite.PointY = _goomba_running_1_sprite_Y;
                    GoombaSprite.Width = _goomba_running_1_sprite_X;
                    GoombaSprite.Height = _goomba_running_1_sprite_height;
                }
                else if (counter >= 10 && counter < 20)
                {
                    GoombaSprite.PointX = _goomba_sprite_X;
                    GoombaSprite.PointY = _goomba_sprite_Y;
                    GoombaSprite.Width = _goomba_sprite_width;
                    GoombaSprite.Height = _goomba_sprite_height;
                }
                else if (counter < 10)
                {
                    GoombaSprite.PointX = _goomba_running_2_sprite_X;
                    GoombaSprite.PointY = _goomba_running_2_sprite_Y;
                    GoombaSprite.Width = _goomba_running_2_sprite_width;
                    GoombaSprite.Height = _goomba_running_2_sprite_height;
                }
                counter++;
            }
                            
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) || GoombaStatus == "attack")
            {
                Attack();
            }
            //Update position
            GoombaPosition = position;
        }

        public void Attack()
        {
            GoombaStatus = "attack";
            // Goomba Moviment Rules
            position += velocity;
            position.X -= 2f;
            velocity.X = -0.2f;


        }

        public void Stop()
        {
            GoombaStatus = "notActive";
        }
    }
}
