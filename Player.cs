using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWindows {
    class Player : MovingObject {
        public const int MAX_HEALTH = 100;
        public const int MAX_SPEED = 15;
        public int Health { get; private set; }
        public Player(float startX, float startY, Tuple<float, float> direction, float speed, float radius) 
            : base(startX, startY, direction, speed, radius) {
            Health = MAX_HEALTH;
        }

        public void Rotate(double degrees) {

        }
    }
}
