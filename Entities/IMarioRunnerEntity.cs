using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerByMarioGame.Entities
{
    internal interface IMarioRunnerEntity
    {
        public int DrawPriority { get; }

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
