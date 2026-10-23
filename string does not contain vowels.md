using System;

internal class Program
{
    static void CheckVowels(string input)
    {
        bool hasvowel = false;

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (c == 'a' || c == 'A' || c == 'e' || c == 'E' || c == 'i' || c == 'I' || c == 'o' || c == 'O' || c == 'u' || c == 'U')
            {
                hasvowel = true;
                break;
            }
        }

        if (!hasvowel)
        {
            throw new Exception("Error");
        }
    }

    static void Main()
    {
        string input = Console.ReadLine();
        CheckVowels(input);
    }
}
