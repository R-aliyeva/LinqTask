using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Tasks29._06._2025.Program;

namespace Tasks29._06._2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>
           {
                  new Order { Id = 1, CustomerName = "Alice", Amount = 150.50m, OrderDate = new DateTime(2024, 1, 15) },
                  new Order { Id = 2, CustomerName = "Bob", Amount = 89.99m, OrderDate = new DateTime(2024, 2, 10) },
                  new Order { Id = 3, CustomerName = "Alice", Amount = 200.00m, OrderDate = new DateTime(2024, 1, 25) },
                  new Order { Id = 4, CustomerName = "Charlie", Amount = 75.25m, OrderDate = new DateTime(2024, 3, 5) },
                  new Order { Id = 5, CustomerName = "Bob", Amount = 120.75m, OrderDate = new DateTime(2024, 2, 20) },
                  new Order { Id = 6, CustomerName = "Diana", Amount = 300.00m, OrderDate = new DateTime(2024, 1, 30) }
               };
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Smith", Department = "IT", Salary = 75000, Age = 28 },
                new Employee { Id = 2, Name = "Sarah Johnson", Department = "HR", Salary = 65000, Age = 32 },
                new Employee { Id = 3, Name = "Mike Wilson", Department = "IT", Salary = 85000, Age = 35 },
                new Employee { Id = 4, Name = "Emily Davis", Department = "Finance", Salary = 70000, Age = 29 },
                new Employee { Id = 5, Name = "David Brown", Department = "IT", Salary = 95000, Age = 40 },
                new Employee { Id = 6, Name = "Lisa Garcia", Department = "Marketing", Salary = 60000, Age = 26 },
                new Employee { Id = 7, Name = "Robert Taylor", Department = "Finance", Salary = 80000, Age = 38 },
                new Employee { Id = 8, Name = "Jennifer Lee", Department = "HR", Salary = 55000, Age = 24 }

            };
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25, 30 };
            //1.Cüt ədədləri süzün: Nömrələr siyahısından bütün cüt ədədləri əldə edin.
            Console.WriteLine("1.Cüt ədədləri süzün: Nömrələr siyahısından bütün cüt ədədləri əldə edin.");

            var even = numbers.Where(x => x % 2 == 0);
            even.Print();

            //2.Xüsusi hərflə başlayan şəhərlər: 'L' və ya 'T' hərfi ilə başlayan bütün şəhərləri tapın.
            Console.WriteLine("2. Xüsusi hərflə başlayan şəhərlər: 'L' və ya 'T' hərfi ilə başlayan bütün şəhərləri tapın.");
            string[] cities = { "New York", "London", "Tokyo", "Paris", "Berlin", "Sydney", "Toronto", "Mumbai", "Barcelon" };
            var specialCities = cities.Where(x => x.StartsWith("L") | x.StartsWith("T"));
            specialCities.Print();

            //3.Yüksək maaşlı işçilər: 70.000 ABŞ dollarından çox əmək haqqı olan bütün işçiləri alın.
            Console.WriteLine("3. Yüksək maaşlı işçilər: 70.000 ABŞ dollarından çox əmək haqqı olan bütün işçiləri alın.");

            var highSalaryEmployee = employees.Where(e => e.Salary > 70000).Select(x => new { x.Name, x.Salary });
            highSalaryEmployee.Print();

            //4.Gənc işçilər: 30 yaşdan kiçik işçiləri tapın.
            Console.WriteLine("4. Gənc işçilər: 30 yaşdan kiçik işçiləri tapın.");
            var youngeEmployess = employees.Where(e => e.Age < 30).Select(x => new { x.Name, x.Age });
            youngeEmployess.Print();

            //5.Kvadrat nömrələr: Rəqəmlər siyahısındakı hər nömrənin kvadratını ehtiva edən yeni siyahı yaradın.
            Console.WriteLine("5.Kvadrat nömrələr: Rəqəmlər siyahısındakı hər nömrənin kvadratını ehtiva edən yeni siyahı yaradın.");
            var sqrNumbers = numbers.Select(x => x * x);
            sqrNumbers.Print();

            //6.Şəhər uzunluğu: şəhər adlarının siyahısını, onların xarakterlərinin sayı ilə birlikdə əldə edin.
            Console.WriteLine("6. Şəhər uzunluğu: şəhər adlarının siyahısını, onların xarakterlərinin sayı ilə birlikdə əldə edin.");
            var lenghtOfCities = cities.Select(c => new { answer = c + ":" + c.Trim().Length + "character" });
            foreach (var item in lenghtOfCities)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();

            // 7.Yalnız işçi adları: Yalnız bütün işçilərin adlarını çıxarın.
            Console.WriteLine("7. Yalnız işçi adları: Yalnız bütün işçilərin adlarını çıxarın.");
            var onlyNames = employees.Select(x => x.Name);
            onlyNames.Print();

            // 8.İşçi xülasəsi: Adı, Departamenti və hesablanmış məlumatları ehtiva edən anonim obyektlər yaradın
            //əmək haqqının orta səviyyədən yuxarı olub olmadığını göstərən sahə.
            Console.WriteLine("8.İşçi xülasəsi: Adı, Departamenti və hesablanmış məlumatları ehtiva edən anonim obyektlər yaradın\r\n əmək haqqının orta səviyyədən yuxarı olub olmadığını göstərən sahə.");
            var summary = employees.Average(x => x.Salary);
            var employeeList = employees.Select(x => new { x.Name, Above_Average = x.Salary > summary ? true : false });
            employeeList.Print();

            //9.Şəhərləri əlifba sırası ilə sıralayın: Şəhərlərin siyahısını əlifba sırası ilə sıralayın.
            Console.WriteLine("9. Şəhərləri əlifba sırası ilə sıralayın: Şəhərlərin siyahısını əlifba sırası ilə sıralayın.");
            var ascCities = cities.OrderBy(x => x);
            ascCities.Print();

            //10.İşçiləri əmək haqqına görə sıralayın: İşçiləri əmək haqqına görə azalan qaydada sıralayın.
            Console.WriteLine("10. İşçiləri əmək haqqına görə sıralayın: İşçiləri əmək haqqına görə azalan qaydada sıralayın.");

            var emp = employees.OrderByDescending(x => x.Salary);
            emp.Print();
            //11. Çoxsəviyyəli çeşidləmə: İşçiləri əvvəlcə departamentə görə, sonra hər bir şöbə daxilində yaşa görə çeşidləyin.
            Console.WriteLine("11. Çoxsəviyyəli çeşidləmə: İşçiləri əvvəlcə departamentə görə, sonra hər bir şöbə daxilində yaşa görə çeşidləyin.");
            var orderedEmployee = employees.OrderBy(x => x.Department).ThenBy(x => x.Age);
            orderedEmployee.Print();
            //12. Rəqəmləri tərsinə sırala: Rəqəmləri azalan ardıcıllıqla sırala.
            Console.WriteLine("12. Rəqəmləri tərsinə sırala: Rəqəmləri azalan ardıcıllıqla sırala.");
            var descNumbers = numbers.OrderByDescending(x => x);
            descNumbers.Print();

            //13.İşçiləri şöbəyə görə qruplaşdırın: Bütün işçiləri şöbələrinə görə qruplaşdırın və ekran sayına görə
            //hər qrup.
            Console.WriteLine("13. İşçiləri şöbəyə görə qruplaşdırın: Bütün işçiləri şöbələrinə görə qruplaşdırın və ekran sayına görə\r\nhər qrup.");
            var groupOfDepartment = employees.GroupBy(x => x.Department).Select(x => new { count = x.Count(), deparment = x.Key });
            groupOfDepartment.Print();
            //14. Sifarişləri müştəriyə görə qruplaşdırın: Sifarişləri müştəri adına görə qruplaşdırın və ümumi məbləği hesablayın
            //müştəri.
            Console.WriteLine("14. Sifarişləri müştəriyə görə qruplaşdırın: Sifarişləri müştəri adına görə qruplaşdırın və ümumi məbləği hesablayın\r\nmüştəri.");
            var ordersByCustomer = orders.GroupBy(o => o.CustomerName);
            foreach (var group in ordersByCustomer)
                Console.WriteLine($"{group.Key}: ${group.Sum(o => o.Amount):F2} total");
            Console.WriteLine();
            //15.Nömrələri cüt / tək üzrə qruplaşdırın: Nömrələri cüt və tək kateqoriyalara qruplaşdırın
            Console.WriteLine("15.Nömrələri cüt / tək üzrə qruplaşdırın: Nömrələri cüt və tək kateqoriyalara qruplaşdırın");
            var groupedNumbers = numbers.GroupBy(x => x % 2 == 0 ? "even" : "odd");
            foreach (var item in groupedNumbers)
            {
                Console.WriteLine(item.Key);
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1);

                }
            }
            //16. Ortaları hesablayın: Bütün işçilərin orta əmək haqqını tapın.
            Console.WriteLine("16. Ortaları hesablayın: Bütün işçilərin orta əmək haqqını tapın.");
            var averageSalary = employees.Average(x => x.Salary);
            Console.WriteLine(averageSalary.ToString());
            Console.WriteLine();
            Console.WriteLine();
            //17. Şöbə statistikası: Hər bir şöbə üçün orta əmək haqqı və işçilərin sayını hesablayın.
            Console.WriteLine("17. Şöbə statistikası: Hər bir şöbə üçün orta əmək haqqı və işçilərin sayını hesablayın.");
            var departmentGrouped = employees.GroupBy(x => x.Department);
            foreach (var group in departmentGrouped)
            {
                Console.WriteLine($"{group.Key}:${group.Average(g => g.Salary)} average salary:{group.Count()} employee");
            }
            Console.WriteLine();
            Console.WriteLine();
            //18. Cəm və say: Bütün ədədlərin cəmini hesablayın və neçəsinin 5-dən böyük olduğunu hesablayın.
            Console.WriteLine("18. Cəm və say: Bütün ədədlərin cəmini hesablayın və neçəsinin 5-dən böyük olduğunu hesablayın.");
            var sum = numbers.Sum();
            var count = numbers.Where(n => n > 5).Count();
            Console.WriteLine($"count-{count},sum-{sum}");
            Console.WriteLine();
            Console.WriteLine();

            //19. Min/Maks əməliyyatlar: Ən gənc və ən yaşlı işçi yaşlarını tapın.
            Console.WriteLine("19. Min/Maks əməliyyatlar: Ən gənc və ən yaşlı işçi yaşlarını tapın.");
            var minemployee = employees.MinBy(x => x.Age);
            var maxemployee = employees.MaxBy(x => x.Age);
            Console.WriteLine($"Youngest: {minemployee.Age}, Oldest: {maxemployee.Age}");
            Console.WriteLine();
            Console.WriteLine();

            //20. Əməliyyatlara qoşulun: Hər bir işçinin adını formatlanmış sətirlə göstərən siyahı yaradın.
            //şöbə və əmək haqqı.
            Console.WriteLine("20. Əməliyyatlara qoşulun: Hər bir işçinin adını formatlanmış sətirlə göstərən siyahı yaradın.\r\nşöbə və əmək haqqı.\r\n");
            var listOfEmployee = employees.Select(x => new { x.Name, x.Department, x.Salary });
            listOfEmployee.Print();

            //21.Şərti seçim: İşçi adlarını alın, ancaq daha çox qazanan İT departamentinin işçiləri üçün
            //80.000 dollardan çoxdur.
            Console.WriteLine("21.Şərti seçim: İşçi adlarını alın, ancaq daha çox qazanan İT departamentinin işçiləri üçün 80.000 dollardan çoxdur.");

            var filtered = employees.Where(e => e.Department == "IT" && e.Salary > 80000);
            filtered.Print();


            //22. Kompleks filtrasiya: Adında "a" və ya "e" olan və Finance və ya İT sahəsində çalışan işçiləri tapın.

            Console.WriteLine("22. Kompleks filtrasiya: Adında \"a\" və ya \"e\" olan və Finance və ya İT sahəsində çalışan işçiləri tapın.");
            var complexFilter = employees.Where(e => (e.Name.Contains('a')|e.Name.Contains('e')) &&( e.Department== "Finance" | e.Department== "IT"));
            complexFilter.Print();


            //23.Tarixə əsaslanan sorğular: Sifarişlərdən, 2024 - cü ilin yanvar ayında verilmiş bütün sifarişləri məbləğə görə sıralanmış şəkildə əldə edin.
            //Çağırış Tapşırıqları
            Console.WriteLine("23.Tarixə əsaslanan sorğular: Sifarişlərdən, 2024 - cü ilin yanvar ayında verilmiş bütün sifarişləri məbləğə görə sıralanmış şəkildə əldə edin.\r\n");
            var orderByDateOrders = orders.OrderBy(o => o.Amount).Where(o => o.OrderDate <new DateTime (2024, 1, 31) && o.OrderDate >new DateTime(2024, 1, 1));
            foreach (var item in orderByDateOrders)
            {
                Console.WriteLine($"{item.CustomerName}:${item.Amount},{item.OrderDate}");
            }


            //24.Ən yaxşı ifaçılar: Hər şöbədən ən yüksək maaş alan 3 işçini əldə edin.
            Console.WriteLine("24.Ən yaxşı ifaçılar: Hər şöbədən ən yüksək maaş alan 3 işçini əldə edin.");
            var bestEmployees = employees.GroupBy(e => e.Department);
          
            foreach(var employee in bestEmployees)
            { 
            Console.WriteLine($"{employee.Key}:");
                var result = employee.OrderByDescending(e => e.Salary).Take(3);
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Name}:${item.Salary}");
                }
                }

            //25.Müştəri təhlili: Hər bir müştəri üçün onların ümumi sifariş sayını, xərclənən ümumi məbləği və göstərin
            //orta sifariş dəyəri.
            Console.WriteLine("Hər bir müştəri üçün onların ümumi sifariş sayını, xərclənən ümumi məbləği və göstərin orta sifariş dəyəri.");
            var customerGroupBy = orders.GroupBy(o => o.CustomerName);
            foreach (var customer in customerGroupBy)
            {
                

            
            }

            //26.Kompleks toplama: Orta əmək haqqının ümumi şirkətdən yuxarı olduğu şöbələri tapın
            //orta.
            //27.Zəncirləmə əməliyyatları: İT departamentində ikinci ən yüksək maaşı tapın.
            //28.Xüsusi müqayisə: Eyni şöbədə işləyən, lakin fərqli maaşları olan işçiləri tapın


        }







        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }
            public int Age { get; set; }
            public override string ToString()
            {
                return $"{Id}:{Name}-{Salary}-{Department}-{Age}";

            }
            
        }
        public class Order
        {
            public int Id { get; set; }
            public string CustomerName { get; set; }
            public decimal Amount { get; set; }
            public DateTime OrderDate { get; set; }
        }
    }
    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
