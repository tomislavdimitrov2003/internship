using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    class StationaryPhone : Calling
    {
        public void Call(string callerID)
        {
            Console.WriteLine("Dialling... " + callerID);
        }
    }
}
