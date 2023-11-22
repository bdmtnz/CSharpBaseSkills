using BasicSkills.Base;
using BasicSkills.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSkills.Linq
{
    class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }

    public class Select : Base<Product>, IRunnable
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
                Name="Price",
                Pets = new List<string>{ "Scratches", "Diesel" } 
            },
            new PetOwner { 
                Name="Hines",
                Pets = new List<string>{ "Dusty" } 
            } 
        };

        public Select()
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
            var select = Items.Select(x => x.Name);
            var selectMany = petOwners.SelectMany(
                item => item.Pets,
                (item, pet) => new
                {
                    PetOwnerNames = $"{item.Name} - {pet}"
                }
            );
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("Select -> [{0}]", string.Join(',', select)));
            builder.AppendLine(String.Format("SelectMany -> [{0}]", string.Join(',', selectMany.Select(x => x.PetOwnerNames))));
            Console.WriteLine(builder.ToString());
        }
    }
}
