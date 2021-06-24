using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    class Smartphone : Calling, Browsing
    {
        public void Call(string callerID)
        {
            Console.WriteLine("Calling... " + callerID);
        }

        public void Browse(string url)
        {
            Console.WriteLine("Browsing: " + url);
        }
    }
}
