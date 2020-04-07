using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace Asteroids
{
    class HealthBar : MovingObject {
        private float size;
        private Vector2 canvasSize;
        public HealthBar(Vector2 startPos, Vector2 direction, int speed, float radius)
            : base(startPos, direction, speed, radius) {
            size = radius;
            canvasSize = startPos;
        }

        public override void Draw(CanvasDrawingSession canvas)
        {
            Vector2 topLeft = new Vector2(0,0);
            Vector2 bottomLeft = new Vector2(0,10);
            Vector2 topRight = new Vector2(canvasSize.X * (size / 100), 0);
            Vector2 bottomRight = new Vector2(canvasSize.X * (size/100), 10);
            Vector2[] rectanglePoints = { topLeft, bottomLeft, bottomRight, topRight };
            CanvasGeometry healthBar = CanvasGeometry.CreatePolygon(canvas, rectanglePoints);
            canvas.FillGeometry(healthBar, Colors.HotPink);
        }
    }
}
