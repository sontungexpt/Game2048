using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    internal static class Hint
    {
        public static Rectangle Show(Rectangle frameContain, int width, int height)
        {
            Console.CursorVisible = false;
            Rectangle frame = new Rectangle(width, height);
            frame.Init(new Coord(frameContain.Center().x - width / 2, frameContain.Center().y - height / 4 + 2));
            frame.Draw();
            string hint = "Use the arrow button";
            string hint1 = "to control the game";
            string hint2 = "ESC: Menu";
            Cursor.WriteAt(hint, new Coord(frame.Center().x + frame.WidthConsole / 2 / 2 - hint.Length / 2, frame.Center().y - frame.HeightConsole / 6));
            Cursor.WriteAt(hint1, new Coord(frame.Center().x + frame.WidthConsole / 2 / 2 - hint1.Length / 2, frame.Center().y + frame.HeightConsole / 6));
            Cursor.WriteAt(hint2, new Coord(frame.Center().x + frame.WidthConsole / 2 / 2 - hint2.Length / 2, Cursor.Current().y + GameSpecs.Line_Spacing));
            Square box = new Square(frameContain.WidthConsole / 2 / 6);
            box.Init(new Coord(frame.Center().x - frame.WidthConsole / 2 / 2 - (box.Width + 1) / 2, frame.Center().y + frame.HeightConsole / 6));
            box.Draw((char)25);
            box.Init(new Coord(frame.Center().x - frame.WidthConsole / 2 / 2 - (box.Width + 1) / 2 - box.Width - 1, frame.Center().y + frame.HeightConsole / 6));
            box.Draw((char)27);
            box.Init(new Coord(frame.Center().x - frame.WidthConsole / 2 / 2 - (box.Width + 1) / 2 + box.Width + 1, frame.Center().y + frame.HeightConsole / 6));
            box.Draw((char)26);
            box.Init(new Coord(frame.Center().x - frame.WidthConsole / 2 / 2 - (box.Width + 1) / 2, frame.Center().y + frame.HeightConsole / 6 - (box.Height / 2)));
            box.Draw((char)24);
            return frame;
        }
    }
}
