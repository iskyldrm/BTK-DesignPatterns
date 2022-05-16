using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager isak = new Manager();
            isak.Name = "isak";
            isak.Salary = 1500;
            Manager Memanti = new Manager { Name= "Memati", Salary = 1500};

            Worker Kadir = new Worker { Name="kadir", Salary= 1000};
            Worker adil = new Worker { Name="adil", Salary=1000};   

            isak.subordinates.Add(Memanti);
            Memanti.subordinates.Add(Kadir);
            Memanti.subordinates.Add(adil);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(isak);
            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayRise payRise = new PayRise();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payRise);

            Console.ReadLine();
        }
    }

    public class OrganisationalStructure
    {
        public Employeebase Employee;
        public OrganisationalStructure(Employeebase employee)
        {
            Employee = employee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }

    }

    public abstract class Employeebase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    public class Manager : Employeebase
    {
        public List<Employeebase> subordinates { get; set; }    
        public Manager()
        {
            subordinates = new List<Employeebase>();   
        }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in subordinates)
            {
                employee.Accept(visitor);
            }

        }
    }
    public class Worker : Employeebase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    public abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }
    public class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1} ",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1} ", manager.Name, manager.Salary);
        }
    }

    public class PayRise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary incresad to {1} ", worker.Name, worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary incresad to {1} ", manager.Name, manager.Salary * (decimal)1.2);
        }
    }
}
