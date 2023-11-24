using BasicSkills.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Union : Base<int>, IRunnable
    {
        public List<int> Other { get; set; } = new List<int>();

        public Union()
        {
            Items.AddRange(new[]
            {
                6, 1, 2, 3
            });

            Other.AddRange(new[]
            {
                5, 1, 2
            });
        }

        public async Task Run()
        {
            var union = Items.Union(Other);
            var unionBy = Items.UnionBy(Other, item => item);
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Union -> [{0}]", string.Join(',', union)));
            builder.AppendLine(String.Format("UnionBy -> [{0}]", string.Join(',', unionBy)));
            Console.WriteLine(builder.ToString());
        }
    }
}
