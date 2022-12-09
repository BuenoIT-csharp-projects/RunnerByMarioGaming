using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RunnerByMarioGame.Background;
using RunnerByMarioGame.Entities;
using RunnerByMarioGame.Sprites;
using System;
using System.Collections.Generic;

namespace RunnerByMarioGame
{
    public class MarioRunner : Game
    {
        //Random Initialization
        Random random = new Random();

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

        //List of Goombas declaration
        List<Goomba> goombas = new List<Goomba>();

        //Screen size declarations and initialization
        public const int screen_width = 1000;
        public const int screen_height = 400;

        //Background scrolling declaration
        private Scrolling _scrolling1;
        private Scrolling _scrolling2;

        //Font declaration
        private SpriteFont _font;

        //Game session declaration
        private double _timer;
        private int _score;
        private double _timeLap;

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

            //Time lap zero
            _timeLap = 0;

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Background movement
            _scrolling1 = new Scrolling(Content.Load<Texture2D>("background"), new Rectangle(0, -300, 1280, 720));
            _scrolling2 = new Scrolling(Content.Load<Texture2D>("background"), new Rectangle(1280, -300, 1280, 720));

            //Font
            _font = Content.Load<SpriteFont>("Fonts");

            //Load Mario Sprite to the Game
            _spriteMario = Content.Load<Texture2D>(mario_asset_img);
            _mario = new Mario(_spriteMario, new Vector2(1, 250)); //Hard code initialization position of Mario to the game
            
            //Load Goomba Sprite to the Game
            _spriteGoomba = Content.Load<Texture2D>(goomba_no_bg);
            //_goomba = new Goomba(_spriteGoomba, new Vector2(1100, 290));

            //Load Goombas created to the game
            var rndNumberOfGoombas = random.Next(8, 20); //Random number of Goombas to be created in the game
            for (int i = 0; i < rndNumberOfGoombas; i++)
            {
                goombas.Add(new Goomba(_spriteGoomba, new Vector2(random.Next(900, 10000), 300)));
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            //Increase time
            _timer += gameTime.ElapsedGameTime.TotalSeconds;
            
            if (_timer - _timeLap >= 3)
            {
	            _timeLap = _timer;
	            _score += 10;
            }
            

            //Background Image position update
            if (_scrolling1.rectangle.X + 1280 <= 0)
            {
	            _scrolling1.rectangle.X = _scrolling2.rectangle.X + 1280;
            }
            if (_scrolling2.rectangle.X + 1280 <= 0)
            {
	            _scrolling2.rectangle.X = _scrolling1.rectangle.X + 1280;
            }

            _scrolling1.Update();
            _scrolling2.Update();

            //Characters Update
            _mario.Update(gameTime);
            for (int i = 0; i < goombas.Count; i++)
            {
                goombas[i].Update(gameTime);
            }
            //_goomba.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            //Background draw
            _scrolling1.Draw(_spriteBatch);
            _scrolling2.Draw(_spriteBatch);

            //Character Draw
            _mario.Draw(_spriteBatch, gameTime);

            for (int i = 0; i < goombas.Count; i++)
            {
                goombas[i].Draw(_spriteBatch, gameTime);
            }
            //_goomba.Draw(_spriteBatch, gameTime);

            //Font draw
            _spriteBatch.DrawString(_font, $"Time: {Math.Round(_timer,0)}", new Vector2(5, 10), Color.Red);
            _spriteBatch.DrawString(_font, $"Score:  {_score}", new Vector2(5,50),Color.Red);
            _spriteBatch.DrawString(_font, $"Level", new Vector2(5,100),Color.White);

            //End
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}