// See https://aka.ms/new-console-template for more information
using System;

static void WriteAt(string s, int x, int y)
{
    try
    {
        Console.SetCursorPosition(x, y);
        Console.Write(s);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.Clear();
        Console.WriteLine(e.Message);
    }
}

int WindowWidth = Console.WindowWidth;
int WindowHeight = Console.WindowHeight;
//Console.BackgroundColor = ConsoleColor.Yellow;
/*
for (int x=0; x < WindowWidth; x++)
{
    for (int y=0; y < WindowHeight; y++)
    {
        Console.BackgroundColor = ColorGenerator;
        //Console.SetCursorPosition(y, x);
        //Console.Write("######");
        //System.Threading.Thread.Sleep(5);
    }
}
*/


const int numColors = 4;
int counter = 0;
string[] colorStore = new string[numColors] { "Magenta", "Red", "Yellow", "Blue" };

while (counter < 10000)
{
    int idx = counter % 3;
    var colorObj = new ColorFactory();
    colorObj.GetColorVariant(colorStore[idx]); // 0, 1, 2, 3
    counter += 1;                               // 0 = magenta, 1 red, 2 yellow, 3 blue, 4 outofbounds
    System.Threading.Thread.Sleep(5);
    // Task.Delay(5);
}

public abstract class ColorGenerator
{
    public string Colors { get; set; }
}

public class Magenta : ColorGenerator
{
    public Magenta()
    {
        Console.BackgroundColor = ConsoleColor.Magenta;
        Colors = "Magenta";
    }
}

public class Red : ColorGenerator
{
    public Red()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Colors = "Red";
    }
}

public class Yellow : ColorGenerator
{
    public Yellow()
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Colors = "Yellow";
    }
}

public class Blue : ColorGenerator
{
    public Blue()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Colors = "Blue";
    }
}

interface IColorGeneratorFactory
{
    ColorGenerator GetColorVariant(string description);
}

public class ColorFactory : IColorGeneratorFactory
{
    public ColorGenerator GetColorVariant(string description)
    {
        if (description.Contains("Magenta"))
        {

            return new Magenta();
        }
        else
        if (description.Contains("Red"))
        {

            return new Red();
        }
        else
        if (description.Contains("Yellow"))
        {

            return new Yellow();
        }
        else
         if (description.Contains("Blue"))
        {

            return new Blue();
        }
        else
            throw new ArgumentException("Invalid Description");

        //  Magenta, Red, Yellow
    }
}