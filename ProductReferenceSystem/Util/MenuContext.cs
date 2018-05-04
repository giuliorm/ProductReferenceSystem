using System;
using System.Collections.Generic;
using System.Text;

namespace ProductReferenceSystem.Util
{
    public class MenuContext
    {
        private MenuContext()
        {

        }

        private static MenuContext _instance;

        public static MenuContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MenuContext();
            }
            return _instance;
        }
        public MenuState MenuState { get; set; }
    }
}
