using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace rejestrOs
{
    internal class RemoveCommand : ICommand
    {
        public void Execute()
        {
            var json = File.ReadAllText(@"people.json");
            var people = JsonConvert.DeserializeObject<List<Person>>(json);

            Console.WriteLine("People in the collection:");
            foreach (var item in people)
            {
                
                Console.WriteLine($"{people.IndexOf(item)} | {item.FirstName} {item.LastName} {item.Gender} {item.PostCode} {item.City} {item.Street} {item.HouseNumber}");
            }
            Console.WriteLine("Select the index od the person to remove from the collection:");
            int number;
            bool success = int.TryParse(Console.ReadLine(), out number);
            if (success == true && number <= people.Count +1)
            {
                people.RemoveAt(number);
                Console.WriteLine("person removed!");
            }
            else
            {
                Console.WriteLine("Could not remove person with that index!");
            }

            File.WriteAllText(@"people.json", JsonConvert.SerializeObject(people));
        }
    }
}