using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Asteroids {
    public class Asteroid : MovingObject {
        public const float SPLIT_CUTOFF_RADIUS = 15;
        public Asteroid(Vector2 startPos, Vector2 direction, int speed, float radius)
            : base(startPos, direction, speed, radius) {
        }

        public bool CanSplit() {
            return Radius > SPLIT_CUTOFF_RADIUS;
        }

        public Asteroid Half()
        {
            Radius /= 2;
            Speed *= 2;
            UnitDirectionVector = VMath.RotateVector(UnitDirectionVector, 25);
            Asteroid splitAsteroid = new Asteroid(Position, UnitDirectionVector, Speed, Radius);
            if (CanSplit())
            {
                splitAsteroid.UnitDirectionVector = VMath.RotateVector(UnitDirectionVector,-50);
            }
            else 
            {
                Destroy();
                splitAsteroid.Health = 0;
            }
            return splitAsteroid;
        }

        public override void Draw(CanvasDrawingSession canvas)
        {
            canvas.FillEllipse(Position, Radius, Radius, Colors.Maroon);
        }
    }
}
