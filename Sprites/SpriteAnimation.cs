using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerByMarioGame.Sprites
{
    internal class SpriteAnimation
    {
        public int CurrentFrame { get; set; }
        public int FrameCount { get; set; }
        public SpriteDimensions SpriteDimensions { get; set; }
        public float FrameSpeed { get; set; }
        public bool isLooping { get; set; }

        public SpriteAnimation(SpriteDimensions spriteDimensions, int frameCount) {
            SpriteDimensions = spriteDimensions;
            FrameCount = frameCount;
            isLooping= true;
            FrameSpeed= 0.2f;
        }

    }
}
