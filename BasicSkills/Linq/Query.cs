using BasicSkills.Base;
using BasicSkills.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    public class Query : Base<Product>, IRunnable
    {
        PetOwner[] petOwners =
        {
            new PetOwner {
                Name="Higa",
                Pets = new List<string>{ "Scruffy", "Sam" }
            },
            new PetOwner {
                Name="Ashkenazi",
                Pets = new List<string>{ "Walker", "Sugar" }
            },
            new PetOwner {
                Name="Higa",
                Pets = new List<string>{ "Scratches", "Diesel" }
            },
            new PetOwner {
                Name="Hines",
                Pets = new List<string>{ "Dusty" }
            }
        };

        public Query()
        {
            Items.AddRange(new[]
            {
                new Product() {Code = 0, Name = "Jugo"},
                new Product() {Code = 1, Name = "Pelota"},
                new Product() {Code = 2, Name = "Jugo"},
                new Product() {Code = 3, Name = "Mouse"},
                new Product() {Code = 0, Name = "Juego"},
            });
        }

        public async Task Run()
        {
            var query = (
                from item in Items
                where item.Code % 2 == 0
                select new
                {
                    Name = item.Name,
                    CodexName = $"{item.Code}. {item.Name}"
                }
            );
            var queryOrderBy = (
                from item in Items
                where item.Code % 2 == 0 && item.Code > -1
                orderby item.Code descending
                select new
                {
                    Name = item.Name,
                    CodexName = $"{item.Code}. {item.Name}"
                }
            );
            var count = (
                from item in Items
                where item.Code % 2 == 0 && item.Code > -1
                orderby item.Code descending
                select new
                {
                    Name = item.Name,
                    CodexName = $"{item.Code}. {item.Name}"
                }
            ).Count();
            var max = (
                from item in Items
                where item.Code % 2 == 0 && item.Code > -1
                orderby item.Code descending
                select new
                {
                    Code = item.Code,
                    Name = item.Name,
                    CodexName = $"{item.Code}. {item.Name}"
                }
            ).Max(item => item.Code);
            var groupBy = (
                from item in petOwners
                where item.Name.Length > 1
                group item by item.Name into g
                orderby g.Count() ascending
                select new
                {
                    Owner = g.Key,
                    PetsNumber = g.Count(),
                    OwnerxPet = $"{g.Count()} of {g.Key}"
                }
                
            );
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Query -> [{0}]", string.Join(',', query.Select(item => item.CodexName))));
            builder.AppendLine(String.Format("QueryOrderBy -> [{0}]", string.Join(',', queryOrderBy.Select(item => item.CodexName))));
            builder.AppendLine(String.Format("QueryCount -> {0} Rows", count));
            builder.AppendLine(String.Format("QueryMax -> {0}", max));
            builder.AppendLine(String.Format("QueryGroupBy -> [{0}]", string.Join(',', groupBy.Select(item => item.OwnerxPet))));
            Console.WriteLine(builder.ToString());
        }
    }
}
