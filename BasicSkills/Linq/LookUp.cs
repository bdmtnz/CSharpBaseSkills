using BasicSkills.Base;
using BasicSkills.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class LookUp : Base<Product>, IRunnable
    {
        public LookUp() : base()
        {
            Items.AddRange(new[]
            {
                new Product() {Code = 0, Name = "Jugo"},
                new Product() {Code = 1, Name = "Pelota"},
                new Product() {Code = 0, Name = "Jugo"},
                new Product() {Code = 2, Name = "Mouse"},
            });
        }

        public void Run()
        {
            var lookUp = Items.ToLookup(item => item.Code);
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("LookUp -> [{0}]", string.Join(',', lookUp.Select(item => item.OfType<Product>().FirstOrDefault().Code))));
            Console.WriteLine(builder.ToString());
        }
    }
}
