using System.Xml.Schema;

namespace GenericAndCollection.Utility;

public static class GetInput
{
    public static int GetInt()
    {
        while (true)
        {
            try
            {
                var input = Console.ReadLine();
                if (input != null) return Int32.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Masukkan Id yang sesuai . . .");
            }
        }
    }
    
    public static string GetString(string text)
    {
        string? name;
        while (true)
        {
            Console.Write(text);
            name = Console.ReadLine();
            if (name != null && name.Length >= 2)
            {
                break;
            }
            else
            {
                Console.WriteLine("Insert at Least 2 Character . . .");
            }
        }

        return name;
    }
}