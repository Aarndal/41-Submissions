using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _2309_41_01_EscapeRoom
{
    struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    struct ColoredCharTile
    {
        public char tile;
        public ConsoleColor tileColor;

        public ColoredCharTile(char _tile = ' ', ConsoleColor _tileColor = ConsoleColor.White)
        {
            tile = _tile;
            tileColor = _tileColor;
        }

    }

    class Game
    {
        #region Variables
        private static bool runGame = true;

        // RoomVariables
        Vector2 levelStart = new Vector2(10, 10);

        public static int RoomXValue = 20; // Default Room Width
        public static int RoomYValue = 10; // Default Room Length

        private ColoredCharTile[,] room;

        private ColoredCharTile background = new ColoredCharTile(' ', ConsoleColor.Black);
        private ColoredCharTile wall = new ColoredCharTile('\u2593', ConsoleColor.Green);

        // DoorVariables
        private ColoredCharTile door = new ColoredCharTile('D', ConsoleColor.Red);
        Vector2 doorPosition = new Vector2(0, 1); // Default DoorPosition
        static bool doorState = false;

        // KeyVariables
        private ColoredCharTile key = new ColoredCharTile('K', ConsoleColor.DarkYellow); //'\u26B7'
        Vector2 keyPosition = new Vector2(2, 2); // Default KeyPosition
        static bool pcHasKey = false;

        // PlayerCharacterVariables
        private ColoredCharTile playerCharacter = new ColoredCharTile('P', ConsoleColor.DarkCyan);
        Vector2 pcPosition = new Vector2(1, RoomYValue / 2); // Default PlayerCharacterPosition

        #endregion

        public void RunGame()
        {
            Console.CursorVisible = false; // removes CursorVisibility

            InitializeRoom();
            InitializeDoor();
            InitializePC();
            InitializeKey();

            while (runGame)
            {
                Update();
            }

            Console.Clear();
        }

        private void InitializeRoom()
        {
            room = new ColoredCharTile[RoomXValue, RoomYValue]; // Initialization and Definition of 2DArray for Room

            for (int j = 0; j < RoomYValue; j++)
            {
                for (int i = 0; i < RoomXValue; i++)
                {
                    if (j == 0 || i == 0 || j == RoomYValue - 1 || i == RoomXValue - 1)
                    {
                        room[i, j] = wall; // WallTile Insert
                    }
                    else
                    {
                        room[i, j] = background; // BackgroundTile Insert
                    }
                }
            }
        }

        private void InitializeDoor() // Randomizing DoorSpawnPoint
        {
            Random _rnd = new Random();
            int _doorSeed = _rnd.Next(4);

            switch (_doorSeed)
            {
                case 0: // Place Door in <NorthWall>
                    doorPosition.x = _rnd.Next(1, RoomXValue - 1);
                    doorPosition.y = 0;
                    break;
                case 1: // Place Door in <WestWall>
                    doorPosition.x = 0;
                    doorPosition.y = _rnd.Next(1, RoomYValue - 1);
                    break;
                case 2: // Place Door in <EastWall>
                    doorPosition.y = RoomXValue - 1;
                    doorPosition.y = _rnd.Next(1, RoomYValue - 1);
                    break;
                case 3: // Place Door in <SouthWall>
                    doorPosition.x = _rnd.Next(1, RoomXValue - 1);
                    doorPosition.y = RoomYValue - 1;
                    break;
                default:
                    break;
            }

            room[doorPosition.x, doorPosition.y] = door;
        }

        private void InitializePC() // Randomizing PlayerSpawnPoint
        {
            Random _rnd = new Random();
            pcPosition.x = _rnd.Next(1, RoomXValue - 1);
            pcPosition.y = _rnd.Next(1, RoomYValue - 1);
            room[pcPosition.x, pcPosition.y] = playerCharacter;
        }

        private void InitializeKey() // Randomizing KeySpawnPoint
        {
            Random _rnd = new Random();

            // Preventing KeySpawnPoint from overriding PlayerSpawnPoint
            do
            {
                keyPosition.x = _rnd.Next(1, RoomXValue - 1);
                keyPosition.y = _rnd.Next(1, RoomYValue - 1);
            }
            while (keyPosition.x == pcPosition.x && keyPosition.y == pcPosition.y);

            room[keyPosition.x, keyPosition.y] = key;
        }

        private void Update()
        {
            Console.SetCursorPosition(levelStart.x, levelStart.y);
            PrintLevel();
            PCMovement();
        }

        private void PrintLevel() // Prints Walls, Floor, Door, Player at StartPosition, and Key
        {
            for (int j = 0; j < RoomYValue; j++)
            {
                for (int i = 0; i < RoomXValue; i++)
                {
                    Console.ForegroundColor = room[i, j].tileColor; // set color
                    Console.Write(room[i, j].tile); // print tile with set color
                }
                Console.SetCursorPosition(levelStart.x, levelStart.y + 1 + j); // positions the cursor one row downwards
            }
        }

        private Vector2 GetUserInput() // returns a "DeltaVector" for PCMovement method
        {
            ConsoleKey input = Console.ReadKey(true).Key; // get KeyInfo from UserInput

            switch (input) // Enable ArrowKeys and WASD to move the PC
            {
                // Move PC upwards
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return new Vector2(0, -1);
                // Move PC leftwards
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return new Vector2(-1, 0);
                // Move PC downwards
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return new Vector2(0, 1);
                // Move PC rightwards
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return new Vector2(1, 0);
                // Don't move PC
                default:
                    return new Vector2(0, 0);
            }
        }

        private void PickUpKey(int _x, int _y) // enables the PC to "pick up" the Key
        {
            if (room[_x, _y].tile == key.tile)
            {
                pcHasKey = true;
                Console.Beep();
                playerCharacter.tileColor = ConsoleColor.DarkYellow;
            }
            else
            {
                return;
            }
        }

        private void PCMovement()
        {
            Vector2 delta = GetUserInput();
            int _newX = pcPosition.x + delta.x;
            int _newY = pcPosition.y + delta.y;


            if (room[_newX, _newY].tile == wall.tile)
            {
                return;
            }
            else if (room[_newX, _newY].tile == door.tile)
            {
                switch (pcHasKey)
                {
                    case true:
                        room[pcPosition.x, pcPosition.y] = background; // clears PC position
                        pcPosition.x = _newX;
                        pcPosition.y = _newY;
                        room[pcPosition.x, pcPosition.y] = playerCharacter; // sets new PC position
                        runGame = false;
                        break;
                    case false:
                        break;
                }
            }
            else
            {
                PickUpKey(_newX, _newY);

                room[pcPosition.x, pcPosition.y] = background; // clears PC position
                pcPosition.x = _newX;
                pcPosition.y = _newY;
                room[pcPosition.x, pcPosition.y] = playerCharacter; // sets new PC position
            }
        }
    }
}
