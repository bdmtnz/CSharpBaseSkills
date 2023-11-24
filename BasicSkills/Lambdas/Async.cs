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
    internal class Async : Base<Product>, IRunnable
    {
        public Action<int, string> Lambda { get; set; }

        public Async() : base()
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

        public async Task Run()
        {
            var asyncLambda = MethodAsync;
            await asyncLambda();
        }

        private async Task MethodAsync()
        {
            // The following line simulates a task-returning asynchronous process.
            Console.WriteLine("Text before delay");
            await Task.Delay(1000);
            Console.WriteLine("Text after delay");
        }
    }
}
