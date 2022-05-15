using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccesor(vicePresident);
            vicePresident.SetSuccesor(president);

            Expense expense = new Expense();
            expense.Detail = "Hotel";
            expense.Amount=863;
            manager.HandleExpense(expense);

            Console.ReadLine();
        }
    }
    //Adı üstünde sorumluluk zinciri kalıbıdır
    //yapılacak olan işlemi base abstract classta tanımladıktan sonra onu yapabilcek her bussines classına yetki sınır vermekye benzer
    //bu base clasta bunun için kendi tipinden bir değişkenler tanımlanan base clasın değiştirilmesi ve üst yetkili clasa devredilmesi sağlanır.


    class Expense
    {
        public string Detail { get; set; }
        public int Amount { get; set; }

    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Succesor;
        public abstract void HandleExpense(Expense expense);
        public void SetSuccesor(ExpenseHandlerBase expenseHandler)
        {
            Succesor = expenseHandler;
        }
    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <=100)
            {
                Console.WriteLine("Manager Handled the expense");
            }
            else if (Succesor!=null)
            {
                Succesor.HandleExpense(expense);
            }
        }
    }
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<=1000)
            {
                Console.WriteLine("VicePresident Handled the expense");
            }
            else if (Succesor != null)
            {
                Succesor.HandleExpense(expense);
            }
        }
    }
    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount> 1000)
            {
                Console.WriteLine("President Handled the expense");
            }
            
        }
    }
}
