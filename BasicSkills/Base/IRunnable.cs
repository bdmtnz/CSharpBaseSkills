using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Base
{
    public interface IRunnable
    {
        Task Run();
    }

    public interface IRunnable<T, D>
    {
        void Run(T param);
        D RunReturn(T param);
    }
}
