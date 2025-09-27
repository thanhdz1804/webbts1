using System;
using System.Text;
using TNTLibrary;

namespace TNTConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập tên của bạn: ");
            string name = Console.ReadLine();

            HappinessCalculator calc = new HappinessCalculator();
            calc.InputName = name;
            calc.Calculate();

            Console.WriteLine(calc.GetMessage());
            Console.ReadKey();
        }
    }
}
