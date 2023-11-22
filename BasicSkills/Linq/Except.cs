using BasicSkills.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Except :  Base<int> , IRunnable
    {
        public List<int> Duplicate { get; set; } = new List<int>();

        public Except() : base()
        {
            Items.AddRange(new[]
            {
                6, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            });
            Duplicate.AddRange(new[]
            {
                6, 2, 3
            });
        }

        public void Run()
        {
            var except = Items.Except(Duplicate);
            var exceptBy = Items.ExceptBy(Duplicate, Items => Items);
            var take = Items.Take(new Range(2, 5));
            var takeLast = Items.TakeLast(5);
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Except [6,2,3] -> [{0}]", string.Join(',', except)));
            builder.AppendLine(String.Format("ExceptBy [6,2,3] -> [{0}]", string.Join(',', exceptBy)));
            Console.WriteLine(builder.ToString());
        }
    }
}
