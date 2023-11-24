using BasicSkills.Base;
using BasicSkills.Comparers;
using BasicSkills.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Lambdas
{
    internal class Instruction : Base<Product> , IRunnable
    {
        public Func<int, string, int> Lambda { get; set; }
        public Func<int, string, string> LambdaMultiline { get; set; }

        public Instruction() : base()
        {
            Items.AddRange(new[]
            {
                new Product() {Code = 0, Name = "Jugo"},
                new Product() {Code = 1, Name = "Pelota"},
                new Product() {Code = 0, Name = "Jugo"},
                new Product() {Code = 2, Name = "Mouse"},
            });
            Lambda = (n, s) => n * s.Length;
            LambdaMultiline = (n, s) =>
            {
                var concat = $"{n}. {s}";
                return concat;
            };
        }

        public async Task Run()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("Lambda {0}", new object[] { Lambda(2, "Lol") }));
            builder.AppendLine(string.Format("Lambda multiline {0}", new object[] { LambdaMultiline(2, "Lol") }));
            builder.AppendLine(string.Format("Select lambda [{0}]", new object[] { string.Join(",", Items.Select(item => item.Name)) }));
            Console.WriteLine(builder.ToString());
        }
    }
}
