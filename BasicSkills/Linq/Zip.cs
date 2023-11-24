using BasicSkills.Base;
using BasicSkills.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Zip : Base<int>, IRunnable
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public Zip() : base()
        {
            Items.AddRange(new[]
            {
                6, 1, 2, 3
            });

            var P1 = new Product() { Code = 0, Name = "Algo 0" };
            var P2 = new Product() { Code = 1, Name = "Algo 1" };
            var P3 = new Product() { Code = 2, Name = "Algo 2" };
            var P4 = new Product() { Code = 1, Name = "Algo 4" };

            Products.AddRange(new[]
            {
                P1 , P2 , P3 , P4
            });
        }

        public async Task Run()
        {
            var zip = Items.Zip(Products, (item, product) =>
            {
                return new
                {
                    productCode = product.Code,
                    productName = product.Name,
                    Number = item,
                    productxNumber = $"{item}. {product.Name}"
                };
            });
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Zip -> [{0}]", string.Join(',', zip.Select(item => item.productxNumber))));
            Console.WriteLine(builder.ToString());
        }
    }
}
