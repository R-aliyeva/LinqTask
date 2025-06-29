using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LinqTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var people = new List<Person>
{   new Person(1, "Elvin", "Məmmədov", 31, "Bakı"),
    new Person(2, "Aysel", "Əliyeva", 28, "Gəncə"),
    new Person(3, "Tural", "Hüseynov", 35, "Sumqayıt"),
    new Person(4, "Nigar", "Quliyeva", 26, "Lənkəran"),
    new Person(5, "Kamran", "Rzayev", 40, "Şəki"),
    new Person(6, "Sevda", "İsmayılova", 22, null),
    new Person(7, "Murad", "Qasımov", 29, "Quba"),
    new Person(8, "Günel", "Səfərova", 33, "Mingəçevir"),
    new Person(9, "Rəşad", "Baxşəliyev", 38, "Mingəçevir"),
    new Person(10, "Zəhra", "Əhmədova", 25, "Mingəçevir")
};
            var peopleFiletred = people.Where(x => x.Age > 30).ToList();
            //foreach (var item in peopleFiletred)
            //{
            //    Console.WriteLine($"{item.LastName} {item.FirstName} {item.Age}");
            //}

            var peopleProjection = people.Select(x => new { fullname = x.FirstName + " " + x.LastName, x.Age }).ToList();

            //foreach (var item in peopleProjection)
            //{
            //    Console.WriteLine($"{item.fullname}  {item.Age}");
            //}

            //Group persons by City.

            var peopleGroupByCity = people.Where(p => p.City != null)
                .GroupBy(x => x.City);


            //foreach (var item in peopleGroupByCity)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var item1 in item)
            //    {
            //        Console.WriteLine($"{item1.FirstName} {item1.LastName}");
            //    }

            //}
            // Order the list of persons by age in descending order.

            var peopleOrdered = people.OrderByDescending(x => x.Age).ToList();
            //foreach (var item in peopleOrdered)
            //{
            //    Console.WriteLine($"{item.FirstName}+{item.Age}");
            //}
            //Find the average age of all persons.

            var peopleAvarge = people.Average(x => x.Age);
            //Console.WriteLine(peopleAvarge.ToString());

            //Find the first person who lives in &quot; Baku & quot;.

            var peopleSelected = people.FirstOrDefault(x => x.City == "Bakı");

            // Console.WriteLine($"{peopleSelected.FirstName}+{peopleSelected.Age}+{peopleSelected.City}");
            var skipTake = people.Skip(3).Take(5);

        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public Person()
        {

        }

        public Person(int id, string firstName, string lastName, int age, string? city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            City = city;
        }
        public override string ToString()
        {
            return $"{Id},{FirstName},{LastName},Age-{Age},city-{City}";
        }
    }
    public static class Extensions 
    { 
       // public static T? FirstOrDefault<T>(this T? value, T defaultValue) where T : class




    }
}
