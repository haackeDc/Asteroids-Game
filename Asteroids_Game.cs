using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;

namespace Asteroids {
    class Asteroids_Game {
        Random rand;
        public const float PLAYER_STARTX = 700, PLAYER_STARTY = 400;
        public const float PLAYER_START_DIRECTIONX = 0;
        public const float PLAYER_START_DIRECTIONY = -1;
        public const int PLAYER_START_SPEED = 0;
        public const float PLAYER_START_RADIUS = 10;
        public const float NUM_STARTING_ASTEROIDS = 15;
        public const float MAX_ASTEROID_RADIUS = 10;
        public const float MAX_ASTEROID_SPEED = 12;

        public bool IsUpButtonPressed { get; set; }
        public bool IsDownButtonPressed { get; set; }
        public bool IsLeftButtonPressed { get; set; }
        public bool IsRightButtonPressed { get; set; }

        public bool IsSpaceBarPressed { get; set; }

        public int canvasWidth, canvasHeight;

        Player player;
        List<MovingObject> gameObjects;
        public Asteroids_Game(int width, int height) {
            rand = new Random();
            canvasWidth = width;
            canvasHeight = height;
            gameObjects = new List<MovingObject>();
            InitializeObjects();

        }

        public void InitializeObjects() {
            player = new Player(
                new Vector2(PLAYER_STARTX, PLAYER_STARTY), 
                new Vector2(PLAYER_START_DIRECTIONX, PLAYER_START_DIRECTIONY), 
                PLAYER_START_SPEED, PLAYER_START_RADIUS);
            gameObjects.Add(player);
        }

        public void DrawAllGameObjects(CanvasDrawingSession canvas) {
            foreach (var obj in gameObjects) {
                obj.Draw(canvas);
            }
        }

        public void Update() {
            if (IsUpButtonPressed) {
                if (player.Speed < 0)
                    player.Speed = 0;
                if (player.Speed < player.MAX_SPEED)
                    player.Speed++;
            } else {
                if (player.Speed > 0)
                    player.Speed--;
            }
            if (IsDownButtonPressed) {
                if (player.Speed > 0)
                    player.Speed = 0;
                if (player.Speed > -player.MAX_SPEED)
                    player.Speed--;
            } else {
                if (player.Speed < 0)
                    player.Speed++;
            }
            if (IsLeftButtonPressed) {
                player.Rotate(player.ROTATE_DEGREE_INCREMENT);
            }
            if (IsRightButtonPressed) {
                player.Rotate(-player.ROTATE_DEGREE_INCREMENT);
            }
            if (IsSpaceBarPressed) {
                if (player.LastFired == player.FIRE_COOLDOWN) {
                    player.LastFired = 0;
                    Bullet newBullet = new Bullet(VMath.AddVectors(player.Position,new Vector2(rand.Next(8)-4,rand.Next(8)-4)), player.UnitDirectionVector, 20, 3);
                    gameObjects.Add(newBullet);
                }
            }
            foreach (var obj in gameObjects)
                obj.Move(canvasWidth, canvasHeight);
            foreach(var obj in gameObjects.Where(b=>(b is Bullet)).ToList()) {
                if (obj.Position.X < 0 || obj.Position.X > canvasWidth || obj.Position.Y < 0 || obj.Position.Y > canvasHeight) {
                    gameObjects.Remove(obj);
                }
            }
        }
    }
}
