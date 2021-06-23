using System;
using System.Text.RegularExpressions;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbersToCall = "0882134215 0882134333 0899213421 0558123 3333123";
            string websitesToBrowse = "http://softuni.bg http://youtube.com http://www.g00gle.com";
            string[] callerIDs = numbersToCall.Split(" ");
            string[] urls = websitesToBrowse.Split(" ");
            StationaryPhone stationary = new StationaryPhone();
            Smartphone gsm = new Smartphone();

            foreach (var callerID in callerIDs)
            {
                string check = "[0-9]";
                if (Regex.IsMatch(callerID, check))
                {
                    if (callerID.Length == 7)
                    {
                        stationary.Call(callerID);
                    }

                    if (callerID.Length == 10)
                    {
                        gsm.Call(callerID);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var url in urls)
            {
                string check = "[0-9]";
                if (!Regex.IsMatch(url, check))
                {
                    gsm.Browse(url);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
