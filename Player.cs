using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Asteroids {
    class Player : MovingObject {
        public int MAX_HEALTH = 100;
        public int MAX_SPEED = 12;
        public int ROTATE_DEGREE_INCREMENT = 9;
        public int FIRE_COOLDOWN = 10;
        public int LastFired { get; set; }
        public Player(Vector2 startPos, Vector2 direction, int speed, float radius) 
            : base(startPos, direction, speed, radius) {
            LastFired = FIRE_COOLDOWN;
            Health = MAX_HEALTH;
        }

        public void AsteroidCollision(Asteroid asteroid) {
            Health -= (int)asteroid.Radius;
        }

        public void Rotate(float degrees) {
            UnitDirectionVector = VMath.RotateVector(UnitDirectionVector, degrees);
        }

        public Vector2 GetGunPosition() {
            return VMath.AddVectors(Position, VMath.ScalarMultiply(UnitDirectionVector, 12));
        }

        public override void Draw(CanvasDrawingSession canvas) {
            if (LastFired < FIRE_COOLDOWN)
                LastFired++;
            Vector2 triangleTip = VMath.AddVectors(Position, VMath.ScalarMultiply(UnitDirectionVector, 12));
            Vector2 triangleLeft = VMath.AddVectors(
                VMath.AddVectors(Position, VMath.ScalarMultiply(UnitDirectionVector, -12))
                , VMath.ScalarMultiply(VMath.GetPerpendicularVector(UnitDirectionVector), -8));
            Vector2 triangleRight = VMath.AddVectors(
                VMath.AddVectors(Position, VMath.ScalarMultiply(UnitDirectionVector, -12))
                , VMath.ScalarMultiply(VMath.GetPerpendicularVector(UnitDirectionVector), 8));
            Vector2[] trianglePoints = { triangleTip, triangleLeft, triangleRight };
            CanvasGeometry triangle = CanvasGeometry.CreatePolygon(canvas, trianglePoints);
            canvas.DrawGeometry(triangle, Colors.CadetBlue);
        }
    }
}
