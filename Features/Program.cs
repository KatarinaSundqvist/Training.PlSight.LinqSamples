//using Features.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Features {
    class Program {
        static void Main(string[] args) {

            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;

            Action<int> write = x => Console.WriteLine(x);

            write(square(add(3, 5)));

            var developers = new Employee[] {
                new Employee { Id = 1, Name = "Scott" },
                new Employee { Id = 2, Name = "Chris" },
            };

            var sales = new List<Employee>() {
                new Employee { Id = 3, Name = "Alex" }
            };

            //Console.WriteLine(developers.Count());

            // METHOD SYNTAX
            var query = developers.Where(e => e.Name.Length == 5)
                                                .OrderBy(e => e.Name)
                                                .Select(e => e); // this line is optional

            // QUERY SYNTAX
            var query2 = from developer in developers
                         where developer.Name.Length == 5
                         orderby developer.Name
                         select developer;


            foreach (var employee in query) {
                Console.WriteLine(employee.Name);
            }

            foreach (var employee in query2) {
                Console.WriteLine(employee.Name);
            }


            //    // longer way to write a foreach, essentially doing it yourself
            //    IEnumerator<Employee> enumerator = developers.GetEnumerator();
            //    while (enumerator.MoveNext()) {
            //        Console.WriteLine(enumerator.Current.Name);
            //    }
        }

    }
}
