using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    internal static class Menu
    {
        public enum Choice
        {
            PLAY = 1,
            RECORD,
            HINT,
            SIGN_OUT,
        }

        #region Method (Public)
        public static Rectangle Show(Rectangle frameContain, int width, int height, int lineSpacing)
        {
            Console.CursorVisible = false;
            Rectangle frame = new Rectangle(width, height);
            if(frame.HeightConsole > frameContain.HeightConsole)
            {
                Exception exception = new Exception("menu height can be grater than frameContain heightConsole");
                throw exception;
            }
            frame.Init(new Coord(frameContain.Center().x - frame.WidthConsole / 2, frameContain.Center().y - (frame.HeightConsole / 3 + frame.HeightConsole / 2 / 3)));
            string menuTitle = "<---------Menu--------->";
            frame.DrawInvisibalTitled(menuTitle);
            string playTitle = "Play";
            Cursor.WriteAt(playTitle, new Coord(frame.Center().x - playTitle.Length / 2 + 1, frame.Origin.y + frame.HeightConsole / 3));
            string recordTitle = "Record";
            Cursor.WriteAt(recordTitle, new Coord(frame.Center().x - recordTitle.Length / 2 + 1, Cursor.Current().y + lineSpacing));
            string hintTitle = "Hint";
            Cursor.WriteAt(hintTitle, new Coord(frame.Center().x - hintTitle.Length / 2 + 1, Cursor.Current().y + lineSpacing));
            string signOutTitle = "Sign Out";
            Cursor.WriteAt(signOutTitle, new Coord(frame.Center().x - signOutTitle.Length / 2 + 1, Cursor.Current().y + lineSpacing));
            if(Cursor.Current().y - frame.Origin.y >= frame.HeightConsole)
            {
                Exception exception = new Exception("menu height can be grater than frameContain heightConsole");
                throw exception;
            }
            return frame;
        }

        public static int Choose(Rectangle framesContains, int lineSpacing, int minChoice, int maxChoice)
        {
            Console.CursorVisible = false;
            Cursor.WriteAt((char)187, new Coord(framesContains.Origin.x + framesContains.Width / 5, framesContains.Origin.y + framesContains.Height / 6));
            ConsoleKey button = ConsoleKey.C;
            int choice = minChoice;

            while ((button != ConsoleKey.UpArrow && button != ConsoleKey.DownArrow) || button != ConsoleKey.Enter)
            {
                button = Console.ReadKey(true).Key;
                if (button == ConsoleKey.Enter)
                    break;
                //move up
                if (button == ConsoleKey.UpArrow)
                {
                    choice = MoveUp(choice, minChoice, lineSpacing);
                }
                //move down
                else if (button == ConsoleKey.DownArrow)
                {
                    choice = MoveDown(choice, maxChoice, lineSpacing);
                }
            }
            return choice;
        }

        public static int MoveUp(int choice, int minChoice, int lineSpacing)
        {
            Console.CursorVisible = false;
            choice--;
            if (choice == minChoice - 1)
                choice = minChoice;
            else
            {
                Cursor.WriteAt(" ", new Coord(Cursor.Current().x - 1, Cursor.Current().y));
                Cursor.WriteAt((char)187, new Coord(Cursor.Current().x - 1, Cursor.Current().y - lineSpacing));
            }
            return choice;
        }

        public static int MoveDown(int choice, int maxChoice, int lineSpacing)
        {
            Console.CursorVisible = false;
            choice++;
            if (choice == maxChoice + 1)
                choice = maxChoice;
            else
            {
                Cursor.WriteAt(" ", new Coord(Cursor.Current().x - 1, Cursor.Current().y));
                Cursor.WriteAt((char)187, new Coord(Cursor.Current().x - 1, Cursor.Current().y + lineSpacing));
            }
            return choice;
        }
        #endregion
    }
}