using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Revision
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            //CUD_01 obj = new CUD_01();
            //obj.CreateTable();

            Readata obj = new Readata();
            obj.DisplayData();


            Console.ReadKey();
        }
    }
}
