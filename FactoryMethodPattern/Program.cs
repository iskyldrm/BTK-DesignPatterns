using System;

namespace FactoryMethodPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deneme");

            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            
        }
    }

    class LoggerFactory : ILoggerFactory    //Factory Methodda clas bağımlılığının önüne geçmek için nesne üretimi ortak bir kanaldan yapılır.
    {                                       //Bu kanala bestpractice olarak factory eklenir ismine
                                            //Bu fabrika bize istediğimiz türden nesneyi üretip verir
                                            //bu üretilecek nesneler class olmalı abstract class olmaları dışında başka konu giriyor işin içine
        public ILogger CreatLogger()        
        {
            return new IyLogger();
        }
    }
    class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreatLogger()
        {
            return new OcLogger();
        }
    }

    public interface ILogger
    {
        void log();
    }

    public interface ILoggerFactory
    {
        public ILogger CreatLogger();
    }

    class IyLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("loged with IyLogger");
        }
    }


    class OcLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("loged witg OcLogger");
        }
    }
    public class CustomerManager
    {
        private ILoggerFactory _Iloggerfactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _Iloggerfactory = loggerFactory;    
        }
        public void Save()
        {
            Console.WriteLine("Kaydedildi");
            ILogger logger =_Iloggerfactory.CreatLogger();
            logger.log();
            
        }
    }
}
