using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Base<T>
    {
        public List<T> Items { get; set; }
        public Base()
        {
            Items = new List<T>();
        }
    }
}
