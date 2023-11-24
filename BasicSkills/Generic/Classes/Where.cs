using BasicSkills.Base;
using BasicSkills.Generic.Interfaces;
using BasicSkills.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Generic.Classes
{
    public class Statement
    {
        public string Clausure { get; set; }
        public Statement() { }
    }

    public class ExtendedStatement : Statement { }

    public class Where<T> : IWhere<T> where T : Statement
    {
        public T Id { get; set; } = default;

        public T RunTask()
        {
            return Id;
        }
    }

    public class IWhereImplement : IRunnable
    {
        public Where<ExtendedStatement> ExtStatement { get; set; }
        public IWhereImplement()
        {
            ExtStatement = new Where<ExtendedStatement>()
            {
                Id = new ExtendedStatement() { Clausure = "1 = 1 and 2 <> 3" }
            };
        }

        public async Task Run()
        {
            Console.WriteLine($"Interface IWhere with where T type implement: {ExtStatement.Id.Clausure}");
        }
    }
}
