using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartikelEffect
{
    class Camera
    {
        private float sizeofthefield = 500;
        private int bordersize = 64;
        private float scaleX;
            private float scaleY;
        public float scale =1;
        
        
        public void ScaleEverything(Viewport viewport)
        {
            scaleX = viewport.Width;
            scaleY = viewport.Height;

            if (scaleX < scaleY)
            {
                scale = scaleX;
            }
            else if (scaleX > scaleY)
            {
                scale = scaleY;
            }

            scaleX = scale - bordersize * 2;
            scaleY = scale - bordersize * 2;
        }

        public Vector2 VisualCoordination(float x, float y)
        {
            float visualX = x * scaleX + bordersize *2;
            float visualY = y * scaleY + bordersize *2;

            return new Vector2(visualX, visualY);
        }

            public float ScaleObject(SplitterParticle particle)   // scale 10% of the screeen size
        {
            scale = sizeofthefield / particle.nowsprites.Width;
            return scale;
        }


    }
    }

  

