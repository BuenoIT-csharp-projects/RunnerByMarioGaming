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
    internal class KoopaTroopa
    {
	    //Koopa Troopa Iddle Sprite
        public int _koopaTroopa_sprite_X = 215;
        public int _koopaTroopa_sprite_Y = 82;
        public int _koopaTroopa_sprite_width = 43;
        public int _koopaTroopa_sprite_height = 53;

        //Koopa Troopa Running Sprite_1
        public int _koopaTroopa_running_1_sprite_X = 53;
        public int _koopaTroopa_running_1_sprite_Y = 7;
        public int _koopaTroopa_running_1_sprite_width = 40;
        public int _koopaTroopa_running_1_sprite_height = 52;

        //Koopa Troopa Running Sprite_2
        public int _koopaTroopa_running_2_sprite_X = 267;
        public int _koopaTroopa_running_2_sprite_Y = 81;
        public int _koopaTroopa_running_2_sprite_width = 43;
        public int _koopaTroopa_running_2_sprite_height = 53;


        //Jump variables declaration and initialization
        Vector2 position = new Vector2(800, 290); //Initial Position Koopa Troopa
        Vector2 velocity;

        int counter = 1;

        public SpriteDimensions KoopaTroopaSprite { get; set; }
        public string KoopaTroopaStatus { get; set; }
        public Vector2 KoopaTroopaPosition { get; set; }
        public Rectangle KoopaTroopaRectangle { get; set; }

        public KoopaTroopa(Texture2D koopaTroopaSprite, Vector2 koopaTroopaPosition)
        {
            KoopaTroopaSprite = new SpriteDimensions(koopaTroopaSprite, _koopaTroopa_sprite_X, _koopaTroopa_sprite_Y, _koopaTroopa_sprite_width, _koopaTroopa_sprite_height);
            position = koopaTroopaPosition;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (KoopaTroopaStatus == "attack")
            {
                KoopaTroopaSprite.Draw(spriteBatch, position);

                if (counter >= 30)
                {
                    counter = 1;
                }
                else if (counter >= 20)
                {
                    KoopaTroopaSprite.PointX = _koopaTroopa_running_1_sprite_X;
                    KoopaTroopaSprite.PointY = _koopaTroopa_running_1_sprite_Y;
                    KoopaTroopaSprite.Width = _koopaTroopa_running_1_sprite_X;
                    KoopaTroopaSprite.Height = _koopaTroopa_running_1_sprite_height;
                }
                else if (counter >= 10 && counter < 20)
                {
                    KoopaTroopaSprite.PointX = _koopaTroopa_sprite_X;
                    KoopaTroopaSprite.PointY = _koopaTroopa_sprite_Y;
                    KoopaTroopaSprite.Width = _koopaTroopa_sprite_width;
                    KoopaTroopaSprite.Height = _koopaTroopa_sprite_height;
                }
                else if (counter < 10)
                {
                    KoopaTroopaSprite.PointX = _koopaTroopa_running_2_sprite_X;
                    KoopaTroopaSprite.PointY = _koopaTroopa_running_2_sprite_Y;
                    KoopaTroopaSprite.Width = _koopaTroopa_running_2_sprite_width;
                    KoopaTroopaSprite.Height = _koopaTroopa_running_2_sprite_height;
                }
                counter++;
            }
                            
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) || KoopaTroopaStatus == "attack")
            {
                Attack();
            }
        }

        public void Attack()
        {
            KoopaTroopaStatus = "attack";
            // Koopa Troopa Moviment Rules
            position += velocity;
            position.X -= 2f;
            velocity.X = -0.2f;


        }

        public void Stop()
        {
            KoopaTroopaStatus = "notActive";
        }
    }
}
