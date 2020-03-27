using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids {
    public class Asteroid : MovingObject {
        public const float SPLIT_CUTOFF_RADIUS = 10;
        public Asteroid(Vector2 startPos, Vector2 direction, int speed, float radius)
            : base(startPos, direction, speed, radius) {
        }

        public bool CanSplit() {
            return Radius > SPLIT_CUTOFF_RADIUS;
        }
    }
}
