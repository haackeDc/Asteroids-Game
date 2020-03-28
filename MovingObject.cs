using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Asteroids {
    public class MovingObject : IDrawable {
        public Vector2 Position { get; set; }
        public Vector2 UnitDirectionVector { get; set; }
        public float Radius { get; set; }
        public int Speed { get; set; }

        public int Health { get; set; }

        public MovingObject(Vector2 startPos, Vector2 direction, int speed, float radius) {
            Position = startPos;
            Speed = speed;
            UnitDirectionVector = VMath.GetUnitVector(direction);
            Radius = radius;
        }

        //Interface implementations
        public virtual void Draw(CanvasDrawingSession canvas) {}
        public void Move(int canvasWidth, int canvasHeight) {
            Position = VMath.AddVectors(Position, VMath.ScalarMultiply(UnitDirectionVector, Speed));
            if (!(this is Bullet)) {
                if (Position.X > canvasWidth)
                    Position = new Vector2(0, Position.Y);
                if (Position.X < 0)
                    Position = new Vector2(canvasWidth, Position.Y);
                if (Position.Y > canvasHeight)
                    Position = new Vector2(Position.X, 0);
                if (Position.Y < 0)
                    Position = new Vector2(Position.X, canvasHeight);
            }
        }
    }
}
