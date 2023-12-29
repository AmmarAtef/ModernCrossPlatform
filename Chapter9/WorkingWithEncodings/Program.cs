using static System.Console;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml;
using System.IO.Compression;
using System.Text;

WriteLine($"Encodings");
WriteLine($"[1] ASCII");
WriteLine($"[2] UTF-7");
WriteLine($"[3] UTF-8");
WriteLine($"[4] UTF-16 (Unicode)");
WriteLine($"[5] UTF-32");
WriteLine($"[any other key] Default");

Write($"Press a  number to choose an encoding: ");

ConsoleKey number = ReadKey(false).Key;

WriteLine();
WriteLine();

Encoding encoder;

switch (number)
{
    case ConsoleKey.D1:
        encoder = Encoding.ASCII;
        break;
    case ConsoleKey.D2:
        encoder = Encoding.UTF7;
        break;
    case ConsoleKey.D3:
        encoder = Encoding.UTF8;
        break;
    case ConsoleKey.D4:
        encoder = Encoding.Unicode;
        break;
    case ConsoleKey.D5:
        encoder = Encoding.UTF32;
        break;
    default:
        encoder = Encoding.Default;
        break;
}



string message = "Cafe cost :4.39$";

byte[] encoded = encoder.GetBytes(message);


WriteLine($"{encoder.GetType()} uses {encoded.Length} bytes");
WriteLine();


WriteLine($"BYTE HEX CHAR");

foreach (byte b in encoded)
{
    WriteLine($"{b,4}  {b.ToString("X")} {(char)b,5}");
}

string decoded = encoder.GetString(encoded);
WriteLine(decoded);













