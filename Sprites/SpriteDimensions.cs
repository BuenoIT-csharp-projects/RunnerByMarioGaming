using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerByMarioGame.Sprites
{
    //Reusable SpriteDimensions class to classify and draw sprites in different sizes
    public class SpriteDimensions
    {
        public SpriteDimensions(Texture2D textureSprite, int pointX, int pointY, int width, int height)
        {
            TextureSprite = textureSprite;
            PointX = pointX;
            PointY = pointY;
            Width = width;
            Height = height;
        }

        public Texture2D TextureSprite { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; } = Color.White;

        public void Draw (SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(TextureSprite, position, new Rectangle(PointX, PointY, Width, Height), Color);
        }

    }
}
