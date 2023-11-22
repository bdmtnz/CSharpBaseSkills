using BasicSkills.Base;
using BasicSkills.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class ToDictionary : Base<Product>, IRunnable
    {
        public ToDictionary() : base()
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
            var dictionary = Items.ToDictionary(item => item.Code);
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Zip -> [{0}]", string.Join(',', dictionary.Select(item => $"{item.Key}: {item.Value.Name}"))));
            Console.WriteLine(builder.ToString());
        }
    }
}
