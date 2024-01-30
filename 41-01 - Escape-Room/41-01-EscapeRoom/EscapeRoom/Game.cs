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
    #region Structs
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
    #endregion

    class Game
    {
        #region MemberVariables
        private static bool m_gameIsRunning = true;

        // RoomVariables
        private ColoredCharTile[,]? m_room;
        private ColoredCharTile m_background = new(' ', ConsoleColor.Black);
        private ColoredCharTile m_wall = new('\u2593', ConsoleColor.Green);

        public static int m_roomXValue = 20; // Default Room Width
        public static int m_roomYValue = 10; // Default Room Length

        Vector2 m_levelStart = new(10, 10);

        // DoorVariables
        private ColoredCharTile m_door = new('D', ConsoleColor.Red);
        Vector2 m_doorPosition = new(0, 1); // Default DoorPosition

        // KeyVariables
        private ColoredCharTile m_key = new('K', ConsoleColor.DarkYellow); //'\u26B7'
        Vector2 m_keyPosition = new(2, 2); // Default KeyPosition

        // PlayerCharacterVariables
        private ColoredCharTile m_playerCharacter = new('P', ConsoleColor.DarkCyan);
        Vector2 m_pcPosition = new(1, m_roomYValue / 2); // Default PlayerCharacterPosition

        static bool m_pcHasKey = false;

        #endregion

        public void RunGame()
        {
            Console.CursorVisible = false; // removes CursorVisibility

            Awake();
            Start();

            while (m_gameIsRunning)
            {
                Update();
            }

            Console.Clear();
        }

        #region Awake
        private void Awake()
        {
            InitializeRoom();
            InitializeDoor();
            InitializePC();
        }

        private void InitializeRoom()
        {
            m_room = new ColoredCharTile[m_roomXValue, m_roomYValue]; // Initialization and Definition of 2DArray for Room

            for (int j = 0; j < m_roomYValue; j++)
            {
                for (int i = 0; i < m_roomXValue; i++)
                {
                    if (j == 0 || i == 0 || j == m_roomYValue - 1 || i == m_roomXValue - 1)
                    {
                        m_room[i, j] = m_wall; // WallTile Insert
                    }
                    else
                    {
                        m_room[i, j] = m_background; // BackgroundTile Insert
                    }
                }
            }
        }

        private void InitializeDoor() // Randomizing DoorSpawnPoint
        {
            Random rnd = new();
            int doorSeed = rnd.Next(4);

            switch (doorSeed)
            {
                case 0: // Place Door in <NorthWall>
                    m_doorPosition.x = rnd.Next(1, m_roomXValue - 1);
                    m_doorPosition.y = 0;
                    break;
                case 1: // Place Door in <WestWall>
                    m_doorPosition.x = 0;
                    m_doorPosition.y = rnd.Next(1, m_roomYValue - 1);
                    break;
                case 2: // Place Door in <EastWall>
                    m_doorPosition.y = m_roomXValue - 1;
                    m_doorPosition.y = rnd.Next(1, m_roomYValue - 1);
                    break;
                case 3: // Place Door in <SouthWall>
                    m_doorPosition.x = rnd.Next(1, m_roomXValue - 1);
                    m_doorPosition.y = m_roomYValue - 1;
                    break;
                default:
                    break;
            }

            if (m_room is not null)
                m_room[m_doorPosition.x, m_doorPosition.y] = m_door;
        }

        private void InitializePC() // Randomizing PlayerSpawnPoint
        {
            Random _rnd = new();
            m_pcPosition.x = _rnd.Next(1, m_roomXValue - 1);
            m_pcPosition.y = _rnd.Next(1, m_roomYValue - 1);

            if (m_room is not null)
                m_room[m_pcPosition.x, m_pcPosition.y] = m_playerCharacter;
        }

        #endregion

        #region Start
        private void Start()
        {
            InitializeKey();
        }

        private void InitializeKey() // Randomizing KeySpawnPoint
        {
            Random _rnd = new();

            // Preventing KeySpawnPoint from overriding PlayerSpawnPoint
            do
            {
                m_keyPosition.x = _rnd.Next(1, m_roomXValue - 1);
                m_keyPosition.y = _rnd.Next(1, m_roomYValue - 1);
            }
            while ((m_keyPosition.x == m_pcPosition.x) && (m_keyPosition.y == m_pcPosition.y));

            if (m_room is not null)
                m_room[m_keyPosition.x, m_keyPosition.y] = m_key;
        }

        #endregion

        #region Update
        private void Update()
        {
            Console.SetCursorPosition(m_levelStart.x, m_levelStart.y);
            PrintLevel();
            PCMovement();
        }

        private void PrintLevel() // Prints Walls, Floor, Door, Player at StartPosition, and Key
        {
            for (int j = 0; j < m_roomYValue; j++)
            {
                for (int i = 0; i < m_roomXValue; i++)
                {
                    if (m_room is not null)
                    {
                        Console.ForegroundColor = m_room[i, j].tileColor; // set color
                        Console.Write(m_room[i, j].tile); // print tile with set color
                    }
                }
                Console.SetCursorPosition(m_levelStart.x, m_levelStart.y + 1 + j); // positions the cursor one row downwards
            }
        }

        private void PCMovement()
        {
            Vector2 delta = GetUserInput();
            int _newX = m_pcPosition.x + delta.x;
            int _newY = m_pcPosition.y + delta.y;

            if (m_room is null)
                return;
            if (m_room[_newX, _newY].tile == m_wall.tile)
            {
                return;
            }
            else if (m_room[_newX, _newY].tile == m_door.tile)
            {
                switch (m_pcHasKey)
                {
                    case true:
                        m_room[m_pcPosition.x, m_pcPosition.y] = m_background; // clears PC position
                        m_pcPosition.x = _newX;
                        m_pcPosition.y = _newY;
                        m_room[m_pcPosition.x, m_pcPosition.y] = m_playerCharacter; // sets new PC position
                        m_gameIsRunning = false;
                        break;
                    case false:
                        break;
                }
            }
            else
            {
                PickUpKey(_newX, _newY);

                m_room[m_pcPosition.x, m_pcPosition.y] = m_background; // clears PC position
                m_pcPosition.x = _newX;
                m_pcPosition.y = _newY;
                m_room[m_pcPosition.x, m_pcPosition.y] = m_playerCharacter; // sets new PC position
            }
        }

        private static Vector2 GetUserInput() // returns a "DeltaVector" for PCMovement method
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
            if (m_room is null)
                return;
            if (m_room[_x, _y].tile == m_key.tile)
            {
                m_pcHasKey = true;
                Console.Beep();
                m_playerCharacter.tileColor = ConsoleColor.DarkYellow;
            }
            else
                return;
        }

        #endregion
    }
}
