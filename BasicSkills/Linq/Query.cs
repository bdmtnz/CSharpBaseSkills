using BasicSkills.Base;
using BasicSkills.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Query : Base<Product>, IRunnable
    {
        public Query()
        {
            Items.AddRange(new[]
            {
                new Product() {Code = 0, Name = "Jugo"},
                new Product() {Code = 1, Name = "Pelota"},
                new Product() {Code = 2, Name = "Jugo"},
                new Product() {Code = 3, Name = "Mouse"},
            });
        }

        public void Run()
        {
            var query = (
                from item in Items
                where item.Code % 2 == 0
                select new
                {
                    Name = item.Name,
                    CodexName = $"{item.Code}. {item.Name}"
                }
            );
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Query -> [{0}]", string.Join(',', query.Select(item => item.CodexName))));
            Console.WriteLine(builder.ToString());
        }
    }
}
