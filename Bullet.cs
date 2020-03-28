using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Asteroids {
    public class Bullet : MovingObject {
        public Bullet(Vector2 startPos, Vector2 direction, int speed, float radius)
            : base(startPos, direction, speed, radius) { }

        public override void Draw(CanvasDrawingSession canvas) {
            canvas.FillEllipse(Position, Radius, Radius, Colors.White);
        }
    }
}
