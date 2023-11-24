using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Delegates
{
    public class Mammals 
    {
        public string Name { get; set; } = "Mammal default name";
    }
    public class Dogs : Mammals { }
    public partial class Delegate
    {
        // Define the delegate.  
        public delegate Mammals HandlerMethod();

        public static Mammals MammalsHandler()
        {
            return new Mammals
            {
                Name = "Covariance mammals handler delegate"
            };
        }

        public static Dogs DogsHandler()
        {
            return new Dogs
            {
                Name = "Covariance dogs handler delegate"
            };
        }
    }
}
