using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWindows {
    public class Asteroid : MovingObject {
        public const float SPLIT_CUTOFF_RADIUS = 10;
        public Asteroid(float startX, float startY, Tuple<float, float> direction, float speed, float radius) 
            : base(startX, startY, direction, speed, radius) {
        }

        public bool CanSplit() {
            return Radius > SPLIT_CUTOFF_RADIUS;
        }
    }
}
