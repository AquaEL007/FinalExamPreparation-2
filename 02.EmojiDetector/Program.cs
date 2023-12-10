using System.Text.RegularExpressions;

internal class Program
{

    static void Main()
    {

        string emojiPattern = @"(\:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
        string coolThresholdPattern = @"\d";

        List<string> coolEmojies = new List<string>();

        string input = Console.ReadLine();

        ulong coolThreshold = 1;

        foreach (Match match in Regex.Matches(input, coolThresholdPattern))
        {
            coolThreshold *= ulong.Parse(match.Value);
        }

        MatchCollection matches = Regex.Matches(input, emojiPattern);

        foreach (Match match in matches)
        {
            string emojiStr = match.Groups["emoji"].Value;

            ulong totalEmojiSum = 0;

            foreach (char character in emojiStr)
            {
                totalEmojiSum += character;
            }
            if (totalEmojiSum >= coolThreshold)
            {
                coolEmojies.Add(match.Value);
            }
        }

        Console.WriteLine($"Cool threshold: {coolThreshold}");
        Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

        foreach (string emoji in coolEmojies)
        {
            Console.WriteLine($"{emoji}");
        }
    }
}
