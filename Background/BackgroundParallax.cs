/*
 *  Class ID: BackgroundParallax
 *  Purpose: To create moving background
 *
 *  Revision history
 *      Dohee Hur, 2022.12.10: Created and implemented
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RunnerByMarioGame.Background
{
	public partial class ScrollingBackground
	{
		public Texture2D texture;
		public Rectangle rectangle;

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, rectangle, Color.White);
		}
	}

	class Scrolling : ScrollingBackground
	{
		public Scrolling(Texture2D newTexture, Rectangle newRectangle)
		{
			texture = newTexture;
			rectangle = newRectangle;
		}

		public void Update()
		{
			rectangle.X -= 2;
		}
	}
}
