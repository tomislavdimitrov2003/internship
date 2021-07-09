using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> companyOrders = new Dictionary<string, Dictionary<string, int>>();
            int numberOfOrders = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOrders; i++)
            {
                string order = Console.ReadLine();
                Dictionary<string, int> orderedProducts = new Dictionary<string, int>();
                string[] arguments = order.Split();
                string company = arguments[0];
                int ammount = int.Parse(arguments[1]);
                string product = arguments[2];

                if (!companyOrders.ContainsKey(company))
                {
                    orderedProducts.Add(product, ammount);
                    companyOrders.Add(company, orderedProducts);
                }
                else if (!companyOrders[company].ContainsKey(product))
                {
                    companyOrders[company].Add(product, ammount);
                }
                else
                {
                    companyOrders[company][product] += ammount;
                }
            }
            var ordered = companyOrders.OrderBy(company => company.Key);
            //object p = (ordered).ForEach(company => Console.WriteLine(company.Key));
            foreach (var company in ordered)
            {
                Console.Write(company.Key + " ");
                foreach (var product in company.Value)
                {
                    Console.Write(product.Key + " " + product.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
