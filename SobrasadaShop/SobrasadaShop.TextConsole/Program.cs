using System;

namespace SobrasadaShop.TextConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var sobrasada = new Sobrasada();
            Console.WriteLine("Your sobrasada costs " + sobrasada.Price);
        }
    }
}
