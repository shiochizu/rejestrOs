using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace rejestrOs
{
    internal class AddCommand : ICommand
    {
        public void Execute()
        {

            var json = File.ReadAllText(@"people.json");
            var people = JsonConvert.DeserializeObject<ICollection<Person>>(json);


            Person person = new Person();
            PropertyInfo[] propertyInfos = typeof(Person).GetProperties();
            foreach (var info in propertyInfos)
            {
                Console.Write(info.Name +": ");
                string value = Console.ReadLine();
                info.SetValue(person, Convert.ChangeType(value, info.PropertyType));
            }
            people.Add(person);

            File.WriteAllText(@"people.json", JsonConvert.SerializeObject(people));
        }
        
    }
}