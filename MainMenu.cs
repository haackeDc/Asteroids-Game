using Microsoft.Graphics.Canvas;
using System;
using Windows.UI;
using Windows.Foundation;

namespace Asteroids
{
    public class MainMenu
    {
        public bool gameStarted { get; set; }
        public bool onInstructions { get; set; }
        public bool onCredits { get; set; }
        public CanvasBitmap spaceImage { get; set; }

        //public Point point1 { get; set; }
        //public Point point2 { get; set; }

        //public Rect rect { get; set; }
        public MainMenu()
        {
            gameStarted = false;
            onCredits = false;
            onInstructions = false;
            //point1 = new Point(0, 0);
            //point2 = new Point(1100, 1100);
            //rect = new Rect(point1, point2);
            
        }

        public void DrawMainMenu(CanvasDrawingSession drawingSession)
        {   
            drawingSession.DrawImage(spaceImage);//would put rect in here
            //drawingSession.Clear(Colors.Red);
            var fontFormat = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 72,
                
                
            };
            var fontFormat2 = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 15,


            };

            var fontFormat3 = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 36
            };
            drawingSession.DrawText("CoronAsteroids", 300, 300, Colors.LightYellow, fontFormat);
            drawingSession.DrawText("The Lone white blood cell Osmosis Jones braves the bloodstream to fight against the invisible \n and lifeless virus, COVID-19....Shoot the virus envelopes to survive and thwart the pandemic!", 300, 400, Colors.LightYellow, fontFormat2);
            drawingSession.DrawText("1 : Start Game", 350, 450, Colors.LightYellow, fontFormat3);
            drawingSession.DrawText("2 : Instructions", 350, 500, Colors.LightYellow, fontFormat3);
            drawingSession.DrawText("3 : Credits", 350, 550, Colors.LightYellow, fontFormat3);
        }
        public void DrawInstructions(CanvasDrawingSession drawingSession)
        {   
            drawingSession.DrawImage(spaceImage);//would put rect in here
            //drawingSession.Clear(Colors.Red);
            var fontFormat3 = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 36
            };
            var fontFormat = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 12
            };
            drawingSession.DrawText("HEALTH is shown at the top through a health bar\nAvoid the virus envelopes to not take damage\nIf your health goes to 0, you lose!", 100, 100, Colors.LightYellow, fontFormat);
            drawingSession.DrawText("Shoot virus envelopes to split them until they're small enough to be destroyed\nDestroy the viruses to survive!", 400, 100, Colors.LightYellow, fontFormat);
            drawingSession.DrawText("Press \"B\" to exit", 765, 0, Colors.LightYellow, fontFormat3);
            drawingSession.DrawText("Instructions", 250, 300, Colors.LightYellow, fontFormat3);
            drawingSession.DrawText("UP:       (Use W or up arrow key)", 300, 350, Colors.LightYellow, fontFormat3);
            drawingSession.DrawText("DOWN:     (Use S or down arrow key)", 300, 400, Colors.LightYellow, fontFormat3);
            drawingSession.DrawText("LEFT:     (Use A or left arrow key)", 300, 450, Colors.LightYellow, fontFormat3);
            drawingSession.DrawText("RIGHT:    (Use D or right arrow key)", 300, 500, Colors.LightYellow, fontFormat3);
            drawingSession.DrawText("SHOOT:    (Use SPACEBAR key)", 300, 550, Colors.LightYellow, fontFormat3);
        }

        public void DrawCredits(CanvasDrawingSession drawingSession)
        {   
            drawingSession.DrawImage(spaceImage);//would put rect in here
            //drawingSession.Clear(Colors.Red);
            var fontFormat3 = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 34
            };
            drawingSession.DrawText("Press \"B\" to exit", 765, 0, Colors.LightYellow, fontFormat3);
            drawingSession.DrawText("Created By: \n\n Joseph Cornell \n\n Jason Soltis \n\n Daniel Haacke \n\n Aleksandra Shor", 250, 200, Colors.LightYellow, fontFormat3);
        }
    }
}