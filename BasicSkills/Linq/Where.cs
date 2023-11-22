using BasicSkills.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Where : Base<int>, IRunnable
    {
        public Where() : base()
        {
            Items.AddRange(new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            });
        }

        public void Run()
        {
            var moreThanFive = Items.Where(item => item > 5);
            var minusThanFive = Items.Where((item) => item < 5);
            var positionEqualsFive = Items.Where(((item, index) => index == 5));
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Where (>5) -> [{0}]", string.Join(',', moreThanFive)));
            builder.AppendLine(String.Format("Where (<5) -> [{0}]", string.Join(',', minusThanFive)));
            builder.AppendLine(String.Format("Where (index==5) -> [{0}]", string.Join(',', positionEqualsFive)));
            Console.WriteLine(builder.ToString());
        }
    }
}
