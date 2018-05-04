using System;
using System.Collections.Generic;
using System.Text;

namespace ProductReferenceSystem.Util
{
    public abstract class MenuState
    {
        protected MenuContext _context = MenuContext.GetInstance();
        protected Dictionary<Int32, MenuState> _states = new Dictionary<int, MenuState>();

        protected int ParseCommand(String command)
        {
            if (UpperBound < 1)
            {
                throw new Exception("Upper bound of menu command number cannot be less than 1!");
            }
            int cmd = Int32.MaxValue;
            Int32.TryParse(command, out cmd);
            if (cmd < 1 || cmd > UpperBound)
            {
                throw new Exception("Cannot parse product command! Enter the correct command and try again.");
            }
            return cmd;
        }

        public void ExecuteCommand(String command)
        {
            try
            {
                int cmd = ParseCommand(command);
                MenuState state = this._states.GetValueOrDefault(cmd, null);
                //this._states.Remove(UpperBound);
                //this._states.Add(UpperBound, _context.MenuState);
                _context.MenuState = state;
                state.DisplayMain();
                state.ExecuteCommand();
            }
            catch (Exception ex)
            {
                DisplayError();
                DisplayMain();
            }
        }

        protected abstract int UpperBound { get; }
        public abstract void ExecuteCommand();
        public abstract void DisplayMain();
        public abstract void DisplayError();
    }
}
