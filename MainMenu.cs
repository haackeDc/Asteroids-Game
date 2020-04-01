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
            drawingSession.DrawText("CoronAsteroids", 300, 300,Colors.DarkSlateGray);
            drawingSession.DrawText("1 : Start Game", 350, 350, Colors.DarkSlateGray);
        }
    }
}