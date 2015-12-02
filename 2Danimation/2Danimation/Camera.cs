using Microsoft.Xna.Framework;

namespace _2Danimation
{
    public class Camera
    {

        public float scaleX;
        public float scaleY;
        public float virtualHeight;
        public float virtualWidth;
        public int borderSize = 64;


        public Camera(int width, int height, float virtualWidth = 1, float virtualHeight = 1)
        {
            this.virtualHeight = virtualHeight;
            this.virtualWidth = virtualWidth;

            scaleX = (float)(width - borderSize * 2) / virtualWidth;
            scaleY = (float)(height - borderSize * 2) / virtualHeight;
        }

        public Vector2 VisualCoord(float x, float y)
        {
            int visualX = (int)(borderSize + x * scaleX);
            int visualY = (int)(borderSize + y * scaleY);
            return new Vector2(visualX, visualY);
            
        }

        public Vector2 ScaleObject(int width, int height)
        {
            return new Vector2(scaleX / width, scaleY / height);
        }


    }
}