using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new NhProductDal());
            productManager.Save();


            Console.ReadLine();  
        }
    }
    public interface IProductDAL
    {
        void Save();
    }

    public class ProductDAL:IProductDAL
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF");
        }
    }

    public class NhProductDal : IProductDAL
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh");
        }
    }

    public class ProductManager
    {
        private IProductDAL _productDal;

        public ProductManager(IProductDAL productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
            _productDal.Save();
        }
    }
}
