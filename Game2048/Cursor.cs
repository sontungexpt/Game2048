using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048 {
public struct Coord {
  public int x;
  public int y;

  public Coord(int x = 0, int y = 0) {
    this.x = x;
    this.y = y;
  }
}
internal static class Cursor {

#region Method(Public)
  // get the current coodinates
  public static Coord Current() {
    return new Coord(Console.CursorLeft, Console.CursorTop);
  }

  // input somthing at some coordinates
  public static int InputAt(Coord positionInput, int maxNumberOfCharacter,
                            int minSize, int maxSize) {
    try {
      Console.CursorVisible = true;
      int length = 0;
      string number = "0";
      int currentNumber = 0;
      Console.SetCursorPosition(positionInput.x, positionInput.y);
      ConsoleKey c = ConsoleKey.Z;
      while (c != ConsoleKey.Enter || currentNumber < minSize) {
        c = Console.ReadKey(true).Key;
        if (c == ConsoleKey.Backspace && length > 0) {
          number = number.Remove(number.Length - 1, 1);
          Cursor.BackSpace();
          length--;
        }
        currentNumber = Converting.ToInt(number);
        int nextNumber = 0;
        if (c != ConsoleKey.Enter && c != ConsoleKey.Backspace)
          nextNumber = Converting.ToInt(number + (char)c);
        if (length >= maxNumberOfCharacter)
          continue;
        if (c >= (ConsoleKey)'0' && c <= (ConsoleKey)'9' &&
            nextNumber <= maxSize && length < maxNumberOfCharacter) {
          length++;
          int unit = Converting.ToInt((char)c);
          WriteContinueAt(unit, new Coord(0, 0));
          number += (char)c;
        }
      }
      Console.CursorVisible = false;
      return currentNumber;
    } catch (ArgumentOutOfRangeException e) {
      Console.Clear();
      Console.WriteLine(e.Message);
    }
    return 1;
  }

  // write some thing to some coordinates
  public static void WriteAt(dynamic s, Coord writingPosition,
                             ConsoleColor charColor = ConsoleColor.White) {
    try {
      Console.ForegroundColor = charColor;
      Console.SetCursorPosition(writingPosition.x, writingPosition.y);
      Console.Write(s);
      Console.ResetColor();
    } catch (ArgumentOutOfRangeException e) {
      Console.Clear();
      Console.WriteLine(e.Message);
    }
  }

  // write something begin this cordinate to new coordinates
  public static void
  WriteContinueAt(dynamic s, Coord writingPosition,
                  ConsoleColor charColor = ConsoleColor.White) {

    try {
      Console.ForegroundColor = charColor;
      Console.SetCursorPosition(Cursor.Current().x + writingPosition.x,
                                Cursor.Current().y + writingPosition.y);
      Console.Write(s);
      Console.ResetColor();
    } catch (ArgumentOutOfRangeException e) {
      Console.Clear();
      Console.WriteLine(e.Message);
    }
  }

  // move the cursor to some coordinates
  public static void GoToXY(Coord position) {
    try {
      Console.SetCursorPosition(position.x, position.y);
    } catch (ArgumentOutOfRangeException e) {
      Console.Clear();
      Console.WriteLine(e.Message);
    }
  }

  // delete the entered character
  public static void BackSpace() {
    dynamic backspace = "\b \b";
    Console.Write(backspace);
  }
  // delete the existed character from current coordinates to end of Length Of
  // Console Screen
  public static void DeleteBehind(Coord position) {
    Cursor.GoToXY(position);
    for (int i = 0; i < Console.WindowWidth - position.x; i++)
      Console.Write(" ");
  }

  // delete the existed character from current coordinates with the numbers of
  // deleting characters
  public static void DeleteBehind(Coord position, int numberOfCharacter) {
    try {
      Cursor.GoToXY(position);
      for (int i = 0; i <= numberOfCharacter; i++)
        Console.Write(" ");
    } catch (Exception e) {
      Console.WriteLine(e.Message);
    }
  }
#endregion
}
}
