using Microsoft.Graphics.Canvas;
using System;
using Windows.UI;

namespace Asteroids
{
    public class MainMenu
    {
        public bool gameStarted { get; set; }
        public MainMenu()
        {
            gameStarted = false;
        }

        internal void DrawMainMenu(CanvasDrawingSession drawingSession)
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
            drawingSession.DrawText("The Lone white blood cell Osmosis Jones braves the bloodstream to fight against the invisible \n and lifeless virus, COVID-19....Shoot the virus envelopes to survive and twart the pandemic!", 250, 400, Colors.DarkSlateGray, fontFormat2);
            drawingSession.DrawText("1 : Start Game", 350, 450, Colors.DarkSlateGray, fontFormat3);
        }
    }
}