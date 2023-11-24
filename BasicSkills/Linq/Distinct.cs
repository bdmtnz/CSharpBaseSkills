using BasicSkills.Base;
using BasicSkills.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Distinct : Base<Product>, IRunnable
    {
        public Distinct() : base()
        {
            Items.AddRange(new[]
            {
                new Product() {Code = 0, Name = "Jugo"},
                new Product() {Code = 1, Name = "Pelota"},
                new Product() {Code = 0, Name = "Jugo"},
                new Product() {Code = 2, Name = "Mouse"},
            });
        }

        public async Task Run()
        {
            var distinct = Items.Distinct(new ProductComparer());
            var distinctBy = Items.DistinctBy(item => item.Name);
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Distinct -> [{0}]", string.Join(',', distinct.Select(x => x.Name))));
            builder.AppendLine(String.Format("DistinctBy -> [{0}]", string.Join(',', distinctBy.Select(x => x.Name))));
            Console.WriteLine(builder.ToString());
        }
    }
}
