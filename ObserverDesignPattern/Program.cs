using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            CustomerObserver observer = new CustomerObserver();
            EmployeeObserver employeeObserver = new EmployeeObserver();
            productManager.Attact(observer);
            productManager.Attact(employeeObserver);
            productManager.Detact(observer);
            productManager.Update();
            Console.ReadLine();
        }
    }

    //Observer patterni ise bir iş classının çalışmalarını başka bir yerde kullanmak için observer olan classların bu iş
    // clasına abone edilmesidir. observer da miras alan tüm class lar iş clasında silte olarak çağrılır ve bu metodun çaışmaların
    // kullanılır

    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void Update()
        {
            Console.WriteLine("Product Price Changed");
            Notify();
        }
        public void Attact(Observer observer)
        {
            _observers.Add(observer);
        }
        public void Detact(Observer observer)
        {
            _observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var item in _observers)
            {
                item.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Customer Manager: Product Price Changed");
        }
    }
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Employee Manager: Product Price Changed");
        }
    }
}
