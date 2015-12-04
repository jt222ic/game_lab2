using Ballsimulation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace Ballsimulation.View
{
    class BallView
    {

        Texture2D ball;
        Texture2D background;
        //Camera camera;
         BallSimulation b_ballsimunlation;
        
        

        public BallView(ContentManager content, BallSimulation ballsimunlation, GraphicsDeviceManager graphics)
        {
            b_ballsimunlation = ballsimunlation;
           
            ball = content.Load<Texture2D>("Ball.png");
            background = new Texture2D(graphics.GraphicsDevice, 1, 1);
            background.SetData<Color>(new Color[]
            {
                Color.White
            });
                //.Load<Texture2D>("Final.jpg");
            //amera = new Camera();
            
            
        }
        
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, camera.getGameArea(), Color.HotPink);
            Vector2 ballanimation = b_ballsimunlation.position();

            var ballposition = camera.VisualCoord(b_ballsimunlation.GetBalls().BallPosition.X - b_ballsimunlation.GetBalls().Ballsize, b_ballsimunlation.GetBalls().BallPosition.Y - b_ballsimunlation.GetBalls().Ballsize);
            float scale = camera.ScaleObject(ball.Width, b_ballsimunlation.GetBalls().Ballsize);
            spriteBatch.Draw(ball, ballposition, null, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);


            


            // innehållet.
            spriteBatch.End();
        }
       
    }
}
