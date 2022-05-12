using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarBase car = new PersonelCar();
            car.Fiyat = 3000;

            SpecialCarOffer carOffer = new SpecialCarOffer(car);

            Console.WriteLine(car.Fiyat);
            Console.WriteLine(carOffer.Fiyat);

            Console.ReadLine();
        }
    }
    //Decarator pattern builder benzeri bir yapıaya sahip
    //bir nesnemizi farklı clentlere özelleştirilmiş şekidle kullandırmak için bu pattern kullanılır
    //decaratore kullanmak istediğimiz nesne tipinden birşey verilir
    //decarator daha sonra özellşetirilecek sınıfta manipule edilerek kullanıcayı istediği nesnenin dekore edilmiş hali gönderilir.
    //

    public abstract class CarBase
    {
        public abstract decimal Fiyat { get; set; }
    }

    public class PersonelCar : CarBase
    {
        public override decimal Fiyat { get; set; }
        
    }

    public class KiralikCar : CarBase
    {
        public override decimal Fiyat { get; set; }
    }

    public abstract class CarDecoratorBase : CarBase
    {
        private CarBase _car;
        public CarDecoratorBase(CarBase car)
        {
            this._car = car;
        }
    }

    public class SpecialCarOffer : CarDecoratorBase
    {
        private readonly CarBase _car;
        public SpecialCarOffer(CarBase car) : base(car)
        {
            _car = car;
        }
        public override decimal Fiyat
        {
            get
            {
                return _car.Fiyat * 90 / 100;
            }
            set
            {

            }
        }
    }
}
