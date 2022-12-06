using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerByMarioGame.Sprites
{
    internal class SpriteAnimationManager
    {
        private SpriteAnimation _animation;
        private float _timer;
        public SpriteAnimationManager(SpriteAnimation animation)
        {
            _animation = animation;
        }
        public void Start(SpriteAnimation spriteAnimation)
        {
            if (_animation == spriteAnimation)
            {
                return;
            }
            _animation = spriteAnimation;
            _animation.CurrentFrame = 0;
            _timer = 0;
        }

        public void Stop()
        {
            _timer= 0;

            _animation.CurrentFrame= 0;
        }

        public void Update(GameTime gameTime) {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;

                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                {
                    _animation.CurrentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteDimensions spriteDimensions)
        {
            spriteBatch.Draw(spriteDimensions.TextureSprite,new Rectangle(spriteDimensions.PointX, spriteDimensions.PointY, spriteDimensions.Width, spriteDimensions.Height), Color.White);
        }
    }
}
