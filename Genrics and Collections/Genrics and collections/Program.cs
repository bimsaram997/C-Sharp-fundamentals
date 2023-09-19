using System;
using System.Collections.Generic;
using Genrics_and_collections.@class;

namespace Genrics_and_collections
{

    class Program
    {
        public static void Main(string[] args)
        {
            /*Generics 
            GenericList<int> intList = new GenericList<int>();
            intList.Add(1);
            intList.Add(2);
            int item = intList.GetItem(0); // item is of type int

            GenericList<string> stringList = new GenericList<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            string itemString = stringList.GetItem(0);

            Console.WriteLine(itemString + " " + item);*/

            //Arrays
            Employee[] employees = new Employee[]
            {
                new Employee("bimsara"),
                new Employee("Scot")
            };

            foreach (Employee employee in employees)
            {
                // Console.WriteLine(employee.Name);
            }

            //List

            List<Employee> employeelist = new List<Employee>();
            employeelist.Add(new Employee("Bimsara"));
            employeelist.Add(new Employee("John"));
            employeelist.Add(new Employee("Scot"));
            employeelist.Add(new Employee("Asanga"));
            employeelist.Add(new Employee("Hirushan"));
            employeelist.Add(new Employee("Isuru"));
            employeelist.Add(new Employee("Amila"));
            Console.WriteLine(employeelist.Count);
            employeelist.Remove(employeelist[0]);

            Employee bimsaraEmployee = employeelist.FirstOrDefault(employee => employee.Name == "Bimsara");
            if (bimsaraEmployee != null)
            {
                employeelist.Remove(bimsaraEmployee);
            }
            employeelist.Sort((employee1, employee2) => string.Compare(employee1.Name, employee2.Name));

            //using LINQ 
            bool containsBimsara = employeelist.Any(employee => employee.Name == "Amila");
            // using cusotm equality comparer
            bool isExist = employeelist.Contains(new Employee("Hirushan"));

            //Index
            int index = employeelist.IndexOf(new Employee("Amila"));
            //Index using lamba expression
            int indexLam = employeelist.FindIndex(employee => employee.Name == "Amila");

            employeelist.ForEach(employee =>
            {
                Console.WriteLine(employee.Name);
            });

            Console.WriteLine("Queue.....................");

            Queue<Employee> queue = new Queue<Employee>();
            queue.Enqueue(new Employee("John"));
            queue.Enqueue(new Employee("Loggy"));
            queue.Enqueue(new Employee("Micheal"));

            Console.WriteLine(queue.Peek().Name);

            while (queue.Count > 0)
            {
                var emp = queue.Dequeue();
                Console.WriteLine(emp.Name);
            }



            Console.WriteLine("Stack.....................");

            Stack<Employee> stack = new Stack<Employee>();
            stack.Push(new Employee("Romain"));
            stack.Push(new Employee("Jolly"));
            stack.Push(new Employee("Linna"));

            Console.WriteLine(stack.Peek().Name);

            while (stack.Count > 0)
            {
                var emp = stack.Pop();
                Console.WriteLine(emp.Name);
            }

            Console.WriteLine("Hash set with primary type.....................");
            HashSet<int> hashPrimary = new HashSet<int>();
            hashPrimary.Add(1);
            hashPrimary.Add(2);

            foreach (int item in hashPrimary)
            {
                System.Console.WriteLine(item);
            }

            Console.WriteLine("Hash set with refence type.....................");
            HashSet<Employee> hashReference = new HashSet<Employee>();
            hashReference.Add(new Employee("Dewa"));
            hashReference.Add(new Employee("Gimaths"));
            hashReference.Add(new Employee("Gimaths"));
            // hashReference.Remove(new Employee("Gimaths"));
            foreach (Employee item in hashReference)
            {
                System.Console.WriteLine(item.Name);
            }

             Console.WriteLine("Linekd list with primary type.....................");
        LinkedList<int> myList = new LinkedList<int>();
        myList.AddFirst(1);
        myList.AddLast(2);
        myList.AddFirst(0);
        myList.AddFirst(3);

        foreach (var item in myList)
        {
            System.Console.WriteLine(item);
        }
        Console.WriteLine("Dictionery.....................");
        Dictionary<string, Employee> dict =  new Dictionary<string, Employee>();
        dict.Add("Alice", new Employee("Alice"));
         dict.Add("Alex", new Employee("Alex"));
         dict["George"] = new Employee("George");

         foreach (var item in dict)
         {
            System.Console.WriteLine("{0} : {1}", item.Key, item.Value.Name);
         }

        Console.WriteLine("Dictionery by list.....................");
        Dictionary<string, List<Employee>> employyeByDepartment = new Dictionary<string, List<Employee>>();

        // Create a list of employees for the "Engineering" department
        List<Employee> engineeringEmployees = new List<Employee>
        {
     
            new Employee("Scott"),
            new Employee("Alice"),
            new Employee("Bob")
        };

        // Add the list of employees to the dictionary under the "Engineering" key
        employyeByDepartment["Engineering"] = engineeringEmployees;

        // You can add more departments and employees in a similar way

        // Iterate through the dictionary
        foreach (var department in employyeByDepartment)
        {
            Console.WriteLine($"Employees in the {department.Key} department:");

            foreach (var emp in department.Value)
            {
                Console.WriteLine(emp.Name);
            }
        }
        {
            
        }
        }

        

}
}