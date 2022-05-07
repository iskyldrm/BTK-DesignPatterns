using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new LofFactory());
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract  void Log(string message);  
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }

    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Nlogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cash(string massage);
    }

    public class MemCache : Caching
    {
        public override void Cash(string data)
        {
            Console.WriteLine("Caching wtih memcache");
        }  
    }

    public class RedisCache : Caching
    {
        public override void Cash(string data)
        {
            Console.WriteLine("Caching wtih RedisCahe");
        }
    }

    public abstract class CrossCutingConsernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCache();
    }

    public class LofFactory : CrossCutingConsernsFactory
    {
        public override Caching CreateCache()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class LofFactory2 : CrossCutingConsernsFactory
    {
        public override Caching CreateCache()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        private CrossCutingConsernsFactory _crossCutingConsernsFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCutingConsernsFactory crossCutingConsernsFactory)
        {
            _crossCutingConsernsFactory = crossCutingConsernsFactory;
            _logging = _crossCutingConsernsFactory.CreateLogger();
            _caching = _crossCutingConsernsFactory.CreateCache();
        }
        public void GetAll()
        {
            _logging.Log("");
            _caching.Cash("");
            Console.WriteLine("Pruduct Listed  ");
        }
    }
}
