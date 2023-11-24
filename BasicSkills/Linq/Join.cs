using BasicSkills.Base;
using BasicSkills.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Join : Base<Product>, IRunnable
    {
        public List<Store> Stores { get; set; } = new List<Store>();

        public Join() : base()
        {
            var P1 = new Product() { Code = 0, Name = "Algo 0" };
            var P2 = new Product() { Code = 1, Name = "Algo 1" };
            var P3 = new Product() { Code = 2, Name = "Algo 2" };
            var P4 = new Product() { Code = 1, Name = "Algo 4" };

            Items.AddRange(new[]
            {
                P1 , P2 , P3 , P4
            });

            Stores.AddRange(new[]
            {
                new Store() {Code = 0, Name = "Galaxy Store", Product = P1},
                new Store() {Code = 0, Name = "Apple Store", Product = P2},
                new Store() {Code = 0, Name = "Xiaomi Store", Product = P1},
                new Store() {Code = 0, Name = "Galaxy Store", Product = P3},
                new Store() {Code = 0, Name = "Sony Store", Product = P4}
            });
        }

        public async Task Run()
        {
            var join = Items.Join(
                 Stores,
                 product => product,
                 store => store.Product,
                 (product, store) =>
                 {
                     return new
                     {
                         Producto = product.Name,
                         Store = store.Name,
                         ProductStore = $"{store.Name} {product.Name}",
                     };
                 }
             );

            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Join store products -> [{0}]", string.Join(',', join.Select(item => item.ProductStore))));
            Console.WriteLine(builder.ToString());
        }
    }
}
