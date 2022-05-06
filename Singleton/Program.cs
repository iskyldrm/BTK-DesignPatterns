using System;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");



            var abc = b.GetB(); // singlenton yapılmış bir classı kullanma
            abc.get();

            a.geta(); // static olan bir clası kullanma

        }

    }

    //Singleton patternde bir nesne birkez üretilir ve herkes onu kullanılır.
    //clasında dışardan erişimi kapatılır constructere private yapılarak.
    //ve kendi içinde kendi tipinden bir nesne örneği döndüren metod yazılır.
    //bu metod ifle kontrol edilir eğer üretilmemişse üretir.
    //THREAD SAFE OLARAK AYNI ANDA İKİ KİŞİ TARAFINDAN KULLANILMASINA KARŞIN NESNE NESNE ÜRETİMİ LOCK İLE KİLİTLİ NESNE YAPILIR
    class ProductMaganger
    {
        static object _lockObject = new object();   // Kilitli nesne örneği üretimi 
        private static ProductMaganger _productMabager; //Kendi içinde oluşturulan private field.
        private ProductMaganger() //dışardan erişime kaptılması için oluşturulan PRİVATE CTOR 
        {
                                    //Bu sayede nesene örneği dışardan üretilemez. statik gibi düşünülebilir.
                                    //Aşağıda a ve b classları ile örneklendi
                                    //nesneyi kullanmak istersek onu karşıyalayn bir şeye atamalıyız.

        }

        public static ProductMaganger CreatAsSingleton() // nesne yi kullanabilmezmi için bu metodu çağırmalıyız
                                                         // eğer nesne örneği üretilmemiş se yani null ise nesne üretilecek
                                                         //lock ise nesne örneği üretimini güvenlli hale geitrerek ikinci bir kulanıcını geldi
                                                         //ulaşılacak sorunların önüne geçer
        {
            lock (_lockObject)          
            {
                if (_productMabager == null)
                {
                _productMabager = new ProductMaganger();
                }

            }

            return _productMabager;
        }
    }


    // STATİC CLASS İLE SİNGLETON YAPILMIŞ CLASS ARASINDAKİ FARK
    public static class a
    {
        public static void geta()
        {
            Console.WriteLine("a class");
        }
    }

    public class b
    {
        private static b _b;
        private b()
        {

        }

        public static b GetB()
        {
            if (_b == null)
            {
                _b = new b();
            }
            return _b;
        }

        public void get()
        {
            Console.WriteLine("b class");
        }
    }
}
