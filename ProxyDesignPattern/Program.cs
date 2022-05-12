using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditMangerProxy creditMangerProxy = new CreditMangerProxy();
            Console.WriteLine(creditMangerProxy.Calculator()); 
            Console.WriteLine(creditMangerProxy.Calculator());
            Console.ReadLine(); 
        }
    }

    //Proxy design pattern bir nesnenin özelliği kullanıldığı zaman bir kez daha kullanıcaksa
    //eğer direk o ilk oluşturulan özelliğin sonucu verilir.
    //bu sayede daha önce yyapılmış işlem tekrar tekrar yapılmasının önüne geçiyor. 
    //yapılmış işlem bir private değişkene atanır ve işlem yapıldıktan sonra sonuç private olarak tutulur hafızada
    // daha sonra tekrar istenmesi durumunda elde edilen eski sonuç örneklenmeden verilir


    public abstract class CreditBase
    {
        public abstract int Calculator();
        
    }

    public class CreditManager : CreditBase
    {
        public override int Calculator()
        {
            int result = 1;

            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }

    public class CreditMangerProxy : CreditBase
    {
        private CreditManager manager;
        private int _CachedValue;
        public override int Calculator()
        {
            if (manager == null)
            {
                manager = new CreditManager();
                _CachedValue = manager.Calculator();
            }
            return _CachedValue;
        }
    }
}
