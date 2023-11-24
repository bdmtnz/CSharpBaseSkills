using BasicSkills.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Delegates
{
    public partial class Delegate : IRunnable
    {
        public Delegate()
        {
            
        }
        public async Task Run()
        {
            #region Covariance
            HandlerMethod handlerMammals = MammalsHandler;
            // Covariance enables this assignment.  
            HandlerMethod handlerDogs = DogsHandler;

            var builder = new StringBuilder();
            var mammal = handlerMammals();
            builder.AppendLine(mammal.Name);
            mammal = handlerDogs();
            builder.AppendLine(mammal.Name);

            Console.WriteLine(builder.ToString());
            #endregion

            #region Contravariance
            Console.WriteLine("Contravariance");
            Event += MultiHandler;
            MouseEvent += MultiHandler;

            Event(this, new KeyEventArgs("Keyboard dispatch"));
            MouseEvent(this, new MouseEventArgs("Mouse dispatch"));

            Event(null, new MouseEventArgs("App dispatch"));
            #endregion
        }
    }
}
