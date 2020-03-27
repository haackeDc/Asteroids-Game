using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids {
    public class Bullet : MovingObject {
        public const int BULLET_DAMAGE = 20;
        public Bullet(Vector2 startPos, Vector2 direction, int speed, float radius)
            : base(startPos, direction, speed, radius) {
        }
    }
}
