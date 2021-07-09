using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncTesting
{
    public delegate char FirstDelegate(char[] args);
    public delegate char SecondDelegate(char[] args);
    class Func
    {
        public void DictionaryDelegate()
        {
            // store
            Dictionary<string, Delegate> dico = new Dictionary<string, Delegate>();
            //dico[1] = new Func<int, int, int>(Func1);
            //dico[2] = new Func<int, int, int, int>(Func2);
            FirstDelegate a = Func1;
            SecondDelegate b = Func2;
            dico.Add("Func1", a);
            dico.Add("Func2", b);
            char[] first = {'a', 'b', 'c' };
            char[] second = { 'a', 'b' };
            Console.WriteLine(dico["Func1"].DynamicInvoke(first));
            Console.WriteLine(dico["Func2"].DynamicInvoke(second));
            // and later invoke
            //var res = dico[1].DynamicInvoke(1, 2);
            //Console.WriteLine(res);
            //var res2 = dico[2].DynamicInvoke(1, 2, 3);
            //Console.WriteLine(res2);
        }

        public static char Func1(char[] args)
        {
            return args[2];
        }

        public static char Func2(char[] args)
        {
            return args[1];
        }
    }
}
