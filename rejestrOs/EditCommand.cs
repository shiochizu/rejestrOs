using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace rejestrOs
{
    internal class EditCommand : ICommand
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
            Console.WriteLine("Select the index od the person to edit:");
            int number;
            bool success = int.TryParse(Console.ReadLine(), out number);
            if (success == true && number <= people.Count + 1)
            {
                //people.RemoveAt(number);
                PropertyInfo[] propertyInfos = typeof(Person).GetProperties();
                foreach (var info in propertyInfos)
                {
                    Console.Write(info.Name + ": ");
                    string value = Console.ReadLine();
                    if(!String.IsNullOrEmpty(value) )
                    {
                        info.SetValue(people.ElementAt(number), Convert.ChangeType(value, info.PropertyType));

                    }

                }
                Console.WriteLine("person edited!");


            
            
            }
            else
            {
                Console.WriteLine("Could not edit person with that index!");
            }

            File.WriteAllText(@"people.json", JsonConvert.SerializeObject(people));
        }
    }
}