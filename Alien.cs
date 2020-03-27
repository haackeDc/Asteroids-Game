using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWindows {
    public class Alien : MovingObject {
        public Alien(float startX, float startY, Tuple<float, float> direction, float speed, float radius) 
            : base(startX, startY, direction, speed, radius) {
        }
    }
}