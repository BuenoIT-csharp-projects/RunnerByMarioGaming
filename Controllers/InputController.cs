using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RunnerByMarioGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerByMarioGame.Controllers
{
    internal class InputController
    {
        private Mario _mario;
        private KeyboardState _keyboard;

        public InputController(Mario mario)
        {
            _mario = mario;
        }

        public void Controllers(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (!_keyboard.IsKeyDown(Keys.Up) && keyboardState.IsKeyDown(Keys.Up))
            {
                _mario.Jump();
            }
            
            _keyboard= keyboardState;

        }
    }
}
