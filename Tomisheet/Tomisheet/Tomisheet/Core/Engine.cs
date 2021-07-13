﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core
{
    public static class Engine
    {
        public static void Run(User currentUser) 
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    string[] arguments = input.Split();
                    Type strategyType = Type.GetType("Tomisheet.Core.Strategy." + arguments[0]);
                    MethodInfo strategyMethod = strategyType.GetMethod("Execute");
                    ConstructorInfo strategyConstructor = strategyType.GetConstructor(Type.EmptyTypes);
                    object strategyClassObject = strategyConstructor.Invoke(new object[] { });
 
                    object strategyValue = strategyMethod.Invoke(strategyClassObject, new object[] { currentUser, arguments });
                    Console.Write(strategyValue);
                    input = Console.ReadLine();
                }
                catch (NullReferenceException)
                {
                    throw (new Exception("Wrong Command."));
                }
                catch (TargetInvocationException)
                {
                    string[] arguments = input.Split();
                    Type strategyType = Type.GetType("Tomisheet.Core.Strategy." + arguments[0]);
                    MethodInfo strategyMethod = strategyType.GetMethod("Execute");
                    MethodBody methodBody = strategyMethod.GetMethodBody();
                    IList<LocalVariableInfo> localVariables = methodBody.LocalVariables;
                    string message = "Parameters should be: ";

                    foreach (LocalVariableInfo variable in localVariables)
                    {
                        message += variable + " ";
                    }
                    throw (new Exception(message));
                }
            }
        }
    }
}