using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoggerManager loggerManager = new LoggerManager(new LocalLog4Net());
            loggerManager.Save();
            Console.ReadLine();
        }
    }

    //ADAPTER DESIGN PATTERNİ YERE OLMAYAN DIŞARIDAN EKLENEN BİR SERVİSİN KENDİ SERVİSLERİMİZE ADABTE EDİLMESİ İŞİNE YARAR.
    //BU PATTERNDE DIŞARIDAN GELEN SINIFA BAĞLI KALMAMAK VE O SERVİSİ KENDİ SERVİSİMİZ GİBİ KULLANABİLMEK İÇİN O CLASS KENDİ
    //İNTERFACE LERİMİZ İLE UYUMLU OLACAK ŞEKİLDE BAŞKA BİR CLASSTA OLUŞTURMAMIZ GEREKMEKTEDİR.
    //BU SAYEDE SERVİSİ İSTEDİĞİMİ GİBİ YÖNETEBİLİR VE LOCAL SERVİS HALİNE ÇEVİRMİŞ OLABİLİRİZ.


    public class LoggerManager
    {
        private Ilogger _logger;
        public LoggerManager(Ilogger ılogger)
        {
            _logger = ılogger;
        }

        public void Save()
        {
            _logger.Log(_logger.ToString());
        }
    }

    public class LocalLogger : Ilogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged with {0}",message);
        }
    }

    public interface Ilogger
    {
        void Log(string message);
    }

    public class LocalLog4Net : Ilogger
    {
        Log4Net log4net;
        public void Log(string message)
        {
            log4net = new Log4Net();
            log4net.Log4NetLog("Log4ForNet");
        }
    }

    public sealed class Log4Net
    {
        public void Log4NetLog(string massage)
        {
            Console.WriteLine("Log with {0}", massage);
        }
    }
}
