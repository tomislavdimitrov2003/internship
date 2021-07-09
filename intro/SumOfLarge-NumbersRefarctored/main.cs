using System;
class LargeNumSum
{
  public static string sum (string a, string b)
  {
    string sum = "";
    int carryOverTen = 0;
    int numA = 0, numB = 0;
    int maxLenght = Math.Max(a.Length, b.Length);
    
    for(int i = 1; i <= maxLenght; i++)
    {
      numA = 0;
      numB = 0;
      numA = digitOnIndex(a, i);
      numB = digitOnIndex(b, i);
      sum = ((numA + numB + carryOverTen) % 10) + sum;
      carryOverTen = (numA + numB + carryOverTen) / 10;
    }
    
    if(carryOverTen == 1)
    {
      sum = 1 + sum;
    }
    return sum;
  }

  public static int digitOnIndex (string num, int i){
    
    if(i <= num.Length)
    {
      return int.Parse(num[num.Length - i] + "");
      //Console.WriteLine("a "+a[a.Length-i]);
    } else
    {
      return 0;
    }
  }
}
class MainClass
{
  public static void Main (string[] args)
  {
    string firstNumber = Console.ReadLine();
    string secondNumber = Console.ReadLine();
    Console.WriteLine(LargeNumSum.sum(firstNumber, secondNumber));
  }
}