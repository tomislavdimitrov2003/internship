using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person
{
    private string name;
    private int money;
    private string bagOfProducts;
}

class Product
{
    private string name;
    private int cost;
}

class CleanInput
{

    public static string[] cleanUp(string input)
    {
        char[] splitBy = { ';', '=', ' ' };
        string[] cleanInput = input.Split(splitBy);
        return cleanInput;
    }

    public static string[] personNames (string[] input)
    {
        string[] personNames = new string [input.Count() / 2 + 1];
        for (int i = 0; i <= input.Count() / 2; i++)
        {
            personNames[i] = input[i * 2];
            Console.WriteLine(personNames[i]);
        }
        return personNames;
    }

    public static string[] personMoney(string[] input)
    {
        string[] personMoney = new string[input.Count() / 2];
        for (int i = 0; i <= input.Count() / 2; i++)
        {
            personMoney[i] = input[i * 2 + 1];
        }
        return personMoney;
    }

    public static string[] productNames(string[] input)
    {
        string[] productNames = new string[input.Count() / 2];
        for (int i = 0; i <= input.Count() / 2; i++)
        {
            productNames[i] = input[i * 2];
        }
        return productNames;
    }

    public static string[] productMoney(string[] input)
    {
        string[] productMoney = new string[input.Count() / 2];
        for (int i = 0; i <= input.Count() / 2; i++)
        {
            productMoney[i] = input[i * 2 + 1];
        }
        return productMoney;
    }

}
class MainClass
{
    public static void Main()
    {
        string people = Console.ReadLine();
        CleanInput.personNames(CleanInput.cleanUp(people));
        //ReadInput.money(people);
        string products = Console.ReadLine();

        string purchase;
        bool stillBuying=true;

        while (stillBuying)
        {
            purchase = Console.ReadLine();

            stillBuying = purchase != "END";

        }
    }
}
