using ProductReferenceSystem.Util;
using System;

namespace ProductReferenceSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MenuContext.GetInstance().MenuState = new MainMenu();

            while (true)
            {
                MenuContext.GetInstance().MenuState.DisplayMain();
                MenuContext.GetInstance().MenuState.ExecuteCommand(Console.ReadLine());
            }
        }
    }
}
