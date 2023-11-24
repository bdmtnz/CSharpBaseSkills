using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Delegates
{
    // Define a class to hold custom event info
    public class AppEventArgs : EventArgs
    {
        public AppEventArgs(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
    public class KeyEventArgs : AppEventArgs
    {
        public KeyEventArgs(string message) : base(message) { }
    }
    public class MouseEventArgs : AppEventArgs
    {
        public MouseEventArgs(string message) : base(message) { }
    }

    public partial class Delegate
    {
        public event EventHandler<AppEventArgs> Event;
        public event EventHandler<MouseEventArgs> MouseEvent;
        public string SystemDate { get; set; }

        // Event handler that accepts a parameter of the EventArgs type.  
        // To override the next fn
        //      public delegate void KeyEventHandler(object sender, KeyEventArgs e)
        // and this fn 
        //      public delegate void MouseEventHandler(object sender, MouseEventArgs e)
        private void MultiHandler(object? sender, AppEventArgs e)
        {
            SystemDate = System.DateTime.Now.ToString();
            var writer = sender is null ? "N/A" : sender.GetType().Name;
            Console.WriteLine($"Log written by {writer} accross {e.Message} EventHandler at {SystemDate}");
        }

        // You can use a method that has an EventArgs parameter,  
        // although the event expects the KeyEventArgs parameter.  
        //this.button1.KeyDown += this.MultiHandler;  
  
        // You can use the same method
        // for an event that expects the MouseEventArgs parameter.  
        //this.button1.MouseClick += this.MultiHandler;  
    }
}
