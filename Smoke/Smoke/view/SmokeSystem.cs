using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Smoke.view
{
    class SmokeSystem
    {
        //public Smoke[] particle;    // in an array
        public List<Smoke> particle = new List<Smoke>();
        Random rand = new Random();
        Smoke smokeObject;
        public int Maxparticle = 700;
        Texture2D SMOKE;
        public float smokeLife = 3;
        //public int particlelife = 3;



        public SmokeSystem(Texture2D smoke)
        {
            SMOKE = smoke;
            smokeObject = new Smoke(smoke, rand);
        }

        public void MakeSmoke(Texture2D smoke)
        {
            if (particle.Count < Maxparticle)
            {
                Smoke newsmoke = new Smoke(smoke, rand);
                particle.Add(newsmoke);
            }
        }
        public void Draw(Texture2D smokeTexture, SpriteBatch spriteBatch, Camera camera)
        {
            foreach (Smoke s in particle)
            {
                s.Draw(smokeTexture, spriteBatch, camera);
            }
        }
        public void Update(float TimeDuration)
        {
            foreach (Smoke s in particle)
            {
                s.Update(TimeDuration);
                if (s.TimeEnd())
                {
                    s.SmokeFade(TimeDuration);
                }

            }
        }
    }
}

