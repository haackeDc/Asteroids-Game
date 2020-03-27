using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWindows {
    public class Bullet : MovingObject {
        public Bullet(float startX, float startY, Tuple<float, float> direction, float speed, float radius)
            : base(startX, startY, direction, speed, radius) {
        }
    }
}
