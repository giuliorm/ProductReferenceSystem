using ProductReferenceSystem.Database;
using ProductReferenceSystem.Service.Product;
using ProductReferenceSystem.Util.Menu.Product;
using System;
using System.Collections.Generic;
using System.Text;
using P = ProductReferenceSystem.Model.Product;

namespace ProductReferenceSystem.Util.Product
{
    public class ProductMenu : MenuState
    {
        public ProductMenu(MenuState previousState)
        {
            this._states.Add(1, new ProductReader(this, "\nВведите данные о товаре через запятую:\n" +
                "\n" +
                "Имя, Название магазина, Цена\n\n" +
                "Цена должна являться целым неотрицательным числом.\n", 
                "Cannot obtain product data from keyboard!", new ProductFromKeyboardService()));
            this._states.Add(2, new ProductReader(this, "\nВведите путь к файлу с данными о товаре.\n" +
                "Данные о товаре должны быть записаны в следующем формате:\n\n" +
                 "Имя, Название магазина, Цена\n\n" +
                "Цена должна являться целым неотрицательным числом.\n",
                "Cannot obtain product data from file", new ProductFromFileService()));
            this._states.Add(3, previousState);
        }
        public static String MAIN = "\n" +
            "1. Ввод данных о продукте с клавиатуры.\n" +
            "2. Ввод данных о продукте из файла\n" +
            "3. Назад.\n";

        protected override int UpperBound => 3;

        public override void ExecuteCommand()
        {
            ExecuteCommand(Console.ReadLine());
            //HashSet<P> products = null;
            //try
            //{
            //    switch (menuItem)
            //    {
            //        case ProductMenuItem.ProductFromFile:
            //            products = _fileService.ReadProduct(Console.ReadLine());
            //            break;
            //        case ProductMenuItem.ProductFromKeyboard:
            //            products = _keyboardService.ReadProduct(Console.ReadLine());
            //            break;
            //    }
            //    ProductService.AddProducts(products);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    DisplayMain();
            //}
        }

        public override void DisplayMain()
        {
            Console.WriteLine(MAIN);
        }

        public override void DisplayError()
        {
            Console.WriteLine("Cannot parse the product info! Try again.");
        }
    }
}
