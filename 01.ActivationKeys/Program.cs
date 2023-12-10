/*
abcdefghijklmnopqrstuvwxyz
Slice>>>2>>>6
Flip>>>Upper>>>3>>>14
Flip>>>Lower>>>5>>>7
Contains>>>def
Contains>>>deF
Generate

134softsf5ftuni2020rockz42
Slice>>>3>>>7
Contains>>>-rock
Contains>>>-uni-
Contains>>>-rocks
Flip>>>Upper>>>2>>>8
Flip>>>Lower>>>5>>>11
Generate
*/
using System.Data.SqlTypes;

internal class Program
{
    static string activationKey;

    static void Main()
    {
        activationKey = Console.ReadLine();

        string input;
        while ((input = Console.ReadLine()) != "Generate")
        {
            string[] arguments = input.Split(">>>");
            string command = arguments[0];

            if (command == "Contains")
            {
                string substring = arguments[1];
                if (activationKey.Contains(substring))
                {
                    Console.WriteLine($"{activationKey} contains {substring}.");
                }
                else
                {
                    Console.WriteLine("Substring not found!");
                }
            }
            else if (command == "Flip")
            {
                string type = arguments[1];
                int startIndex = int.Parse(arguments[2]);
                int endIndex = int.Parse(arguments[3]);

                if (type == "Upper")
                {
                    string prefix = activationKey.Substring(0, startIndex);
                    string middle = activationKey.Substring(startIndex, endIndex - startIndex).ToUpper();
                    string suffix = activationKey.Substring(endIndex);
                    activationKey = $"{prefix}{middle}{suffix}";
                    Console.WriteLine(activationKey);
                }
                else
                {
                    
                    string prefix = activationKey.Substring(0, startIndex);
                    string middle = activationKey.Substring(startIndex, endIndex - startIndex).ToLower();
                    string suffix = activationKey.Substring(endIndex);
                    activationKey = $"{prefix}{middle}{suffix}";
                    Console.WriteLine(activationKey);
                }
            }
            else if (command == "Slice")
            {
                int startIndex = int.Parse(arguments[1]);
                int endIndex = int.Parse(arguments[2]);

                string firstPart = activationKey.Substring(0, startIndex);
                string secondPart = activationKey.Substring(endIndex);
                activationKey = $"{firstPart}{secondPart}";
                Console.WriteLine(activationKey);
            }
        }

        Console.WriteLine($"Your activation key is: {activationKey}");
    }
}
