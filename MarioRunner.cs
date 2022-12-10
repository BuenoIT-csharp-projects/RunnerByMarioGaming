﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        Rectangle marioRectangle = new Rectangle();

        //Goomba Sprite Add To Variables
        private const string goomba_no_bg = "goomba-no-bg";
        private Texture2D _spriteGoomba;

        //List of Goombas declaration
        List<Goomba> goombas = new List<Goomba>();

        //Boo Sprite Add To Variables
        private const string boo_no_bg = "boo-sprite";
        private Texture2D _spriteBoo;

        //List of Boo declaration
        List<Boo> boos = new List<Boo>();

        //KoopaTroopa Sprite Add To Variables
        private const string koopa_troopa_no_bg = "koopa-troopa";
        private Texture2D _spriteKoopaTroopa;

        //List of Boo declaration
        List<KoopaTroopa> koopaTroopas = new List<KoopaTroopa>();

        //Screen size declarations and initialization
        public const int screen_width = 1000;
        public const int screen_height = 400;

        //Background scrolling declaration
        private Scrolling _scrolling1;
        private Scrolling _scrolling2;

        int counter;

        //Messages variables
        bool isOver = false;
        bool isStarted = false;

        //Font declaration
        private SpriteFont _font;

        //Game session declaration
        private double _timer;
        private int _score;
        private double _timeLap;

        //Sound declaration
        private Song _gameSound;

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
	        //Sound
	        _gameSound = Content.Load<Song>("RunningAbout");
	        //Play sound
	        MediaPlayer.Play(_gameSound);

            //Load Sprite batch
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

            //Load Goombas created to the game
            var rndNumberOfGoombas = random.Next(5, 10); //Random number of Goombas to be created in the game
            for (int i = 0; i < rndNumberOfGoombas; i++)
            {
                goombas.Add(new Goomba(_spriteGoomba, new Vector2(random.Next(0, 8000), 300)));
            }

            //Load Boos Sprite to the Game
            _spriteBoo = Content.Load<Texture2D>(boo_no_bg);

            //Load Boos created to the game
            var rndNumberOfBoos = random.Next(5, 10); //Random number of Boos to be created in the game
            for (int i = 0; i < rndNumberOfBoos; i++)
            {
                boos.Add(new Boo(_spriteBoo, new Vector2(random.Next(9000, 16000), random.Next(220, 250))));
            }

            //Load Koopa Troopas Sprite to the Game
            _spriteKoopaTroopa = Content.Load<Texture2D>(koopa_troopa_no_bg);

            //Load Koopa Troopas created to the game
            var rndNumberOfKoopaTroopas = random.Next(5, 10); //Random number of  Koopa Troopas  to be created in the game
            for (int i = 0; i < rndNumberOfKoopaTroopas; i++)
            {
                koopaTroopas.Add(new KoopaTroopa(_spriteKoopaTroopa, new Vector2(random.Next(17000, 25000), 290)));
            }


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Increase time
            if (_mario.MarioState != MarioState.NotActive && _mario.MarioState != MarioState.Idle)
            {
                _timer += gameTime.ElapsedGameTime.TotalSeconds;

                if (_timer - _timeLap >= 3)
                {
                    _timeLap = _timer;
                    _score += 10;
                }
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

            if (_mario.MarioState != MarioState.NotActive && _mario.MarioState != MarioState.Idle)
            {
                isStarted = true;
                _scrolling1.Update();
                _scrolling2.Update();
            }


            //Characters Update
            _mario.Update(gameTime);
            for (int i = 0; i < goombas.Count; i++)
            {
                if (goombas[i].GoombaStatus == "notActive")
                {
                    return;
                }
                else if (_mario.MarioState == MarioState.NotActive)
                {
                    return;
                }
                else
                {
                  
                    goombas[i].Update(gameTime);
                }
            }

            for (int i = 0; i < boos.Count; i++)
            {
                if (boos[i].BooStatus == "notActive")
                {
                    return;
                }
                else if (_mario.MarioState == MarioState.NotActive)
                {
                    return;
                }
                else
                {      
                    boos[i].Update(gameTime);
                }
            }

            for (int i = 0; i < koopaTroopas.Count; i++)
            {
                if (koopaTroopas[i].KoopaTroopaStatus == "notActive")
                {
                    return;
                }
                else if (_mario.MarioState == MarioState.NotActive)
                {
                    return;
                }
                else
                {     
                    koopaTroopas[i].Update(gameTime);
                }
            }


            //Collision Dectection Update
            marioRectangle = new Rectangle((int)_mario.MarioPosition.X, (int)_mario.MarioPosition.Y, _mario.MarioSprite.Width, _mario.MarioSprite.Height);
            for (int i = 0; i < goombas.Count; i++)
            {
                goombas[i].GoombaRectangle = new Rectangle((int)goombas[i].GoombaPosition.X, (int)goombas[i].GoombaPosition.Y, goombas[i].GoombaSprite.Width, goombas[i].GoombaSprite.Height);
            }

            for (int i = 0; i < goombas.Count; i++)
            {
                if (goombas[i].GoombaRectangle.Intersects(marioRectangle))
                {
                    goombas.Remove(goombas[i]);
                    _mario.MarioState = MarioState.NotActive;
                    isOver = true;
                }
            }

            for (int i = 0; i < boos.Count; i++)
            {
                boos[i].BooRectangle = new Rectangle((int)boos[i].BooPosition.X, (int)boos[i].BooPosition.Y, boos[i].BooSprite.Width, boos[i].BooSprite.Height);
            }

            for (int i = 0; i < boos.Count; i++)
            {
                if (boos[i].BooRectangle.Intersects(marioRectangle))
                {
                    boos.Remove(boos[i]);
                    _mario.MarioState = MarioState.NotActive;
                    isOver = true;
                }
            }

            for (int i = 0; i < koopaTroopas.Count; i++)
            {
                koopaTroopas[i].KoopaTroopaRectangle = new Rectangle((int)koopaTroopas[i].KoopaTroopaPosition.X, (int)koopaTroopas[i].KoopaTroopaPosition.Y, koopaTroopas[i].KoopaTroopaSprite.Width, koopaTroopas[i].KoopaTroopaSprite.Height);
            }

            for (int i = 0; i < koopaTroopas.Count; i++)
            {
                if (koopaTroopas[i].KoopaTroopaRectangle.Intersects(marioRectangle))
                {
                    koopaTroopas.Remove(koopaTroopas[i]);
                    _mario.MarioState = MarioState.NotActive;
                    isOver = true;
                }
            }


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

            if (!isStarted)
            {
                _spriteBatch.DrawString(_font, $"Press Space to Start the Game", new Vector2(350, 200), Color.Black);      
            }

            for (int i = 0; i < goombas.Count; i++)
            {
                goombas[i].Draw(_spriteBatch, gameTime);
            }

            for (int i = 0; i < boos.Count; i++)
            {
                boos[i].Draw(_spriteBatch, gameTime);
            }

            for (int i = 0; i < koopaTroopas.Count; i++)
            {
                koopaTroopas[i].Draw(_spriteBatch, gameTime);
            }



            //Font draw
            _spriteBatch.DrawString(_font, $"Time: {Math.Round(_timer,0)}", new Vector2(5, 10), Color.Red);
            _spriteBatch.DrawString(_font, $"Score:  {_score}", new Vector2(5,50),Color.Red);
            _spriteBatch.DrawString(_font, $"Level {counter}", new Vector2(5,100),Color.White);

            if (isOver)
            {
                _spriteBatch.DrawString(_font, $"End Game", new Vector2(450, 200), Color.Black);
            }

            //End
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}