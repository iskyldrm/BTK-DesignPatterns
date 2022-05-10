using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person people = new Person { Name="isak yıldırım"};
            Person people1 = new Person { Name = "adil yıldırım" };
            people.AddSubOrdinates(people1);

            Person people2 = new Person { Name = "ali kaya" };
            people1.AddSubOrdinates(people2);
            Person people3 = new Person { Name = "oguz coğ" };
            people1.AddSubOrdinates(people3);
            Person people4 = new Person { Name = "kaya yaadar" };
            people.AddSubOrdinates(people4);
            Person people5 = new Person { Name = "deniz yıldız" };
            Person people6 = new Person { Name = "ahmet kaya" };
            people4.AddSubOrdinates(people6);
            people4.AddSubOrdinates(people5);


            Console.WriteLine("     {0}",people.Name);
            foreach (Person manager in people)
            {
                Console.WriteLine(" {0}",manager.Name);

                foreach (Person item in manager)
                {
                    Console.WriteLine("    {0}",item.Name);
                }
            }

            Console.ReadLine(); 
            
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Person : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordiantes = new List<IPerson>();

        public void AddSubOrdinates(IPerson person)
        {
            _subordiantes.Add(person);
        }
        public void RemoveSubOrdinates(IPerson person)
        {
            _subordiantes.Remove(person);
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var suborinates in _subordiantes)
            {
                yield return suborinates;
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
