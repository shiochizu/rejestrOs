using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rejestrOs
{
    internal class ListCommand : ICommand
    {
        public void Execute()
        {
            var json = File.ReadAllText("people.json");
            var people = JsonConvert.DeserializeObject<ICollection<Person>>(json);

            Console.WriteLine("Results:");
            if (people.Count() == 0) Console.WriteLine("No matches found");
            foreach (var item in people)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Gender} {item.PostCode} {item.City} {item.Street} {item.HouseNumber}");
            }

        }
    }
}