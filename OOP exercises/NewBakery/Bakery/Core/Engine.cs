namespace Bakery.Core
{
    using Bakery.Core.Contracts;
    using Bakery.IO;
    using Bakery.IO.Contracts;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using Bakery.Core.Strategies;
    using Bakery.Core.Strategies.Contracts;
    using System.Reflection;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] arguments = input.Split();

                string command = arguments[0];

                try
                {
                    Type strategyType = Type.GetType("Bakery.Core.Strategies." + arguments[0]);
                    MethodInfo strategyMethod = strategyType.GetMethod("Execute");
                    ConstructorInfo strategyConstructor = strategyType.GetConstructor(Type.EmptyTypes);
                    object strategyClassObject = strategyConstructor.Invoke(new object[] { });
                    object strategyValue = strategyMethod.Invoke(strategyClassObject, new object[] { arguments, controller });
                    Console.WriteLine(strategyValue);
                }
                catch (ArgumentNullException ane)
                {
                    writer.WriteLine(ane.Message);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }

                input = reader.ReadLine();
            }
        }
    }
}