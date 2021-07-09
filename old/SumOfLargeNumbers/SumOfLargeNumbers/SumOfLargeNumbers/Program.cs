using System;
class LargeNumSum
{
    public static string sum(string a, string b)
    {
        string sum = "";
        int overTen = 0;
        int numA = 0, numB = 0;
        for (int i = 1; i <= Math.Max(a.Length, b.Length); i++)
        {
            numA = 0;
            numB = 0;
            if (i <= a.Length)
            {
                numA = int.Parse(a[a.Length - i] + "");
                Console.WriteLine("a " + a[a.Length - i]);
            }
            if (i <= b.Length)
            {
                numB = int.Parse(b[b.Length - i] + "");
                Console.WriteLine("b " + b[b.Length - i]);
            }
            sum = ((numA + numB + overTen) % 10) + sum;
            Console.WriteLine("sum " + sum);
            if (numA + numB + overTen > 9)
            {
                overTen = 1;
            }
            else
            {
                overTen = 0;
            }
        }
        if (overTen == 1)
        {
            sum = 1 + sum;
        }
        return sum;
    }
}
class MainClass
{
    public static void Main(string[] args)
    {
        string firstNumber = Console.ReadLine();
        string secondNumber = Console.ReadLine();
        Console.WriteLine(LargeNumSum.sum(firstNumber, secondNumber));
    }
}