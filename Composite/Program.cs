using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee {Name = "Hamit Doğan"};
            Employee employee2 = new Employee {Name = "Fatih Doğan"};

            employee1.AddSubordinate(employee2);

            Employee recep = new Employee{Name = "Recep"};
            employee1.AddSubordinate(recep);

            Contractor serif = new Contractor {Name = "Serif"};
            recep.AddSubordinate(serif);

            Employee ahmet = new Employee {Name = "Yunus"};
            employee2.AddSubordinate(ahmet);

            Console.WriteLine(employee1.Name);
            foreach (Employee manager in employee1)
            {
                Console.WriteLine("   {0}", manager.Name);

                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}", employee.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor: IPerson
    {
        public string Name { get; set; }
    }

    class Employee: IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
