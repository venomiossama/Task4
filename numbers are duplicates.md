using System;

internal class Program
{
    static void Main()
    {
        string nch = Console.ReadLine();
        int n = 0;
        for (int i = 0; i < nch.Length; i++)
        {
            n = (n * 10) + (nch[i] - '0');
        }

        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            string numch = Console.ReadLine();
            int val = 0;
            for (int j = 0; j < numch.Length; j++)
            {
                val = (val * 10) + (numch[j] - '0');
            }
            numbers[i] = val;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    throw new Exception("Error");
                }
            }
        }
    }
}
