using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Game2048
{
    internal static class GameSpecs
    {
        public const int Line_Spacing = 3;
        public const int Width_Of_Main_Frame = 75;
        public const int Height_Of_Main_Frame = 48;
        public const int Min_Row_Of_Game = 2;
        public const int Min_Col_Of_Game = 2;
        public const int Max_Row_Of_Game = 5;
        public const int Max_Col_Of_Game = 10;
        public const int Width_Of_Button = 18;
        public const int Height_Of_Button = 6;
        public const int Width_Of_Menu_Frame = 26;
        public const int Height_Of_Menu_Frame = 30;
        public const int Width_Of_Choosing_Size_Frame = 50;
        public const int Height_Of_Choosing_Size_Frame = 20;
        public const int Width_Of_Hint_Frame = 50;
        public const int Height_Of_Hint_Frame = 20;
        public const int Width_Of_Console_Window = 90;
        public const int Height_Of_Console_Window = 26;
        public const int Width_Of_Record_Frame = 30;
        public const int Height_Of_Record_Frame = 24;
        public const int Width_Of_User_Frame = 45;
        public const int Height_Of_User_Frame = 30;
        public const int Max_Length_Of_Account_Name = 23;
        public const int Min_Length_Of_Account_Name = 1;
        public const int Max_Length_Of_Password = 23;
        public const int Min_Length_Of_Password = 1;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(GameSpecs.Width_Of_Console_Window, GameSpecs.Height_Of_Console_Window);
            Encoding encoding = Encoding.UTF8;
            Record record = new Record("Record");
            User user = new User("UserAccount");
            while (true)
            {
            User:
                user.Read();
                user.SignIn(GameSpecs.Width_Of_User_Frame, GameSpecs.Height_Of_User_Frame);
            Menu:
                Console.Clear();
                var mainFrame = GameUI.ShowAll(GameSpecs.Width_Of_Main_Frame, GameSpecs.Height_Of_Main_Frame, user.AccountName);
                var menuFrame = Menu.Show(mainFrame, GameSpecs.Width_Of_Menu_Frame, GameSpecs.Height_Of_Menu_Frame, GameSpecs.Line_Spacing);
                int choice = Menu.Choose(menuFrame, GameSpecs.Line_Spacing, (int)Menu.Choice.PLAY, (int)Menu.Choice.SIGN_OUT);
                GameControl gameControl = new GameControl();
                if (choice == (int)Menu.Choice.PLAY)
                {
                BeginGame:
                    menuFrame.ClearAll();
                    gameControl.Init(GameSpecs.Min_Row_Of_Game, GameSpecs.Min_Col_Of_Game, GameSpecs.Max_Row_Of_Game, GameSpecs.Max_Col_Of_Game);
                    Rectangle gameControlFrame = gameControl.ChooseSize(mainFrame, GameSpecs.Width_Of_Choosing_Size_Frame, GameSpecs.Height_Of_Choosing_Size_Frame);
                    gameControlFrame.ClearAll();
                    gameControl.Start(mainFrame);

                    if (gameControl.Loses())
                    {
                        record.Init(user.AccountName,gameControl.Score,DateTime.Now);
                        record.Read();
                        record.Store();
                        GameUI.ShowNevigateButton(mainFrame, new Button("You Lose"), new Button("ESC: Menu"), new Button("Enter : Again"), new Button($"Score: {gameControl.Score}"));
                        ConsoleKey key = ConsoleKey.C;
                        while (key != ConsoleKey.Escape && key != ConsoleKey.Enter)
                        {
                            key = Console.ReadKey(true).Key;
                            if (key == ConsoleKey.Enter)
                            {
                                GameUI.ClearAllNevigateButton(mainFrame);
                                gameControl.Clear();
                                goto BeginGame;
                            }
                            else if (key == ConsoleKey.Escape)
                            {
                                mainFrame.ClearAll();
                                goto Menu;
                            }
                        }
                    }

                }
                else if (choice == (int)Menu.Choice.RECORD)
                {
                    menuFrame.ClearAll();
                    record.Read();
                    record.Show(mainFrame,GameSpecs.Width_Of_Record_Frame, GameSpecs.Height_Of_Record_Frame);
                    GameUI.ShowTopLeftNevigationButton(mainFrame, new Button("ESC: Menu"));
                    ConsoleKey key = ConsoleKey.C;
                    while (key != ConsoleKey.Escape)
                    {
                        key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.Escape)
                        {
                            mainFrame.ClearAll();
                            goto Menu;

                        }
                    }
                }
                else if(choice == (int)Menu.Choice.HINT)
                {
                    menuFrame.ClearAll();
                    Rectangle hint = Hint.Show(mainFrame, GameSpecs.Width_Of_Hint_Frame, GameSpecs.Height_Of_Hint_Frame);
                    ConsoleKey key = ConsoleKey.C;
                    while (key != ConsoleKey.Escape)
                    {
                        key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.Escape)
                        {
                            hint.ClearAll();
                            goto Menu;

                        }
                    }
                }
                else if (choice == (int)Menu.Choice.SIGN_OUT)
                {
                    menuFrame.ClearAll();
                    goto User;
                }
            }

        } 
    }
}
