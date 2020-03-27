using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWindows {
    public class MovingObject : IDrawable, IMoveable {
        public float X { get; protected set; }
        public float Y { get; protected set; }
        public float Radius { get; protected set; }
        public Tuple<float, float> Direction { get; protected set; }
        public float Speed { get; protected set; }

        public MovingObject(float startX, float startY, Tuple<float, float> direction, float speed, float radius) {
            X = startX;
            Y = startY;
            Speed = speed;
            Direction = direction;
            Radius = radius;
        }

        public void SetSpeed(float speed) {

        }

        public void SetDirection(Tuple<float, float> direction) {

        }

        //Interface implementations
        public void Draw(CanvasDrawingSession canvas) {
            throw new NotImplementedException();
        }
        public void Move() {

        }
    }
}
