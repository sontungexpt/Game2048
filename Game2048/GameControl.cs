using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game2048
{
    public struct Button
    {
        public string name;
        public bool appear;
        public int width;
        public int height;

        public Button(string name = "button", bool appear = true, int width = GameSpecs.Width_Of_Button, int height = GameSpecs.Height_Of_Button)
        {
            this.width = width;
            this.height = height;
            this.name = name;
            this.appear = appear;
        }
    }
    internal class GameControl
    {
        #region Feilds (Private)
        private int row;
        private int col;
        private int[,] stored;
        private int maxRow;
        private int maxCol;
        private int minRow;
        private int minCol;
        private int score;
        private Coord origin;
        private Coord appearPosition;
        private ArrayList emptyPosition = new ArrayList();
        private const int SIZE_OF_BOX_SURROUND_NUMBER = 7;
        #endregion

        #region Constructor (Public)
        public GameControl()
        {
            this.row = 3;
            this.col = 3;
            stored = new int[this.row, this.col];
            this.maxRow = 5;
            this.maxCol = 5;
            this.minCol = 2;
            this.minRow = 2;
            this.score = 0;
        }
        public GameControl(int row, int col, int minRow, int minCol, int maxRow, int maxCol)
        {
            this.row = row;
            this.col = col;
            stored = new int[this.row, this.col];
            this.maxRow = maxRow;
            this.maxCol = maxCol;
            this.minCol = minCol;
            this.minRow = minRow;
            this.score = 0;
        }
        public GameControl(int minRow, int minCol, int maxRow, int maxCol)
        {
            this.maxRow = maxRow;
            this.maxCol = maxCol;
            this.minCol = minCol;
            this.minRow = minRow;
            stored = new int[this.row, this.col];
        }
        public GameControl(int row, int col)
        {
            this.score = 0;
            this.row = row;
            this.col = col;
            stored = new int[this.row, this.col];
        }
        #endregion

        #region Properties (Public)
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int Col
        {
            get { return col; }
            set { col = value; }
        }
        public int MaxRow
        {
            get { return maxRow; }
            set { maxRow = value; }
        }
        public int MaxCol
        {
            get { return maxCol; }
            set { maxCol = value; }
        }
        public int MinRow
        {
            get { return minRow; }
            set { minRow = value; }
        }
        public int MinCol
        {
            get { return minCol; }
            set { minCol = value; }
        }
        public Coord Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public int Score
        {
            get { return score; }
        }
        #endregion

        #region Init method (Public)
        public void Init()
        {
            this.row = 3;
            this.col = 3;
            stored = new int[this.row, this.col];
            this.maxRow = 5;
            this.maxCol = 5;
            this.minCol = 2;
            this.minRow = 2;
            this.score = 0;
        }
        public void Init(int row, int col)
        {
            this.score = 0;
            this.row = row;
            this.col = col;
            stored = new int[this.row, this.col];
        }
        public void Init(int minRow, int minCol, int maxRow, int maxCol)
        {
            this.maxRow = maxRow;
            this.maxCol = maxCol;
            this.minCol = minCol;
            this.minRow = minRow;
        }
        public void Init(int row, int col, int minRow, int minCol, int maxRow, int maxCol)
        {
            this.score = 0;
            this.row = row;
            this.col = col;
            stored = new int[this.row, this.col];
            this.maxRow = maxRow;
            this.maxCol = maxCol;
            this.minCol = minCol;
            this.minRow = minRow;
        }
        public void InitMaxSize(int maxRow = 3, int maxCol = 3)
        {
            this.maxRow = maxRow;
            this.maxCol = maxCol;
        }
        #endregion

        #region Controlling method (Public)
        public int WidthScreen()
        {
            if (SIZE_OF_BOX_SURROUND_NUMBER % 2 == 0)
                return (SIZE_OF_BOX_SURROUND_NUMBER + 2) * stored.GetLength(1) - (stored.GetLength(1) - 1);
            else
                return (SIZE_OF_BOX_SURROUND_NUMBER + 1) * stored.GetLength(1) - (stored.GetLength(1) - 1);
        }
        public int HeightScreen()
        {
            return SIZE_OF_BOX_SURROUND_NUMBER / 2 * stored.GetLength(0) - (stored.GetLength(0) - 1);
        }
        public void Begin()
        {
            this.score = 0;
            stored = new int[this.row, this.col];
            for (int i = 0; i < stored.GetLength(0); i++)
                for (int j = 0; j < stored.GetLength(1); j++)
                    stored[i, j] = 0;
            Coord firstPosition = new Coord(0, 0);
            firstPosition = RandomAppearPosition();
            stored[firstPosition.x, firstPosition.y] = 2;
            firstPosition = RandomAppearPosition();
            stored[firstPosition.x, firstPosition.y] = 2;
        }
        public void Show()
        {
            Coord temp = new Coord(origin.x, origin.y);
            Square frames = new Square();
            for (int i = 0; i < stored.GetLength(0); i++)
            {
                for (int j = 0; j < stored.GetLength(1); j++)
                {
                    frames.Init(SIZE_OF_BOX_SURROUND_NUMBER, temp);
                    if (stored[i, j] == 0)
                        frames.Draw(" ");
                    else
                    {
                        if(appearPosition.x == i && appearPosition .y == j)
                            frames.Draw(stored[i, j],ConsoleColor.Red);
                        else
                            frames.Draw(stored[i, j]);
                    }
                    temp.x += frames.WidthConsole - 1;
                }
                temp.x = origin.x;
                temp.y += frames.HeightConsole;
            }
        }
        public Rectangle ChooseSize(Rectangle frameContain, int width, int height)
        {
            Rectangle frame = new Rectangle();
            frame.Init(width, height);
            frame.Init(new Coord(frameContain.Center().x - frame.Width / 2, frameContain.Center().y - frame.Height / 5));
            frame.DrawTitled("Choose size for game!");

            string chooseWidth = "Choose width:";
            string title1 = chooseWidth + $"    numbers(MIN {minCol}, MAX {maxCol})";
            Cursor.WriteAt(title1, new Coord(frameContain.Center().x - title1.Length / 2 + 1, Cursor.Current().y + frame.HeightConsole / 3));

            string chooseHeight = "Choose height:";
            string title2 = chooseHeight + $"    numbers(MIN {minRow}, MAX {maxRow})";
            Cursor.WriteAt(title2, new Coord(frameContain.Center().x - title2.Length / 2 + 1, Cursor.Current().y + 3));

            //set the cursor coordinate for input the width 
            Coord positionOfChooseWidth = new Coord();
            positionOfChooseWidth.x = frameContain.Center().x - title1.Length / 2 + 2 + chooseWidth.Length;
            positionOfChooseWidth.y = frameContain.Center().y - frame.Height / 5 + frame.HeightConsole / 3 + 1;
            this.col = Cursor.InputAt(positionOfChooseWidth, NumbersDigitOf(maxCol), minCol, maxCol);

            //set the cursor coordinate for input the height 
            Coord positionOfChooseHeight = new Coord();
            positionOfChooseHeight.x = frameContain.Center().x - title2.Length / 2 + 2 + chooseHeight.Length;
            positionOfChooseHeight.y = Cursor.Current().y + 3;
            this.row = Cursor.InputAt(positionOfChooseHeight, NumbersDigitOf(maxRow), minRow, MaxRow);
            return frame;
        }
        public ConsoleKey Control(ref int score)
        {
            ConsoleKey button = ConsoleKey.C;
            while (button != ConsoleKey.UpArrow && button != ConsoleKey.DownArrow && button != ConsoleKey.LeftArrow && button != ConsoleKey.RightArrow && button != ConsoleKey.Escape)
            {
                button = Console.ReadKey(true).Key;
                //move up
                if (button == ConsoleKey.Escape)
                {
                    break;
                }
                else if (button == ConsoleKey.UpArrow)
                {
                    Console.Beep();
                    score += MoveUp();
                }
                //move down
                else if (button == ConsoleKey.DownArrow)
                {
                    Console.Beep();
                    score += MoveDown();
                }
                //move left
                else if (button == ConsoleKey.LeftArrow)
                {
                    Console.Beep();
                    score += MoveLeft();
                }
                //move right
                else if (button == ConsoleKey.RightArrow)
                {
                    Console.Beep();
                    score += MoveRight();
                }
            }
            return button;

        }
        public void Start(Rectangle frameContain)
        {
            Begin();
            origin = new Coord(frameContain.Center().x - WidthScreen() / 2, frameContain.Center().y - HeightScreen() / 3 - 2 + 1);
            appearPosition = new Coord();
            while (!Loses())
            {
                GameUI.ShowTopLeftNevigationButton(frameContain, new Button("ESC: Pause"));
                Console.CursorVisible = false;
                Show();

                ConsoleKey c = Control(ref this.score);
                if (c == ConsoleKey.Escape)
                {
                    GameUI.ShowNevigateButton(frameContain, new Button("Paused"), new Button("ESC: Exit"), new Button("Enter: Continue"), new Button("", false));
                    ConsoleKey key = ConsoleKey.C;
                    while (key != ConsoleKey.Enter && key != ConsoleKey.Escape)
                    {
                        key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.Escape)
                        {
                            CreateLosing();
                            GameUI.ClearAllNevigateButton(frameContain);
                            break;
                        }
                        else if (key == ConsoleKey.Enter)
                        {
                            GameUI.ClearTopRightNevigationButton(frameContain);
                            break;
                        }
                            
                    }
                }
                else
                {
                    appearPosition = RandomAppearPosition();
                    stored[appearPosition.x, appearPosition.y] = RandomNewNumber();
                }
            }
            Console.CursorVisible = true;
        }
        public bool Loses()
        {
            if (this.CheckEmptyPosition(stored) == false)
                return true;
            return false;
        }
        public void Clear()
        {
            Coord temp = new Coord(origin.x, origin.y);
            Square frames = new Square();
            for (int i = 0; i < stored.GetLength(0); i++)
            {
                for (int j = 0; j < stored.GetLength(1); j++)
                {
                    frames.Init(SIZE_OF_BOX_SURROUND_NUMBER, temp);
                    frames.Draw(" ");
                    frames.ClearAll();
                    temp.x += frames.WidthConsole - 1;
                }
                temp.x = origin.x;
                temp.y += frames.HeightConsole;
            }
        }
        #endregion
 
        #region Algorithm to control the game (Private)
        private void CreateLosing()
        {
            for (int i = 0; i < stored.GetLength(0); i++)
                for (int j = 0; j < stored.GetLength(1); j++)
                    stored[i, j] = 2;
        }
        private static int NumbersDigitOf(int n)
        {
            int count = 0;
            while (n > 0)
            {
                n /= 10;
                count++;
            }
            return count;
        }
        private int RandomNewNumber()
        {
            Random num = new Random();
            int result = num.Next(0, 5);
            if (result == 0 || result == 1 || result == 2 || result == 3)
                return 2;
            else
                return 4;
        }
        private Coord RandomAppearPosition()
        {
            int appearPos = 0;
            CheckEmptyPosition(stored);
            Random num = new Random();
            appearPos = num.Next(0, emptyPosition.Count - 1);
            return (Coord)emptyPosition[appearPos];
        }
        private bool CheckEmptyPosition(int[,] stored)
        {
            bool empty = false;
            emptyPosition.Clear();
            for (int i = 0; i < stored.GetLength(0); i++)
                for (int j = 0; j < stored.GetLength(1); j++)
                    if (stored[i, j] == 0)
                    {
                        Coord position = new Coord(i, j);
                        emptyPosition.Add(position);
                        empty = true;
                    }
            return empty;
        }
        private int MoveRight(int rowPosition)
        {
            int pointReceived = 0;
            Stack<int> temp = new Stack<int>();
            for (int i = 0; i < stored.GetLength(1); i++)
                if (stored[rowPosition, i] != 0)
                {
                    temp.Push(stored[rowPosition, i]);
                    stored[rowPosition, i] = 0;
                }
            Queue<int> result = new Queue<int>();
            while (temp.Count > 0)
            {
                if (temp.Count >= 2)
                {
                    int first = temp.Pop();
                    int second = temp.Pop();
                    if (first == second)
                    {
                        pointReceived += first + second;
                        result.Enqueue((first + second));
                    }
                    else
                    {
                        result.Enqueue(first);
                        if (temp.Count != 0 && temp.Peek() == second)
                        {
                            int third = temp.Pop();
                            pointReceived += second + third;
                            result.Enqueue(second + third);
                        }
                        else
                            result.Enqueue(second);
                    }
                }
                else
                    result.Enqueue(temp.Pop());
            }
            for (int i = stored.GetLength(1) - 1; result.Count > 0; i--)
                stored[rowPosition, i] = result.Dequeue();
            return pointReceived;
        }
        private int MoveRight()
        {
            int pointReceived = 0;
            for (int i = 0; i < stored.GetLength(0); i++)
                pointReceived += MoveRight(i);
            return pointReceived;

        }
        private int MoveLeft(int rowPosition)
        {
            int pointReceived = 0;
            Stack<int> temp = new Stack<int>();
            for (int i = stored.GetLength(1) - 1; i >= 0; i--)
                if (stored[rowPosition, i] != 0)
                {
                    temp.Push(stored[rowPosition, i]);
                    stored[rowPosition, i] = 0;
                }
            Queue<int> result = new Queue<int>();
            while (temp.Count > 0)
            {
                if (temp.Count >= 2)
                {
                    int first = temp.Pop();
                    int second = temp.Pop();
                    if (first == second)
                    {
                        pointReceived += first + second;
                        result.Enqueue((first + second));
                    }
                    else
                    {
                        result.Enqueue(first);
                        if (temp.Count != 0 && temp.Peek() == second)
                        {
                            int third = temp.Pop();
                            pointReceived += second + third;
                            result.Enqueue(second + third);
                        }
                        else
                            result.Enqueue(second);
                    }
                }
                else
                    result.Enqueue(temp.Pop());
            }
            for (int i = 0; result.Count > 0; i++)
                stored[rowPosition, i] = result.Dequeue();
            return pointReceived;
        }
        private int MoveLeft()
        {
            int pointReceived = 0;
            for (int i = 0; i < stored.GetLength(0); i++)
                pointReceived += MoveLeft(i);
            return pointReceived;
        }
        private int MoveUp(int colPosition)
        {
            int pointReceived = 0;
            Stack<int> temp = new Stack<int>();
            for (int i = stored.GetLength(0) - 1; i >= 0; i--)
                if (stored[i, colPosition] != 0)
                {
                    temp.Push(stored[i, colPosition]);
                    stored[i, colPosition] = 0;
                }
            Queue<int> result = new Queue<int>();
            while (temp.Count > 0)
            {
                if (temp.Count >= 2)
                {
                    int first = temp.Pop();
                    int second = temp.Pop();
                    if (first == second)
                    {
                        pointReceived += first + second;
                        result.Enqueue((first + second));
                    }
                    else
                    {
                        result.Enqueue(first);
                        if (temp.Count != 0 && temp.Peek() == second)
                        {
                            int third = temp.Pop();
                            pointReceived += second + third;
                            result.Enqueue(second + third);
                        }
                        else
                            result.Enqueue(second);
                    }
                }
                else
                    result.Enqueue(temp.Pop());
            }
            for (int i = 0; result.Count > 0; i++)
                stored[i, colPosition] = result.Dequeue();
            return pointReceived;
        }
        private int MoveUp()
        {
            int pointReceived = 0;
            for (int i = 0; i < stored.GetLength(1); i++)
                pointReceived += MoveUp(i);
            return pointReceived;
        }
        private int MoveDown(int colPosition)
        {
            int pointReceived = 0;
            Stack<int> temp = new Stack<int>();
            for (int i = 0; i < stored.GetLength(0); i++)
                if (stored[i, colPosition] != 0)
                {
                    temp.Push(stored[i, colPosition]);
                    stored[i, colPosition] = 0;
                }
            Queue<int> result = new Queue<int>();
            while (temp.Count > 0)
            {
                if (temp.Count >= 2)
                {
                    int first = temp.Pop();
                    int second = temp.Pop();
                    if (first == second)
                    {
                        pointReceived += first + second;
                        result.Enqueue((first + second));
                    }
                    else
                    {
                        result.Enqueue(first);
                        if (temp.Count != 0 && temp.Peek() == second)
                        {
                            int third = temp.Pop();
                            pointReceived += second + third;
                            result.Enqueue(second + third);
                        }
                        else
                            result.Enqueue(second);
                    }
                }
                else
                    result.Enqueue(temp.Pop());
            }
            for (int i = stored.GetLength(0) - 1; result.Count > 0; i--)
                stored[i, colPosition] = result.Dequeue();
            return pointReceived;
        }
        private int MoveDown()
        {
            int pointReceived = 0;
            for (int i = 0; i < stored.GetLength(1); i++)
                pointReceived += MoveDown(i);
            return pointReceived;
        }
        #endregion

    }
}
