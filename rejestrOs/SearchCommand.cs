using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rejestrOs
{
    internal class SearchCommand : ICommand
    {
        public void Execute()
        {

            var json = File.ReadAllText(@"people.json");
            var people = JsonConvert.DeserializeObject<ICollection<Person>>(json);
            Console.WriteLine("Enter search query:");
            string searchStr = Console.ReadLine();

           
            var sList = people.Where(x => x.GetType().GetProperties().Any(p => { var value = p.GetValue(x); return value != null && value.ToString().Contains(searchStr); }));
            Console.WriteLine("Results:");
            if (sList.Count() == 0) Console.WriteLine("No matches found");
            foreach ( var item in sList)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Gender} {item.PostCode} {item.City} {item.Street} {item.HouseNumber}");
            }
            

        }

    }
}