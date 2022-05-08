using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    
    internal class Rectangle
    {
        #region Feilds (Private)
        private int width;
        private int height;
        private Coord origin;
        private int widthConsole;
        private int heightConsole;
        #endregion

        #region Contrustor (Public)
        public Rectangle()
        {
            this.width = 0;
            this.height = 0;
            this.origin = new Coord(0, 0);
        }
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public Rectangle(int width, int height, Coord origin)
        {
            this.width = width;
            this.height = height;
            this.origin = origin;
        }
        public Rectangle(Coord origin)
        {
            this.origin = origin;
        }
        #endregion

        #region Properties (Public)
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public Coord Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public int WidthConsole
        {
            get
            {
                if (height % 2 == 0)
                    this.widthConsole = width + 2;
                else
                    this.widthConsole = width - 1 + 2;
                return widthConsole;
            }
        }
        public int HeightConsole
        {
            get
            {
                return height /2;
            }
        }
        #endregion

        #region Init_Method (Public)
        public void Init()
        {
            this.width = 0;
            this.height = 0;
            this.origin = new Coord(0, 0);
        }
        public void Init(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void Init(Coord origin)
        {
            this.origin = origin;
        }
        public void Init(int width, int height, Coord origin)
        {
            this.width = width;
            this.height = height;
            this.origin = origin;
        }
        #endregion

        #region Method (Public)
        //return the coordinates of the center of rectangle
        public Coord Center()
        {
            Coord center = new Coord(this.origin.x + WidthConsole / 2, this.origin.y + HeightConsole / 2);
            return center;
        }

        //draw a frame and write a string at the center above of the frame, set the 
        public void DrawTitled(string title, ConsoleColor characterColor = ConsoleColor.White, ConsoleColor frameColor = ConsoleColor.White)
        {
            if (title.Length > this.width - 2)
            {
                Exception exception = new Exception("Out of range");
                Console.WriteLine("title is too long");
                throw exception;
            }
            Console.ForegroundColor = frameColor;
            if (height % 2 == 0)
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width + 1, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            else
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            Console.ResetColor();
            Cursor.GoToXY(new Coord(origin.x + WidthConsole / 2 - title.Length / 2, origin.y + 1));
            Console.ForegroundColor = characterColor;
            Console.Write(title);
            Console.ResetColor();
        }
       
        //draw a frame and write string at the center of the frame
        public void Draw(string item, ConsoleColor characterColor = ConsoleColor.White, ConsoleColor frameColor = ConsoleColor.White)
        {
            Console.ForegroundColor = frameColor;
            if (height % 2 == 0)
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width + 1, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            else
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            Console.ResetColor();
            Console.ForegroundColor = characterColor;
            Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2 / 2 + 1));
            for (int i = 0; i < width - 1; i++)
                Console.Write(" ");
            Cursor.GoToXY(new Coord(origin.x + WidthConsole / 2 - item.Length / 2, origin.y + height / 2 / 2 + 1));
            Console.Write(item);
            Console.ResetColor();
        }

        //draw a frame and write double number at the center of the frame
        public void Draw(double item, ConsoleColor characterColor = ConsoleColor.White, ConsoleColor frameColor = ConsoleColor.White)
        {
            Console.ForegroundColor = frameColor;
            if (height % 2 == 0)
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width + 1, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            else
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            Console.ResetColor();
            Console.ForegroundColor = characterColor;
            Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2 / 2 + 1));
            for (int i = 0; i < width - 1; i++)
                Console.Write(" ");
            Cursor.GoToXY(new Coord(origin.x + WidthConsole / 2, origin.y + height / 2 / 2 + 1));
            Console.Write(item);
            Console.ResetColor();
        }

        //draw a frame and write character at the center of the frame
        public void Draw(char item, ConsoleColor characterColor = ConsoleColor.White, ConsoleColor frameColor = ConsoleColor.White)
        {
            Console.ForegroundColor = frameColor;
            if (height % 2 == 0)
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width + 1, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            else
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            Console.ResetColor();
            Console.ForegroundColor = characterColor;
            Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2 / 2 + 1));
            for (int i = 0; i < width - 1; i++)
                Console.Write(" ");
            Cursor.GoToXY(new Coord(origin.x + WidthConsole / 2, origin.y + height / 2 / 2 + 1));
            Console.Write(item);
            Console.ResetColor();
        }
        //draw a frame and write integer number at the center of the frame

        public void Draw(int item, ConsoleColor characterColor = ConsoleColor.White, ConsoleColor frameColor = ConsoleColor.White)
        {
            Console.ForegroundColor = frameColor;
            if (height % 2 == 0)
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width + 1, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            else
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            Console.ResetColor();
            Console.ForegroundColor = characterColor;
            Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2 / 2 + 1));
            for (int i = 0; i < width - 1; i++)
                Console.Write(" ");
            Cursor.GoToXY(new Coord(origin.x + WidthConsole / 2-1, origin.y + height / 2 / 2 + 1));
            Console.Write(item);
            Console.ResetColor();
        }

        //draw a frame
        public void Draw(ConsoleColor frameColor = ConsoleColor.White)
        {
            Console.ForegroundColor = frameColor;
            if (height % 2 == 0)
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width + 1, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            else
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width, origin.y + 1 + i));
                    Console.Write((char)124);
                }
            }
            Console.ResetColor();
        }

        //draw an frame but not show it
        public void DrawInvisibal()
        {
            if (height % 2 == 0)
            {
                this.widthConsole = width + 2;
                this.heightConsole = height / 2;
            }
            else
            {
                this.widthConsole = width - 1 + 2;
                this.heightConsole = height / 2;
            }
        }

        //draw a frame and write something at the center above of the frame but not show the frame
        public void DrawInvisibalTitled(string title, ConsoleColor characterColor = ConsoleColor.White)
        {
            if (height % 2 == 0)
            {
                this.widthConsole = width + 2;
                this.heightConsole = height / 2;
            }
            else
            {
                this.widthConsole = width - 1 + 2;
                this.heightConsole = height / 2;
            }
            Cursor.GoToXY(new Coord(origin.x + WidthConsole / 2 - title.Length / 2 + 1, origin.y + 1));
            Console.ForegroundColor = characterColor;
            Console.Write(title);
            Console.ResetColor();
        }

        //delete the frame
        public void ClearFrame()
        {
            if (height % 2 == 0)
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width; i++)
                    Console.Write(' ');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width; i++)
                    Console.Write(' ');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write(' ');
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width + 1, origin.y + 1 + i));
                    Console.Write(' ');
                }
            }
            else
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width - 1; i++)
                    Console.Write(' ');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width - 1; i++)
                    Console.Write(' ');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write(' ');
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width, origin.y + 1 + i));
                    Console.Write(' ');
                }
            }
        }

        //delete the frame and all thing inside frame
        public void ClearAll()
        {
            if (height % 2 == 0)
            {
                for (int i = 0; i <= height / 2; i++)
                    Cursor.DeleteBehind(new Coord(this.origin.x, this.origin.y + i), width + 1);
            }
            else
            {
                for (int i = 0; i <= height / 2; i++)
                    Cursor.DeleteBehind(new Coord(this.origin.x, this.origin.y + i), width);
            }
        }

        //delete the frame and all thing inside frame
        public static void ClearAll(Rectangle frame)
        {
            if (frame.height % 2 == 0)
            {
                for (int i = 0; i <= frame.height / 2; i++)
                    Cursor.DeleteBehind(new Coord(frame.origin.x, frame.origin.y + i), frame.width);
            }
            else
            {
                for (int i = 0; i <= frame.height / 2; i++)
                    Cursor.DeleteBehind(new Coord(frame.origin.x, frame.origin.y + i), frame.width);
            }
        }

        //delete the all thing inside frame but not delete the frame
        public void ClearInside()
        {
            if (height % 2 == 0)
            {
                for (int i = 0; i < height / 2 - 1; i++)
                    Cursor.DeleteBehind(new Coord(origin.x + 1, origin.y + 1 + i), width - 1);
            }
            else
            {
                for (int i = 0; i < height / 2 - 1; i++)
                    Cursor.DeleteBehind(new Coord(origin.x + 1, origin.y + 1 + i), width - 2);
            }
        }

        //delete all but leave left edge and top edge
        public void ClearExceptTopLeftEdge()
        {
            if (height % 2 == 0)
            {
                for (int i = 0; i <= height / 2 - 1; i++)
                    Cursor.DeleteBehind(new Coord(origin.x + 1, origin.y + 1 + i), width);
            }
            else
            {
                for (int i = 0; i <= height / 2 - 1; i++)
                    Cursor.DeleteBehind(new Coord(origin.x + 1, origin.y + 1 + i), width - 1);
            }
        }

        //delete all but leave left edge
        public void ClearExceptLeftEdge()
        {
            if (height % 2 == 0)
            {
                for (int i = 0; i <= height / 2; i++)
                    Cursor.DeleteBehind(new Coord(origin.x + 1, origin.y + i), width);
            }
            else
            {
                for (int i = 0; i <= height / 2; i++)
                    Cursor.DeleteBehind(new Coord(origin.x + 1, origin.y + i), width - 1);
            }
        }

        //delete all but leave top edge
        public void ClearExceptTopEdge()
        {
            if (height % 2 == 0)
            {
                for (int i = 0; i <= height / 2 - 1; i++)
                    Cursor.DeleteBehind(new Coord(origin.x, origin.y + 1 + i), width + 1);
            }
            else
            {
                for (int i = 0; i <= height / 2 - 1; i++)
                    Cursor.DeleteBehind(new Coord(origin.x, origin.y + 1 + i), width);
            }
        }
        #endregion

        #region Static method(Public)

        //draw a frame and write and set the color for something at the center above of the frame, 
        //return the width and height of the frame that showed in the console
        public static Tuple<int, int> DrawTitled(Coord origin, int width, int height, string title, ConsoleColor characterColor = ConsoleColor.White, ConsoleColor frameColor = ConsoleColor.White)
        {
            Tuple<int, int> widthHeightConsole;
            if (title.Length > width - 2)
            {
                Exception exception = new Exception("Out of range");
                Console.WriteLine("title is too long");
                throw exception;
            }
            Console.ForegroundColor = frameColor;
            if (height % 2 == 0)
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width + 1, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                widthHeightConsole = new Tuple<int, int>(width + 2, height / 2);
            }
            else
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                widthHeightConsole = new Tuple<int, int>(width - 1 + 2, height / 2);
            }
            Console.ResetColor();
            Cursor.GoToXY(new Coord(origin.x + width / 2 - title.Length / 2, origin.y + 1));
            Console.ForegroundColor = characterColor;
            Console.Write(title);
            Console.ResetColor();
            return widthHeightConsole;
        }

        //draw a frame
        //return the width and height of the frame that showed in the console
        public static Tuple<int, int> Draw(Coord origin, int width, int height, ConsoleColor frameColor = ConsoleColor.White)
        {
            Tuple<int, int> widthHeightConsole;
            Console.ForegroundColor = frameColor;
            if (height % 2 == 0)
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width + 1, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                widthHeightConsole = new Tuple<int, int>(width + 2, height / 2);
            }
            else
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                widthHeightConsole = new Tuple<int, int>(width - 1 + 2, height / 2);
            }
            Console.ResetColor();
            return widthHeightConsole;

        }

        //draw a frame and write number at the center of the frame
        //return the width and height of the frame that showed in the console
        public static Tuple<int, int> Draw(Coord origin, int width, int height, double item, ConsoleColor characterColor = ConsoleColor.White, ConsoleColor frameColor = ConsoleColor.White)
        {
            Tuple<int, int> widthHeightConsole;
            Console.ForegroundColor = frameColor;
            if (height % 2 == 0)
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width + 1, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                widthHeightConsole = new Tuple<int, int>(width + 2, height / 2);

            }
            else
            {
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2));
                for (int i = 0; i < width - 1; i++)
                    Console.Write('_');
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                for (int i = 0; i < height / 2; i++)
                {
                    Cursor.GoToXY(new Coord(origin.x + width, origin.y + 1 + i));
                    Console.Write((char)124);
                }
                widthHeightConsole = new Tuple<int, int>(width - 1 + 2, height / 2);

            }
            Console.ResetColor();
            Console.ForegroundColor = characterColor;
            Cursor.GoToXY(new Coord(origin.x + 1, origin.y + height / 2 / 2 + 1));
            for (int i = 0; i < width - 1; i++)
                Console.Write(" ");
            Cursor.GoToXY(new Coord(origin.x + width / 2, origin.y + height / 2 / 2 + 1));
            Console.Write(item);
            Console.ResetColor();
            return widthHeightConsole;
        }

        //draw an frame but not show it
        //return the width and height of the frame that showed in the console
        public static Tuple<int, int> DrawInvisibal(Coord origin, int width, int height)
        {
            Tuple<int, int> widthHeightConsole;

            if (height % 2 == 0)
            {
                widthHeightConsole = new Tuple<int, int>(width + 2, height / 2);
            }
            else
            {
                widthHeightConsole = new Tuple<int, int>(width - 1 + 2, height / 2);
            }
            return widthHeightConsole;
        }
        #endregion
    }
}
