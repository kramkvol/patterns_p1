using System;
using System.Windows.Forms;
using ThePlayfairCipher.Bridge;
using ThePlayfairCipher.Bridge.Abstractions;
using ThePlayfairCipher.Bridge.Implementations;

namespace CiphersWithPatterns
{
    static class Program
    {
        static void Main()
        {
            ICipherUIImpl ui = null;

            Console.WriteLine("Enter number: ");
            Console.WriteLine("1. Console");
            Console.WriteLine("2. WinForms");

            string switchNumber = Console.ReadLine();

            switch (switchNumber)
            {
                case "1":
                    ui = new ConsoleUIImpl();
                    break;
                case "2":
                    ui = new WinFormsUIImpl();
                    break;
                default:
                    Console.WriteLine("Number does not exist");
                    return; 
            }

            var app = new CipherApplication(ui);
            app.Start();
        }
    }

}
