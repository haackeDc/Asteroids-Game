using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;

namespace Asteroids {
    class Asteroids_Game {
        public const float PLAYER_STARTX = 500, PLAYER_STARTY = 800;
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

        Player player;
        List<MovingObject> gameObjects;
        public Asteroids_Game() {
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
                if (player.Speed < player.MAX_SPEED)
                    player.Speed++;
            } else {
                if (player.Speed > 0)
                    player.Speed--;
            }
            if (IsLeftButtonPressed) {
                player.Rotate(player.ROTATE_DEGREE_INCREMENT);
            }
            if (IsRightButtonPressed) {
                player.Rotate(-player.ROTATE_DEGREE_INCREMENT);
            }
            foreach (var obj in gameObjects)
                obj.Move();
        }
    }
}
