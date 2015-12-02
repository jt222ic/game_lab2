using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke.view
{
    class Camera
    { 
    
        private float sizeofthefield;
        private int bordersize = 64;
        private float scaleX;
        private float scaleY;
        public float scale = 1.8f;


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
            float visualX = x * scaleX + bordersize * 2;
            float visualY = y * scaleY + bordersize * 2;

            return new Vector2(visualX, visualY);
        }

        public float ScaleObject(Smoke smokeScale)   // scale 10% of the screeen size
        {
            scale = sizeofthefield / smokeScale.smokey.Width;
            return scale;
        }


    }
}

