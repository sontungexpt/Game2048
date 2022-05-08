using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    internal static class GameUI
    {
        public static Rectangle ShowAll(int width, int height, string nameUser)
        {
            Rectangle mainFrame = new Rectangle();
            mainFrame.Init(width, height);
            mainFrame.Init(new Coord(Console.WindowWidth / 2 - mainFrame.WidthConsole / 2, 0));
            mainFrame.DrawTitled("Game 2048", ConsoleColor.Red);
            String subTitle = "Hello  " + nameUser;
            Cursor.WriteAt(subTitle, new Coord(mainFrame.Center().x - subTitle.Length / 2, Cursor.Current().y + 2), ConsoleColor.DarkGreen);
            String subTitle2 = "(: Are you ready to die :)";
            Cursor.WriteAt(subTitle2, new Coord(mainFrame.Center().x - subTitle2.Length / 2 + 1, Cursor.Current().y + 1),ConsoleColor.DarkGreen);
            return mainFrame;
        }
        
        //show the button at four corner
        public static void ShowNevigateButton(Rectangle frameContain, Button topRightCorner, Button topLeftCorner, Button bottomLeftCorner, Button bottomRightCorner)
        {
            Console.CursorVisible = false;
            Rectangle topRight = new Rectangle(topRightCorner.width, topRightCorner.height, new Coord(frameContain.Origin.x + frameContain.WidthConsole - topRightCorner.width - 5, frameContain.Origin.y + 1));
            if (topRightCorner.appear == true)
                topRight.Draw(topRightCorner.name);
            else
                topRight.ClearAll();

            Rectangle bottomRight = new Rectangle(bottomRightCorner.width, bottomRightCorner.height, new Coord(frameContain.Origin.x + frameContain.WidthConsole - bottomRightCorner.width - 5, frameContain.Origin.y + 1 + topRight.HeightConsole));
            if (bottomRightCorner.appear == true)
                bottomRight.Draw(bottomRightCorner.name);
            else
            {
                if (topRightCorner.appear == true)
                    bottomRight.ClearExceptTopEdge();
                else
                    bottomRight.ClearAll();
            }

            Rectangle topLeft = new Rectangle(topLeftCorner.width, topLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y));
            if (topLeftCorner.appear == true)
                topLeft.Draw(topLeftCorner.name);
            else
                topLeft.ClearExceptTopLeftEdge();


            Rectangle bottomLeft = new Rectangle(bottomLeftCorner.width, bottomLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y + topLeft.HeightConsole));
            if (bottomLeftCorner.appear == true)
                bottomLeft.Draw(bottomLeftCorner.name);
            else
            {
                if (topLeftCorner.appear == true)
                    bottomLeft.ClearExceptTopLeftEdge();
                else
                    bottomLeft.ClearExceptLeftEdge();
            }
        }
        //clear all the button at four corner
        public static void ClearAllNevigateButton(Rectangle frameContain)
        {
            GameUI.ShowNevigateButton(frameContain, new Button("", false), new Button("", false), new Button("", false), new Button("", false));
        }
        public static void ShowTopLeftNevigationButton(Rectangle frameContain, Button topLeftCorner)
        {
            Console.CursorVisible = false;
            Rectangle topLeft = new Rectangle(topLeftCorner.width, topLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y));
            if (topLeftCorner.appear == true)
                topLeft.Draw(topLeftCorner.name);
            else
                topLeft.ClearExceptTopLeftEdge();
        }
        public static void ClearTopLeftNevigationButton(Rectangle frameContain)
        {
            Console.CursorVisible = false;
            Button topLeftCorner = new Button("",false);
            Rectangle topLeft = new Rectangle(topLeftCorner.width, topLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y));
            if (topLeftCorner.appear == true)
                topLeft.Draw(topLeftCorner.name);
            else
                topLeft.ClearExceptTopLeftEdge();
        }
        public static void ShowTopRightNevigationButton(Rectangle frameContain, Button topRightCorner)
        {
            Console.CursorVisible = false;
            Rectangle topRight = new Rectangle(topRightCorner.width, topRightCorner.height, new Coord(frameContain.Origin.x + frameContain.WidthConsole - topRightCorner.width - 5, frameContain.Origin.y + 1));
            if (topRightCorner.appear == true)
                topRight.Draw(topRightCorner.name);
            else
                topRight.ClearAll();
        }
        public static void ClearTopRightNevigationButton(Rectangle frameContain)
        {
            Button topRightCorner = new Button("", false);
            Console.CursorVisible = false;
            Rectangle topRight = new Rectangle(topRightCorner.width, topRightCorner.height, new Coord(frameContain.Origin.x + frameContain.WidthConsole - topRightCorner.width - 5, frameContain.Origin.y + 1));
            if (topRightCorner.appear == true)
                topRight.Draw(topRightCorner.name);
            else
                topRight.ClearAll();
        }
        public static void ShowBottomRightNevigationButton(Rectangle frameContain, Button bottomRightCorner)
        {
            Console.CursorVisible = false;
            Button topRightCorner = new Button("",false);
            Rectangle topRight = new Rectangle(topRightCorner.width, topRightCorner.height, new Coord(frameContain.Origin.x + frameContain.WidthConsole - topRightCorner.width - 5, frameContain.Origin.y + 1));
            if (topRightCorner.appear == true)
                topRight.Draw(topRightCorner.name);
            else
                topRight.ClearAll();

            Rectangle bottomRight = new Rectangle(bottomRightCorner.width, bottomRightCorner.height, new Coord(frameContain.Origin.x + frameContain.WidthConsole - bottomRightCorner.width - 5, frameContain.Origin.y + 1 + topRight.HeightConsole));
            if (bottomRightCorner.appear == true)
                bottomRight.Draw(bottomRightCorner.name);
            else
            {
                if (topRightCorner.appear == true)
                    bottomRight.ClearExceptTopEdge();
                else
                    bottomRight.ClearAll();
            }
        }
        public static void ClearBottomRightNevigationButton(Rectangle frameContain)
        {
            Console.CursorVisible = false;
            Button topRightCorner = new Button("", false);
            Rectangle topRight = new Rectangle(topRightCorner.width, topRightCorner.height, new Coord(frameContain.Origin.x + frameContain.WidthConsole - topRightCorner.width - 5, frameContain.Origin.y + 1));
            if (topRightCorner.appear == true)
                topRight.Draw(topRightCorner.name);
            else
                topRight.ClearAll();
            Button bottomRightCorner = new Button("", false);
            Rectangle bottomRight = new Rectangle(bottomRightCorner.width, bottomRightCorner.height, new Coord(frameContain.Origin.x + frameContain.WidthConsole - bottomRightCorner.width - 5, frameContain.Origin.y + 1 + topRight.HeightConsole));
            if (bottomRightCorner.appear == true)
                bottomRight.Draw(bottomRightCorner.name);
            else
            {
                if (topRightCorner.appear == true)
                    bottomRight.ClearExceptTopEdge();
                else
                    bottomRight.ClearAll();
            }
        }
        public static void ShowBottomLeftNevigationButton(Rectangle frameContain, Button bottomLeftCorner)
        {
            Console.CursorVisible = false;
            Button topLeftCorner = new Button("", false);
            Rectangle topLeft = new Rectangle(topLeftCorner.width, topLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y));
            if (topLeftCorner.appear == true)
                topLeft.Draw(topLeftCorner.name);
            else
                topLeft.ClearExceptTopLeftEdge();


            Rectangle bottomLeft = new Rectangle(bottomLeftCorner.width, bottomLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y + topLeft.HeightConsole));
            if (bottomLeftCorner.appear == true)
                bottomLeft.Draw(bottomLeftCorner.name);
            else
            {
                if (topLeftCorner.appear == true)
                    bottomLeft.ClearExceptTopLeftEdge();
                else
                    bottomLeft.ClearExceptLeftEdge();
            }
        }
        public static void ClearBottomLeftNevigationButton(Rectangle frameContain)
        {
            Console.CursorVisible = false;
            Button topLeftCorner = new Button("", false);
            Rectangle topLeft = new Rectangle(topLeftCorner.width, topLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y));
            if (topLeftCorner.appear == true)
                topLeft.Draw(topLeftCorner.name);
            else
                topLeft.ClearExceptTopLeftEdge();

            Button bottomLeftCorner = new Button("", false);
            Rectangle bottomLeft = new Rectangle(bottomLeftCorner.width, bottomLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y + topLeft.HeightConsole));
            if (bottomLeftCorner.appear == true)
                bottomLeft.Draw(bottomLeftCorner.name);
            else
            {
                if (topLeftCorner.appear == true)
                    bottomLeft.ClearExceptTopLeftEdge();
                else
                    bottomLeft.ClearExceptLeftEdge();
            }
        }
        public static void ShowAllRightNevigationButton(Rectangle frameContain, Button topRightCorner, Button bottomRightCorner)
        {
            Console.CursorVisible = false;
            Rectangle topRight = new Rectangle(topRightCorner.width, topRightCorner.height, new Coord(frameContain.Origin.x + frameContain.WidthConsole - topRightCorner.width - 5, frameContain.Origin.y + 1));
            if (topRightCorner.appear == true)
                topRight.Draw(topRightCorner.name);
            else
                topRight.ClearAll();

            Rectangle bottomRight = new Rectangle(bottomRightCorner.width, bottomRightCorner.height, new Coord(frameContain.Origin.x + frameContain.WidthConsole - bottomRightCorner.width - 5, frameContain.Origin.y + 1 + topRight.HeightConsole));
            if (bottomRightCorner.appear == true)
                bottomRight.Draw(bottomRightCorner.name);
            else
            {
                if (topRightCorner.appear == true)
                    bottomRight.ClearExceptTopEdge();
                else
                    bottomRight.ClearAll();
            }
        }
        public static void ClearAllRightNevigationButton(Rectangle frameContain)
        {
            Console.CursorVisible = false;
            Button topLeftCorner = new Button("", false);
            Rectangle topLeft = new Rectangle(topLeftCorner.width, topLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y));
            if (topLeftCorner.appear == true)
                topLeft.Draw(topLeftCorner.name);
            else
                topLeft.ClearExceptTopLeftEdge();

            Button bottomLeftCorner = new Button("", false);
            Rectangle bottomLeft = new Rectangle(bottomLeftCorner.width, bottomLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y + topLeft.HeightConsole));
            if (bottomLeftCorner.appear == true)
                bottomLeft.Draw(bottomLeftCorner.name);
            else
            {
                if (topLeftCorner.appear == true)
                    bottomLeft.ClearExceptTopLeftEdge();
                else
                    bottomLeft.ClearExceptLeftEdge();
            }
        }
        public static void ShowAllLeftNevigationButton(Rectangle frameContain, Button topLeftCorner, Button bottomLeftCorner)
        {
            Console.CursorVisible = false;
            Rectangle topLeft = new Rectangle(topLeftCorner.width, topLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y));
            if (topLeftCorner.appear == true)
                topLeft.Draw(topLeftCorner.name);
            else
                topLeft.ClearExceptTopLeftEdge();


            Rectangle bottomLeft = new Rectangle(bottomLeftCorner.width, bottomLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y + topLeft.HeightConsole));
            if (bottomLeftCorner.appear == true)
                bottomLeft.Draw(bottomLeftCorner.name);
            else
            {
                if (topLeftCorner.appear == true)
                    bottomLeft.ClearExceptTopLeftEdge();
                else
                    bottomLeft.ClearExceptLeftEdge();
            }
        }
        public static void ClearAllLeftNevigationButton(Rectangle frameContain)
        {
            Console.CursorVisible = false;
            Button topLeftCorner = new Button("", false);
            Rectangle topLeft = new Rectangle(topLeftCorner.width, topLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y));
            if (topLeftCorner.appear == true)
                topLeft.Draw(topLeftCorner.name);
            else
                topLeft.ClearExceptTopLeftEdge();

            Button bottomLeftCorner = new Button("", false);
            Rectangle bottomLeft = new Rectangle(bottomLeftCorner.width, bottomLeftCorner.height, new Coord(frameContain.Origin.x, frameContain.Origin.y + topLeft.HeightConsole));
            if (bottomLeftCorner.appear == true)
                bottomLeft.Draw(bottomLeftCorner.name);
            else
            {
                if (topLeftCorner.appear == true)
                    bottomLeft.ClearExceptTopLeftEdge();
                else
                    bottomLeft.ClearExceptLeftEdge();
            }
        }

    }
}
