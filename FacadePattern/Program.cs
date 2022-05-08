using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Save();
            Console.ReadLine();
        }
    }

    //Facade design pattern eğer bir kaç nesnenin aynı anda üretilip kullanılması gerekiyorsa bu durumda
    //CCC de üretilip manager sınıfına öyle çağrılması gerekir.
    //bu sayade üretilen CCC SINIF İÇİNDE NE VARSA İSTEDİĞİMİZ GİBİ KULLANABİLİRZ.
    //eğer sonra başla bir sınıf daha üretilmesi gerekiyorsa o sınıf nesnesini CCC SINIFINA EKLEMEMİZ YETERLİ OLACAKTIR.

    public class Logging : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }
    public interface ILogger
    {
        void Log();
    }

    public class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }
    public interface ICaching
    {
        void Cache();
    }

    public class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Checked");
        }
    }
    public interface IAuthorize
    {
        void CheckUser();
    }


    public class ProductManager
    {
        private CrossCutingConsernsFacade _facade;
        public ProductManager()
        {
            _facade = new CrossCutingConsernsFacade();
        }

        public void Save()
        {
            _facade.Logger.Log();
            _facade.Caching.Cache();
            _facade.Authorize.CheckUser();
            Console.WriteLine("Saved");
        }
    }

    public class CrossCutingConsernsFacade
    {
        public ILogger Logger;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCutingConsernsFacade()
        {
            Logger = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
}
