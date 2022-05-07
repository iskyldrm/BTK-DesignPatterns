using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer() { Id=1,Adi="isak",SoyAdi="yıldırım",City="erzincan"};

            Customer customer1 = (Customer)customer.Clone();
            customer1.Adi = "adil";
            Console.WriteLine(customer.Adi.ToString());
            Console.WriteLine(customer1.Adi.ToString());
            Console.ReadLine();

        }
    }

    public abstract class Person
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string SoyAdi { get; set; }

        public abstract Person Clone();
    }


    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
