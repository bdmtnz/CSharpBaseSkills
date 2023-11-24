using BasicSkills.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Prepend : Base<int> , IRunnable
    {
        public Prepend()
        {
            Items.AddRange(new[]
            {
                6, 1, 2, 3
            });
        }

        public async Task Run()
        {
            var prepend = Items.Prepend(0);
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Prepend -> [{0}]", string.Join(',', prepend)));
            Console.WriteLine(builder.ToString());
        }
    }
}
