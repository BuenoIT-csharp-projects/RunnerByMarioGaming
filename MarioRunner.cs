using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RunnerByMarioGame.Entities;
using RunnerByMarioGame.Sprites;

namespace RunnerByMarioGame
{
    public class MarioRunner : Game
    {
        //Mario Sprite Add To Variables
        private const string mario_asset_img = "mario-sprite-no-bg";
        private Texture2D _spriteMario;

        //Mario object declaration
        private Mario _mario;

        //Goomba object declaration
        private Goomba _goomba;

        //Goomba Sprite Add To Variables
        private const string goomba_no_bg = "goomba-no-bg";
        private Texture2D _spriteGoomba;

        //Screen size declarations and initialization
        public const int screen_width = 1000;
        public const int screen_height = 400;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public MarioRunner()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            //Apply screen size to the game
            _graphics.PreferredBackBufferWidth= screen_width;
            _graphics.PreferredBackBufferHeight= screen_height;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load Mario Sprite to the Game
            _spriteMario = Content.Load<Texture2D>(mario_asset_img);
            _mario = new Mario(_spriteMario, new Vector2(1, 250)); //Hard code initialization position of Mario to the game
            
            //Load Goomba Sprite to the Game
            _spriteGoomba = Content.Load<Texture2D>(goomba_no_bg);
            _goomba = new Goomba(_spriteGoomba, new Vector2(800, 290));
        
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _mario.Update(gameTime);
            _goomba.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            _mario.Draw(_spriteBatch, gameTime);
            _goomba.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}