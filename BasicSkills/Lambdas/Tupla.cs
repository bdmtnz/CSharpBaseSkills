using BasicSkills.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Lambdas
{
    public class Tupla : IRunnable
    {
        Func<(int n1, int n2, int n3), (int, int, int)> DoubleThem { get; set; }

        public Tupla() {
            DoubleThem = ns => (2 * ns.n1, 2 * ns.n2, 2 * ns.n3);
        }

        public async Task Run()
        {
            var numbers = (2, 3, 4);
            var doubledNumbers = DoubleThem(numbers);
            Console.WriteLine($"The set {numbers} doubled: {doubledNumbers}");
        }
    }
}
