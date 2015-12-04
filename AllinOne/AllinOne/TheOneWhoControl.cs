using AllinOne._2dExplosion;
using AllinOne.Smoke;
using AllinOne.Splitter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllinOne
{
    class TheOneWhoControl
    {

        Texture2D Smoke;
        Texture2D Spark;
        Texture2D Explosion;
        private float seperateTime;

        private SmokeSystem _smokesystem;
        private SplitterSystem _splittersystem;
        private flame Flame;

        int flameCount = 0;
        //private SplitterParticle s_splitterParticle;  // vetej

        Camera camera;

        SpriteBatch spriteBatch;


        public TheOneWhoControl(ContentManager Content, SpriteBatch spriteBatch, Camera camera)
        {
            Smoke = Content.Load<Texture2D>("particlesmokee.png");
            Spark = Content.Load<Texture2D>("spark.png");
            Explosion = Content.Load<Texture2D>("explosion.png");

            _smokesystem = new SmokeSystem(Smoke);
            _splittersystem = new SplitterSystem(Spark);
            Flame = new flame(Explosion);

            this.spriteBatch = spriteBatch;
            this.camera = camera;

        }
        public void Updateeverything(float gameTime)
        {
           

            float timeElapsedSeconds = gameTime;
            Flame.Update(timeElapsedSeconds);
            _splittersystem.Update(timeElapsedSeconds);
            _smokesystem.Update(timeElapsedSeconds);

            seperateTime += gameTime;

            if (seperateTime >= _smokesystem.smokeLife / _smokesystem.Maxparticle)
            {
               _smokesystem.MakeSmoke(Smoke);
                seperateTime = 0;
            }
        }

        public void DrawEverything()
        {
            flameCount++;
            this.spriteBatch.Begin();

            if (flameCount < 24)
            {
                Flame.Draw(this.spriteBatch, this.camera);
            }
            
            _splittersystem.Draw(Spark, this.camera, this.spriteBatch);
            _smokesystem.Draw(Smoke, this.spriteBatch, this.camera);
            

            this.spriteBatch.End();
        }

    }
}
