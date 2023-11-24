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
    internal class Async : IRunnable
    {
        public Async() : base() { }

        public async Task Run()
        {
            var asyncLambda = async () =>
            {
                var asyncMethod = MethodAsync;
                await asyncMethod();
            };
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
