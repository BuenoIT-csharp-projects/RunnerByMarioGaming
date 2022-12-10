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
    internal class Boo
    {
        //Random random = new Random();
        //double timer;
        //double remainingTimer = 10;

        //Boo Iddle Sprite
        public int _boo_sprite_X = 1;
        public int _boo_sprite_Y = 0;
        public int _boo_sprite_width = 37;
        public int _boo_sprite_height = 38;

        //Boo Running Sprite_1
        public int _boo_running_1_sprite_X = 47;
        public int _boo_running_1_sprite_Y = 0;
        public int _boo_running_1_sprite_width = 37;
        public int _boo_running_1_sprite_height = 38;

        //Boo Running Sprite_2
        public int _boo_running_2_sprite_X = 93;
        public int _boo_running_2_sprite_Y = 0;
        public int _boo_running_2_sprite_width = 37;
        public int _boo_running_2_sprite_height = 38;


        //Jump variables declaration and initialization
        Vector2 position = new Vector2(800, 290); //Initial Position Goomba
        Vector2 velocity;

        int counter = 1;

        public SpriteDimensions BooSprite { get; set; }
        //public Vector2 GoombaPosition { get; set; }
        public string BooStatus { get; set; }
        public Vector2 BooPosition { get; set; }
        public Rectangle BooRectangle { get; set; }

        public Boo(Texture2D booSprite, Vector2 booPosition)
        {
            BooSprite = new SpriteDimensions(booSprite, _boo_sprite_X, _boo_sprite_Y, _boo_sprite_width, _boo_sprite_height);
            position = booPosition;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (BooStatus == "attack")
            {
                BooSprite.Draw(spriteBatch, position);

                if (counter >= 30)
                {
                    counter = 1;
                }
                else if (counter >= 20)
                {
                    BooSprite.PointX = _boo_running_1_sprite_X;
                    BooSprite.PointY = _boo_running_1_sprite_Y;
                    BooSprite.Width = _boo_running_1_sprite_X;
                    BooSprite.Height = _boo_running_1_sprite_height;
                }
                else if (counter >= 10 && counter < 20)
                {
                    BooSprite.PointX = _boo_sprite_X;
                    BooSprite.PointY = _boo_sprite_Y;
                    BooSprite.Width = _boo_sprite_width;
                    BooSprite.Height = _boo_sprite_height;
                }
                else if (counter < 10)
                {
                    BooSprite.PointX = _boo_running_2_sprite_X;
                    BooSprite.PointY = _boo_running_2_sprite_Y;
                    BooSprite.Width = _boo_running_2_sprite_width;
                    BooSprite.Height = _boo_running_2_sprite_height;
                }
                counter++;
            }
                            
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) || BooStatus == "attack")
            {
                Attack();
            }
            //Update position
            BooPosition = position;
        }

        public void Attack()
        {
            BooStatus = "attack";
            // Goomba Moviment Rules
            position += velocity;
            position.X -= 2f;
            velocity.X = -0.2f;


        }

        public void Stop()
        {
            BooStatus = "notActive";
        }
    }
}
