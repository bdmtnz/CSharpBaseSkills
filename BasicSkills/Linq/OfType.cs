using BasicSkills.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class OfType : IRunnable
    {
        System.Collections.ArrayList fruits = new System.Collections.ArrayList(4);

        public OfType()
        {
            fruits.Add("Mango");
            fruits.Add("Orange");
            fruits.Add("Apple");
            fruits.Add(3.0);
            fruits.Add("Banana");
        }

        public async Task Run()
        {
            var ofType = fruits.OfType<string>().ToList();
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("OfType -> [{0}]", string.Join(',', ofType)));
            Console.WriteLine(builder.ToString());
        }
    }
}
