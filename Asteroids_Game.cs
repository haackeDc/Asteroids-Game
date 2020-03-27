using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWindows {
    class Asteroids_Game {
        public const float PLAYER_STARTX = 500, PLAYER_STARTY = 800;
        public const float PLAYER_START_DIRECTIONX = 0;
        public const float PLAYER_START_DIRECTIONY = -1;
        public const float PLAYER_START_SPEED = 0;
        public const float PLAYER_START_RADIUS = 10;
        public Asteroids_Game() {
            InitializeObjects();
        }

        public void InitializeObjects() {
            Player player = 
                new Player(PLAYER_STARTX, PLAYER_STARTY, 
                new Tuple<float, float>(PLAYER_START_DIRECTIONX, PLAYER_START_DIRECTIONY), 
                PLAYER_START_SPEED, PLAYER_START_RADIUS);
        }
    }
}
