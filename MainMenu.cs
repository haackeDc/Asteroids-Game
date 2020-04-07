using Microsoft.Graphics.Canvas;
using System;
using Windows.UI;

namespace Asteroids
{
    public class MainMenu
    {
        public bool gameStarted { get; set; }
        public bool onInstructions { get; set; }
        public bool onCredits { get; set; }

        public MainMenu()
        {
            gameStarted = false;
            onCredits = false;
            onInstructions = false;
            
        }

        public void DrawMainMenu(CanvasDrawingSession drawingSession)
        {
            drawingSession.Clear(Colors.Red);
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
            drawingSession.DrawText("CoronAsteroids", 250, 300, Colors.DarkSlateGray, fontFormat);
            drawingSession.DrawText("The Lone white blood cell Osmosis Jones braves the bloodstream to fight against the invisible \n and lifeless virus, COVID-19....Shoot the virus envelopes to survive and thwart the pandemic!", 250, 400, Colors.DarkSlateGray, fontFormat2);
            drawingSession.DrawText("1 : Start Game", 350, 450, Colors.DarkSlateGray, fontFormat3);
            drawingSession.DrawText("2 : Instructions", 350, 500, Colors.DarkSlateGray, fontFormat3);
            drawingSession.DrawText("3 : Credits", 350, 550, Colors.DarkSlateGray, fontFormat3);
        }
        public void DrawInstructions(CanvasDrawingSession drawingSession)
        {
            drawingSession.Clear(Colors.Red);
            var fontFormat3 = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 36
            };
            drawingSession.DrawText("Press \"B\" to exit", 765, 0, Colors.DarkSlateGray, fontFormat3);
            drawingSession.DrawText("Instructions", 250, 300, Colors.DarkSlateGray, fontFormat3);
            drawingSession.DrawText("UP:     (Use W or up arrow key)", 300, 350, Colors.DarkSlateGray, fontFormat3);
            drawingSession.DrawText("DOWN:     (Use S or down arrow key)", 300, 400, Colors.DarkSlateGray, fontFormat3);
            drawingSession.DrawText("LEFT:     (Use A or left arrow key)", 300, 450, Colors.DarkSlateGray, fontFormat3);
            drawingSession.DrawText("RIGHT:     (Use D or right arrow key)", 300, 500, Colors.DarkSlateGray, fontFormat3);
            drawingSession.DrawText("SHOOT:     (Use SPACEBAR key)", 300, 550, Colors.DarkSlateGray, fontFormat3);
        }

        public void DrawCredits(CanvasDrawingSession drawingSession)
        {
            drawingSession.Clear(Colors.Red);
            var fontFormat3 = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
            {
                FontSize = 36
            };
            drawingSession.DrawText("Press \"B\" to exit", 765, 0, Colors.DarkSlateGray, fontFormat3);
            drawingSession.DrawText("Created By: \n\n Joseph Cornell \n\n Jason Soltis \n\n Daniel Haacke \n\n Aleksandra Skor", 250, 200, Colors.DarkSlateGray, fontFormat3);
        }
    }
}