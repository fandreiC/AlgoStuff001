using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS001
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("@@@ First: @@@ ");
            Solution03.CheckValid();
            Console.WriteLine("@@@ Second: @@@ ");
            SolutionPharentesis04.ScreenMe();
            Console.WriteLine("@@@ Updated Stack: @@@ ");
            SolutionParanStack.ScreenMe();

            Console.ReadKey();
        }
    }
}
