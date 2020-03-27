using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids {
    public static class VMath {
        public static float GetVectorMagnitude(Vector2 vector) {
            return (float)Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }

        public static Vector2 GetUnitVector(Vector2 vector) {
            float magnitude = GetVectorMagnitude(vector);
            return new Vector2(vector.X / magnitude, vector.Y / magnitude);
        }

        public static Vector2 AddVectors(Vector2 a, Vector2 b) {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 ScalarMultiply(Vector2 vector, int scalar) {
            return new Vector2(vector.X * scalar, vector.Y * scalar);
        }

        public static float DotProduct(Vector2 a, Vector2 b) {
            return a.X * b.X + a.Y * b.Y;
        }

        public static Vector2 MatrixMult(Vector2 rowVec1, Vector2 rowVec2, Vector2 vector) {
            return new Vector2(DotProduct(rowVec1, vector), DotProduct(rowVec2, vector));
        }

        public static Vector2 RotateVector(Vector2 vector, float degrees) {
            float radians = (float)-(degrees / 360 * 2 * Math.PI); //Negative so rotation is more intuitive
            Vector2 rotateMatrixVec1 = new Vector2((float)Math.Cos(radians), (float)-Math.Sin(radians));
            Vector2 rotateMatrixVec2 = new Vector2((float)Math.Sin(radians), (float)Math.Cos(radians));
            return MatrixMult(rotateMatrixVec1, rotateMatrixVec2, vector);
        }

        public static Vector2 GetPerpendicularVector(Vector2 vector) {
            return new Vector2(-vector.Y, vector.X);
        }
    }
}
