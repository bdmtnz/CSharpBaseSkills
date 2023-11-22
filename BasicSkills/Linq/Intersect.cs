using BasicSkills.Base;
using BasicSkills.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Intersect : Base<Product>, IRunnable
    {
        public List<int> Numbers { get; set; } = new List<int>();
        public List<int> NumbersInt { get; set; } = new List<int>();
        public List<Product> ItemsInt { get; set; } = new List<Product>();

        public Intersect() : base()
        {
            var P1 = new Product() { Code = 0, Name = "Algo 0" };
            var P2 = new Product() { Code = 1, Name = "Algo 1" };
            var P3 = new Product() { Code = 2, Name = "Algo 2" };
            var P4 = new Product() { Code = 3, Name = "Algo 4" };

            Items.AddRange(new[]
            {
                P1 , P2 , P3 , P4
            });

            ItemsInt.AddRange(new[]
            {
                P2 , P3
            });

            Numbers.AddRange(new[]
            {
                1, 2, 3, 4
            });

            NumbersInt.AddRange(new[]
            {
                4
            });
        }

        public void Run()
        {
            var intersect = Numbers.Intersect(NumbersInt);
            var intersectBy = Items.IntersectBy(ItemsInt.Select(x => x.Code),  (item) => item.Code);
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Intersect Numbers -> [{0}]", string.Join(',', intersect)));
            builder.AppendLine(String.Format("IntersectBy Code -> [{0}]", string.Join(',', intersectBy.Select(x => x.Code))));
            Console.WriteLine(builder.ToString());
        }
    }
}
