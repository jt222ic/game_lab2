﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllinOne
{
    class Camera
    {
        private int sizeOfftheField = 250;
        private int bordersize = 64;
        public float scale;
        private float scaleX;
        private float scaleY;


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

        public Vector2 VisualCoord(float x, float y)
        {
            float visualX = x * scaleX + bordersize;
            float visualY = y * scaleY + bordersize;

            return new Vector2(visualX, visualY);
        }

        public float ScaleObject(int width, float radius)   // scale 10% of the screeen size
        {
            scale = sizeOfftheField / (float)width;
            return scale;
        }

        public Vector2 ScaleObject2d(int width, int height)
        {
            return new Vector2(scaleX / width, scaleY / height);
        }
    }
}

