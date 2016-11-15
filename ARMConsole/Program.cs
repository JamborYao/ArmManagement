using ARMTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ARMRestHelp test = new ARMRestHelp();
            test.GetToken().Wait();
        }
    }
}
