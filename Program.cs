using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            int cek = 10;
            string key;
            Console.WriteLine(cek);
            do
            {
                Console.WriteLine("Hallo farhan");
                int val = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Hallo farhan" + (cek - val));
                Console.Write("diulang lagi y or n ");
                key = Console.ReadLine();
                
            } while (key.Equals("y") ? true : false);
            Console.WriteLine("Bye Bye");
            Environment.Exit(0);
        }
    }
}
