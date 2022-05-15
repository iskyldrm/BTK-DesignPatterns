using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            stockManager stockManager = new stockManager();
            buyStock buyStock = new buyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockController stockController = new StockController();
            stockController.TakeOrders(buyStock);
            stockController.TakeOrders(sellStock);
            stockController.TakeOrders(buyStock);
            stockController.PlaceOrdes();

            Console.ReadLine();
        }
    }
    class stockManager
    {
        private string _name { get; set; } = "Laptop";
        private int _quantity { get; set; } = 10;

        public void Buy()
        {
            Console.WriteLine("stock: {0}, {1} bought", _name,_quantity);
        }
        public void Sell()
        {
            Console.WriteLine("stock: {0}, {1} sold", _name, _quantity);
        }
    }
    interface IOrder
    {
        void Execute();
    }

    class buyStock:IOrder
    {
        stockManager _stockManager;
        public buyStock(stockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Buy();
        }
    }

    class SellStock : IOrder
    {
        stockManager _stockManager;
        public SellStock(stockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute()
        {
            _stockManager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();

        public void TakeOrders(IOrder order)
        {
            _orders.Add(order);
        }
        public void PlaceOrdes()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }

            _orders.Clear();
        }
    }
}
