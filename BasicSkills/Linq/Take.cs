using BasicSkills.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Take : Base<int>, IRunnable
    {
        public Take() : base()
        {
            Items.AddRange(new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            });
        }

        public async Task Run()
        {
            var takeWhile = Items.TakeWhile(item => item % 2 != 0);
            var take = Items.Take(new Range(2, 5));
            var takeLast = Items.TakeLast(5);
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Take [2,5) -> [{0}]", string.Join(',', take)));
            builder.AppendLine(String.Format("TakeLast (5) -> [{0}]", string.Join(',', takeLast)));
            builder.AppendLine(String.Format("TakeWhile ($2 != 0) -> [{0}]", string.Join(',', takeWhile)));
            Console.WriteLine(builder.ToString());
        }
    }
}
