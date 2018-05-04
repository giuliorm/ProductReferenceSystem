using ProductReferenceSystem.Service.Product;
using System;
using System.Collections.Generic;
using System.Text;
using P = ProductReferenceSystem.Model.Product;

namespace ProductReferenceSystem.Util.Menu.Product
{
    public class ProductReader : MenuState
    {
        protected override int UpperBound => 1;

        private ProductService _productService;
        private String _mainMessage;
        private String _errorMessage;
        private MenuState _prev;

        public ProductReader(MenuState previousState, 
            String mainMessage, 
            String errorMessage, 
            ProductService productService)
        {
            _prev = previousState;
            _productService = productService;
            _mainMessage = mainMessage;
            _errorMessage = errorMessage;
        }
        public override void DisplayError()
        {
            Console.WriteLine(_errorMessage);
            _context.MenuState.DisplayMain();
        }

        public override void DisplayMain()
        {
            Console.WriteLine(_mainMessage);
        }

        public override void ExecuteCommand()
        {
            String path = Console.ReadLine();
            HashSet<P> products = _productService.ReadProduct(path);
            ProductService.AddProducts(products);
            _context.MenuState = _prev;
        }
    }
}
