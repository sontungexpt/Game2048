using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Game2048
{
    internal class User
    {
        #region Feilds (Public)
        private string accountName;
        private string password;
        private string storedFileName;
        private List<User> users;


        #endregion


        #region Properties (Public)
        public string AccountName
        {
            get { return this.accountName; }
            set { this.accountName = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public string StoredFileName
        {
            get { return this.storedFileName; }
            set { this.storedFileName = value; }
        }
        #endregion

        #region Constructor (Public)
        public User()
        {
            this.accountName = null;
            this.password = null;
            this.storedFileName = storedFileName = null;
        }
        public User(string storedFileName)
        {
            this.accountName = null;
            this.password = null;
            this.storedFileName = storedFileName;
            if (storedFileName != null)
                this.storedFileName = "./" + storedFileName + ".txt";
        }
        public User(string accountName, string password)
        {
            this.accountName = accountName;
            this.password = password;
        }

        #endregion

        #region Init_Method (Public)
        public void Init(string accountName, string password)
        {
            this.accountName = accountName;
            this.password = password;
        }
        #endregion

        #region Method (Public)

        public void ResetPassword(int width, int height)
        {
        ResetPassword:
            Console.Clear();
            Rectangle frame = new Rectangle(width, height);
            frame.Init(new Coord(Console.WindowWidth / 2 - frame.WidthConsole / 2, Console.WindowHeight / 2 - frame.WidthConsole / 5));
            frame.DrawTitled("Welcome to 2048: Reset password", ConsoleColor.DarkYellow);
            string accountTitle = "Account Name: ";
            string newPasswordTitle = "New Password: ";
            Cursor.WriteAt(accountTitle, new Coord(frame.Origin.x + frame.WidthConsole / 10, frame.Center().y - frame.HeightConsole / 5));
            ConsoleKey button;
            this.accountName = InputAccountAt(new Coord(frame.Origin.x + frame.WidthConsole / 10 + accountTitle.Length, frame.Center().y - frame.HeightConsole / 5), GameSpecs.Max_Length_Of_Account_Name, GameSpecs.Min_Length_Of_Account_Name, out button);
            if (this.accountName == null)
                goto ResetPassword;

            if (IsExistNameAccount() >= 0)
            {
                Cursor.WriteAt(newPasswordTitle, new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + GameSpecs.Line_Spacing));
                this.password = InputPasswordAt(new Coord(frame.Origin.x + frame.WidthConsole / 10 + newPasswordTitle.Length, Cursor.Current().y), GameSpecs.Max_Length_Of_Password, GameSpecs.Min_Length_Of_Password, out button);
                FixThePassword(this.Password);
                Store();
                Cursor.WriteAt("ESC: Sign in", new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + GameSpecs.Line_Spacing));
                button = ConsoleKey.A;
                while (button != ConsoleKey.Escape)
                {
                    button = Console.ReadKey(true).Key;
                    if (button == ConsoleKey.Escape)
                        SignIn(width, height);
                }
            }
            else
            {
                Cursor.WriteAt("Account name does not exist", new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + GameSpecs.Line_Spacing), ConsoleColor.Red);
                Cursor.WriteAt("Enter: again", new Coord(frame.Origin.x + frame.WidthConsole / 10, frame.Center().y - frame.HeightConsole / 5 + GameSpecs.Line_Spacing * 2));
                Cursor.WriteAt("ESC: Sign in", new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + 1));
                Cursor.WriteAt("Insert: Sign up", new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + 1));
                button = ConsoleKey.A;
                while (button != ConsoleKey.Enter && button != ConsoleKey.Escape && button != ConsoleKey.Insert)
                {
                    button = Console.ReadKey(true).Key;
                    if (button == ConsoleKey.Enter)
                        goto ResetPassword;
                    else if (button == ConsoleKey.Escape)
                        SignIn(width, height);
                    else if (button == ConsoleKey.Insert)
                        SignUp(width, height);
                }
            }
        }
        public void SignUp(int width, int height)
        {
        SignUp:
            Console.Clear();
            Rectangle frame = new Rectangle(width, height);
            frame.Init(new Coord(Console.WindowWidth / 2 - frame.WidthConsole / 2, Console.WindowHeight / 2 - frame.WidthConsole / 5));
            frame.DrawTitled("Welcome to 2048: Sign Up", ConsoleColor.DarkYellow);
            string accountTitle = "Account Name: ";
            string passwordTitle = "Password: ";
            Cursor.WriteAt(accountTitle, new Coord(frame.Origin.x + frame.WidthConsole / 10, frame.Center().y - frame.HeightConsole / 5));
            Cursor.WriteAt(passwordTitle, new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + GameSpecs.Line_Spacing));
            string hadPassword = "Press Insert to go to sign in";
            Cursor.WriteAt(hadPassword, new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + GameSpecs.Line_Spacing));
            ConsoleKey button;
            this.accountName = InputAccountAt(new Coord(frame.Origin.x + frame.WidthConsole / 10 + accountTitle.Length, frame.Center().y - frame.HeightConsole / 5), GameSpecs.Max_Length_Of_Account_Name, GameSpecs.Min_Length_Of_Account_Name, out button);
            if (this.accountName != null)
                this.password = InputPasswordAt(new Coord(frame.Origin.x + frame.WidthConsole / 10 + passwordTitle.Length, Cursor.Current().y + GameSpecs.Line_Spacing), GameSpecs.Max_Length_Of_Password, GameSpecs.Min_Length_Of_Password, out button);
            if (button == ConsoleKey.Insert)
                SignIn(width, height);
            else if (button == ConsoleKey.Delete)
                goto SignUp;
            else
            {
                if (IsExistNameAccount() >= 0)
                {
                    Cursor.WriteAt("Press Enter to sign up again", new Coord(frame.Origin.x + frame.WidthConsole / 10, frame.Center().y - frame.HeightConsole / 5 + GameSpecs.Line_Spacing * 2 + 2));
                    Cursor.WriteAt("Your accout was existed", new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + 1), ConsoleColor.Red);
                    button = ConsoleKey.A;
                    while (button != ConsoleKey.Enter && button != ConsoleKey.Insert)
                    {
                        button = Console.ReadKey(true).Key;
                        if (button == ConsoleKey.Insert)
                            SignIn(width, height);
                        if (button == ConsoleKey.Enter)
                            goto SignUp;
                    }
                }
                else
                {
                    this.Store();
                    return;
                }
            }

        }
        public void SignIn(int width, int height)
        {
        SignIn:
            Console.Clear();
            Rectangle frame = new Rectangle(width, height);
            frame.Init(new Coord(Console.WindowWidth / 2 - frame.WidthConsole / 2, Console.WindowHeight / 2 - frame.WidthConsole / 5));
            frame.DrawTitled("Welcome to 2048", ConsoleColor.DarkGreen);
            string accountTitle = "Account Name: ";
            string passwordTitle = "Password: ";
            Cursor.WriteAt(accountTitle, new Coord(frame.Origin.x + frame.WidthConsole / 10, frame.Center().y - frame.HeightConsole / 5), ConsoleColor.Yellow);
            Cursor.WriteAt(passwordTitle, new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + GameSpecs.Line_Spacing), ConsoleColor.Yellow);
            string fogotPassword = "Press Delete: Fogot password: ";
            string signUp = "Press Insert: Sign up: ";
            Cursor.WriteAt(fogotPassword, new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + +GameSpecs.Line_Spacing));
            Cursor.WriteAt(signUp, new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + 1));
            ConsoleKey button;
            this.accountName = InputAccountAt(new Coord(frame.Origin.x + frame.WidthConsole / 10 + accountTitle.Length, frame.Center().y - frame.HeightConsole / 5), GameSpecs.Max_Length_Of_Account_Name, GameSpecs.Min_Length_Of_Account_Name, out button);
            if (this.accountName != null)
                this.password = InputPasswordAt(new Coord(frame.Origin.x + frame.WidthConsole / 10 + passwordTitle.Length, Cursor.Current().y + GameSpecs.Line_Spacing), GameSpecs.Max_Length_Of_Password, GameSpecs.Min_Length_Of_Password, out button);
            if (button == ConsoleKey.Delete)
                ResetPassword(width, height);
            else if (button == ConsoleKey.Insert)
                SignUp(width, height);
            else
            {
                if (IsExistAccount() < 0)
                {
                    Cursor.WriteAt("Enter: Sign in again", new Coord(frame.Origin.x + frame.WidthConsole / 10, frame.Center().y - frame.HeightConsole / 5 + GameSpecs.Line_Spacing * 2 + 2));
                    Cursor.WriteAt("Your accout does not exist", new Coord(frame.Origin.x + frame.WidthConsole / 10, Cursor.Current().y + 1), ConsoleColor.Red);
                    button = ConsoleKey.A;
                    while (button != ConsoleKey.Enter && button != ConsoleKey.Delete && button != ConsoleKey.Insert)
                    {
                        button = Console.ReadKey(true).Key;
                        if (button == ConsoleKey.Enter)
                            goto SignIn;
                        else if (button == ConsoleKey.Delete)
                            ResetPassword(width, height);
                        else if (button == ConsoleKey.Insert)
                            SignUp(width, height);
                    }
                }
                else
                {
                    return;
                }
            }
        }
        public static string InputAccountAt(Coord positionInput, int maxStringLength, int minStringLength, out ConsoleKey button)
        {
            button = default;
            try
            {
                string result = "";
                Console.CursorVisible = true;
                Console.SetCursorPosition(positionInput.x, positionInput.y);
                ConsoleKey c = ConsoleKey.Z;
                while (c != ConsoleKey.Enter || result.Length < minStringLength)
                {
                    c = Console.ReadKey(true).Key;
                    if (c == ConsoleKey.Insert)
                    {
                        button = ConsoleKey.Insert;
                        return null;
                    }
                    else if (c == ConsoleKey.Delete)
                    {
                        button = ConsoleKey.Delete;
                        return null;
                    }

                    if (c == ConsoleKey.Backspace && result.Length > 0)
                    {
                        result = result.Remove(result.Length - 1, 1);
                        Cursor.BackSpace();
                        continue;
                    }

                    if (result.Length > maxStringLength)
                        continue;


                    if (((c >= ConsoleKey.A && c <= ConsoleKey.Z) || (c >= ConsoleKey.D0 && c <= ConsoleKey.D9)) && result.Length <= maxStringLength && result.Length >= 0)
                    {
                        if (c >= ConsoleKey.D0 && c <= ConsoleKey.D9)
                        {

                            int unit = Converting.ToInt((char)c);
                            Cursor.WriteContinueAt(unit, new Coord(0, 0));
                            result += (char)c;
                        }
                        else
                        {
                            Cursor.WriteContinueAt(c, new Coord(0, 0));
                            result += (char)c;
                        }
                    }
                }
                Console.CursorVisible = false;
                return result;

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
            return "";
        }
        public static string InputPasswordAt(Coord positionInput, int maxStringLength, int minStringLength, out ConsoleKey button)
        {
            button = default;
            try
            {
                string result = "";
                Console.CursorVisible = true;
                Console.SetCursorPosition(positionInput.x, positionInput.y);
                ConsoleKey c = ConsoleKey.Z;
                while (c != ConsoleKey.Enter || result.Length < minStringLength)
                {
                    c = Console.ReadKey(true).Key;
                    if (c == ConsoleKey.Insert)
                    {
                        button = ConsoleKey.Insert;
                        return null;
                    }
                    else if (c == ConsoleKey.Delete)
                    {
                        button = ConsoleKey.Delete;
                        return null;
                    }

                    if (c == ConsoleKey.Backspace && result.Length > 0)
                    {
                        result = result.Remove(result.Length - 1, 1);
                        Cursor.BackSpace();
                        continue;
                    }
                    if (result.Length > maxStringLength)
                        continue;
                    if (((c >= ConsoleKey.A && c <= ConsoleKey.Z) || (c >= ConsoleKey.D0 && c <= ConsoleKey.D9) && result.Length <= maxStringLength && result.Length >= 0))
                    {
                        Cursor.WriteContinueAt('*', new Coord(0, 0));
                        result += (char)c;
                    }
                }
                Console.CursorVisible = false;
                return result;

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public int IsExistNameAccount()
        {
            if (users.Count == 0)
                return -2; //no data
            for (int i = 0; i < users.Count; i++)
                if (this.accountName == users[i].accountName)
                    return i;
            return -1;//can not file the accountName
        }
        public int IsExistNameAccount(string name)
        {
            if (users.Count == 0)
                return -1; //no data
            for (int i = 0; i < users.Count; i++)
                if (name == users[i].accountName)
                    return i;
            return -2;//can not file the accountName
        }
        public int IsExistAccount()
        {
            if (users.Count == 0)
                return -1; //no data
            for (int i = 0; i < users.Count; i++)
                if (users[i].accountName == this.accountName && users[i].password == this.password)
                    return i;
            return -2;//can not file the account
        }
        public bool Store()
        {
            FileStream storedFile = new FileStream(storedFileName, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(storedFile);
            bool success = false;
            if (IsExistNameAccount() >= 0)
            {
                foreach (var user in users)
                {
                    writer.WriteLine(user.accountName);
                    writer.WriteLine(user.password);
                    writer.Flush();
                    success = true;
                }
            }
            else
            {
                users.Add(new User(this.accountName, this.password));
                foreach (var user in users)
                {
                    writer.WriteLine(user.accountName);
                    writer.WriteLine(user.password);
                    writer.Flush();
                    success = true;
                }
            }
            writer.Close();
            storedFile.Close();
            return success;
        }
        public void FixThePassword(string newPassword)
        {
            int position = IsExistNameAccount();
            if (position >= 0)
                this.users[position].password = newPassword;
        }
        public void Read()
        {
            users = new List<User>();
            if (storedFileName == null)
            {
                Exception exception = new Exception("Need set up the file root to store");
                throw exception;
            }
            FileStream fileData = new FileStream(this.storedFileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(fileData);
            while (reader.Peek() != -1)
            {
                string tempName = reader.ReadLine();
                string tempPassword = reader.ReadLine();
                User tempUser = new User(tempName, tempPassword);
                users.Add(tempUser);
            }
            reader.Close();
            fileData.Close();
        }
        #endregion
    }
}
