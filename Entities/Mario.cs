using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public const int _mario_sprite_X = 12;
        public const int _mario_sprite_Y = 18;
        public const int _mario_sprite_width = 72;
        public const int _mario_sprite_height = 96;


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
            MarioSprite.Draw(spriteBatch, MarioPosition);
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
