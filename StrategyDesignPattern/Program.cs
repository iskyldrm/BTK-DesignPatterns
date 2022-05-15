using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new After2010();
            customerManager.SavedCredit();

            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010 : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("2010before");
        }
    }
    class After2010 : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("2010after");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void SavedCredit()
        {
            Console.WriteLine("Customer manager bussines");
            CreditCalculatorBase.Calculate();
        }
    }
}
