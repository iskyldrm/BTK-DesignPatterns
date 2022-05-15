using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerUpdated customer = new CustomerUpdated();
            customer.MassageSenderBase = new EmailSender();
            customer.Update();
            Console.ReadLine();
        }
    }

    //Bridge patterni abstract classların bussines clasında çağrılması ve ona bir köprü probu atılması ile yapılır.
    //bunun sayesinde yapılan işlem gelen köprü clasındaki metodlar ile zenginleştirilebilir
    

    public abstract class MassageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("MassegeSaved");
        }

        public abstract void Send(MassageBody massageBody);
    }
    
    public class MassageBody
    {
        public string Title { get; set; }
        public string Text { get; set; }    
    }

    public class SmsSender : MassageSenderBase
    {
        public override void Send(MassageBody massageBody)
        {
            Console.WriteLine("{0} massege saved with SmsSender ",massageBody.Title);
        }
    }
    public class EmailSender : MassageSenderBase
    {
        public override void Send(MassageBody massageBody)
        {
            Console.WriteLine("{0} massege saved with EmailSender", massageBody.Title);
        }
    }

    public class CustomerUpdated
    {
        public MassageSenderBase MassageSenderBase { get; set; }
        public void Update()
        {
            MassageSenderBase.Send(new MassageBody { Title = "This Update" });
            Console.WriteLine("Customer Updated");
        }
    }
}
