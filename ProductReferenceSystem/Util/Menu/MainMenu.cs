using ProductReferenceSystem.Util;
using ProductReferenceSystem.Util.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductReferenceSystem
{
    public class MainMenu : MenuState
    {
        public MainMenu()
        {
            this._states.Add(1, new ProductMenu(this));
            this._states.Add(5, this);
            //this._states.Add(2, new Tuple<MainMenuItem, MenuState>(MainMenuItem.ProductMenu, new ProductMenu()));
            //this._states.Add(3, new Tuple<MainMenuItem, MenuState>(MainMenuItem.ProductMenu, new ProductMenu()));
            //this._states.Add(4, new Tuple<MainMenuItem, MenuState>(MainMenuItem.ProductMenu, new ProductMenu()));
        }

        private static String MAIN =
            "\nДобро пожаловать в Информационную справочную систему по товарам.\n" +
            "Пожалуйста, выберите один из следующих пунктов:\n\n" +
            "1. Ввод данных о товаре\n" +
            "2. Поиск магазинов по товару\n" +
            "3. Поиск товаров по магазину\n" +
            "4. Сортировка товаров\n";

        protected override int UpperBound { get => 5;  }

        public override void DisplayMain()
        {
            Console.WriteLine(MAIN);
        }

        public override void DisplayError()
        {
            Console.WriteLine("Cannot execute command! Enter correct command and try again.");
        }

        public override void ExecuteCommand()
        {
            DisplayMain();
        }
    }
}
