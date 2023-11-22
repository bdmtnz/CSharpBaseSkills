using BasicSkills.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Skip : Base<int>, IRunnable
    {
        public Skip() : base()
        {
            Items.AddRange(new[]
            {
                6, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            });
        }
        public void Run()
        {
            var skip = Items.Skip(5);
            var skipWhile = Items.SkipWhile(item => item >= 5);
            var skipLast = Items.SkipLast(5);
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Skip (5) -> [{0}]", string.Join(',', skip)));
            builder.AppendLine(String.Format("SkipLast (5) -> [{0}]", string.Join(',', skipLast)));
            builder.AppendLine(String.Format("SkipWhile (item > 5) -> [{0}]", string.Join(',', skipWhile)));
            Console.WriteLine(builder.ToString());
        }
    }
}
