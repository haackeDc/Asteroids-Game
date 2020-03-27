using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids {
    public class Alien : MovingObject {
        public Alien(Vector2 startPos, Vector2 direction, int speed, float radius)
            : base(startPos, direction, speed, radius) {
        }
    }
}