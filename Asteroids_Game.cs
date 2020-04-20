using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;
using Windows.Media.Core;

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
        public bool gameOver { get; private set; }
        public CanvasBitmap spaceImage { get; set; }

        public int canvasWidth, canvasHeight;

        Player player;
        List<MovingObject> gameObjects;
        public Asteroids_Game(int width, int height) {
            rand = new Random();
            canvasWidth = width;
            canvasHeight = height;
            gameObjects = new List<MovingObject>();
            gameOver = false;
            App.soundPlayer.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Assets/fire.mp3"));
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
            if (IsSpaceBarPressed)
            {
                App.soundPlayer.Play();
                if (player.LastFired == player.FIRE_COOLDOWN && !player.IsDead())
                {
                    player.LastFired = 0;
                    Bullet newBullet = new Bullet(VMath.AddVectors(player.Position, new Vector2(rand.Next(8) - 4, rand.Next(8) - 4)), player.UnitDirectionVector, 20, 3);
                    gameObjects.Add(newBullet);
                   
                }
            }
            if (rand.Next(1,100) <= 1) //random asteroid spawn chance
            {
                Asteroid newAsteroid = new Asteroid(new Vector2(rand.Next(0, canvasWidth), 0), new Vector2(rand.Next(-180, 180), rand.Next(-180, 180)), rand.Next(1, 5), rand.Next(15, 100));
                gameObjects.Add(newAsteroid);
            }

            foreach (var obj in gameObjects.Where((h => (h is HealthBar))).ToList())
            {
                gameObjects.Remove(obj);
            }
            HealthBar gameHealthBar = new HealthBar(new Vector2(canvasWidth, canvasHeight), new Vector2(0, 0), 0, player.Health);
            gameObjects.Add(gameHealthBar);

            foreach (var obj in gameObjects.ToList())
            {
                obj.Move(canvasWidth, canvasHeight);
                if (obj.IsDead())
                {
                    gameObjects.Remove(obj);
                }
            }

            foreach (var obj in gameObjects.Where((b => (b is Bullet))).ToList()) 
            {
                if (obj.Position.X < 0 || obj.Position.X > canvasWidth || obj.Position.Y < 0 || obj.Position.Y > canvasHeight) {
                    obj.Destroy();
                }
            }
            foreach (var obj in gameObjects.Where((a => (a is Asteroid))).ToList())
            {
                if ((obj.Position.X + obj.Radius > player.Position.X && obj.Position.X - obj.Radius < player.Position.X) && (obj.Position.Y + obj.Radius > player.Position.Y && obj.Position.Y - obj.Radius < player.Position.Y))
                {
                    if (!player.IsDead())
                    {
                        player.AsteroidCollision(obj);
                        obj.Destroy();
                    }
                }
            }
            foreach (var ast in gameObjects.Where((a => (a is Asteroid))).ToList())
            {
                foreach (var bul in gameObjects.Where((b => (b is Bullet))).ToList())
                {
                    if ((ast.Position.X + ast.Radius > bul.Position.X && ast.Position.X - ast.Radius < bul.Position.X) && (ast.Position.Y + ast.Radius > bul.Position.Y && ast.Position.Y - ast.Radius < bul.Position.Y))
                    {
                        gameObjects.Add((ast as Asteroid).Half());
                        bul.Destroy();
                    }
                }
            }
            if(player.Health <= 0)
            {
                gameOver = true;
            }
        }
    }
}
