﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PartikelEffect
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D spark;
        Camera camera;
        SplitterSystem splittersystem;
        public float time;
       
       
            public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            camera = new Camera();
            graphics.PreferredBackBufferHeight = 660;
            graphics.PreferredBackBufferWidth = 660;

            graphics.ApplyChanges();
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spark = Content.Load<Texture2D>("spark.png");
            camera.ScaleEverything(graphics.GraphicsDevice.Viewport);
           splittersystem = new SplitterSystem(spark);
            


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // convert form double to float
            // TODO: Add your update logic here
            // updatera tiden från update 
           
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                float elapsedTimeSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
                time += elapsedTimeSeconds;
                if (time >= 3)
                {

                    //splittersystem = new SplitterSystem(spark);
                    time = 0;
                }

                if(Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    splittersystem = new SplitterSystem(spark);    // complementing * forgot to put a manual explosion
                    
                }
            }
            
            

            //foreach (SplitterParticle splitter in splittersystem.particles)
            //{
               // splittersystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            //}



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            splittersystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            splittersystem.Draw(spark, camera, spriteBatch); 
            /*spriteBatch.Begin();

            1  foreach (SplitterParticle spark in splittersystem.particles)
              {
                  float scale = camera.ScaleObject(spark);
                 spriteBatch.Draw(spark.nowsprites, camera.VisualCoordination(0,1), null, Color.White, 0, spark.randomDirection,scale , SpriteEffects.None, 0); // behövs uppdatera bilden eller snarare rendera ut

                  // TODO: Add your drawing code here
                  // kanske ska skriva ut positionerna
                  //rendera ut visual koordination
                  // vid update ska jag försöka loopa igenom array index i particle system
                  // update ska rendera ut bilden för varje particle.

              }
              spriteBatch.End();*/

            base.Draw(gameTime);
        }
    }
}
