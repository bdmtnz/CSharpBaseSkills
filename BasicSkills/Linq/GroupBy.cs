using BasicSkills.Base;
using BasicSkills.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Store
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }
    }

    public class GroupBy : Base<Product>, IRunnable
    {
        public List<Store> Stores { get; set; } = new List<Store>();

        public GroupBy() : base()
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

        public void Run()
        {
            var groupBy = Items.GroupBy(
                item => item.Code,
                item => item.Name,
                (code, names) => new
                {
                    Code = code,
                    NamesCount = names.Count(),
                    Names = string.Join(" ", names)
                }
            );
            var groupJoin = Items.GroupJoin(
                Stores,
                product => product,
                store => store.Product,
                (product, stores) =>
                {
                    return new
                    {
                        Producto = product.Name,
                        TiendasCount = stores.Count(),
                        ProductStore = $"{stores.Count()} {product.Name}",
                        Tiendas = string.Join(" ", stores.Select(x => x.Name))
                    };
                }
            );

            var builder = new StringBuilder();
            builder.AppendLine(String.Format("GroupBy products -> [{0}]", string.Join(',', groupBy.Select(item => item.Names))));
            builder.AppendLine(String.Format("GroupJoin products x stores -> [{0}]", string.Join(',', groupJoin.Select(item => item.ProductStore))));
            Console.WriteLine(builder.ToString());
        }
    }
}
