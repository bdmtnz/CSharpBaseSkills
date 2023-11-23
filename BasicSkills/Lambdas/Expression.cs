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
    public class Expression : Base<Product>, IRunnable
    {
        public Action<int, string> Lambda { get; set; }

        public Expression() : base()
        {
            Items.AddRange(new[]
            {
                new Product() {Code = 0, Name = "Jugo"},
                new Product() {Code = 1, Name = "Pelota"},
                new Product() {Code = 0, Name = "Jugo"},
                new Product() {Code = 2, Name = "Mouse"},
            });
            Lambda = (n, s) =>
            {
                var r = n * s.Length;
                var line = string.Format("Lambda {0}", new object[] { r });
                Console.WriteLine(line);
            };

        }

        public void Run()
        {
            var builder = new StringBuilder();
            Lambda(2, "Lol2");
            Console.WriteLine(builder.ToString());
        }
    }
}
