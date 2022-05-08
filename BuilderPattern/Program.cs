using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var Builder = new NewCustomerProductBuilder();
            var Builder2 = new OldCustomerProductBuilder();
            director.GenerateProduct(Builder);
            director.GenerateProduct(Builder2);
            var model = Builder.GetProductViewModel();
            var model2 = Builder2.GetProductViewModel();

            Console.WriteLine("Ürün Id:          "+model.Id);
            Console.WriteLine("Ürün Kategorisi:  "+model.CategoryName);
            Console.WriteLine("Ürün İsmi:        "+model.ProductName);
            Console.WriteLine("Ürün Fiyatı:      "+model.UnitPrice);
            Console.WriteLine("Ürün İndirimlimi: "+model.DiscountApplied);
            Console.WriteLine("Ürün İ.Fiyatı:    "+model.DiscountedPrice);
            Console.WriteLine("************************");

            Console.WriteLine("Ürün Id:          "+model2.Id);
            Console.WriteLine("Ürün Kategorisi:  "+model2.CategoryName);
            Console.WriteLine("Ürün İsmi:        "+model2.ProductName);
            Console.WriteLine("Ürün Fiyatı:      "+model2.UnitPrice);
            Console.WriteLine("Ürün İndirimlimi: "+model2.DiscountApplied);
            Console.WriteLine("Ürün İ.Fiyatı:    " + model2.DiscountedPrice);

            Console.ReadLine();
        }
    }
    //Builder design pattern i üretilecek nesneni aynı olmaması durumunda farklı işlemler ve değerler getirilmesi durumunda kullanılır
    //örnek olarak aşağıda gelen ürün için idnirimli fiyat uygulması yapıld
    //databasede gelen fiyat bilgisini modelview de karşıladıktan sonra iki farklı class ile yeni özellikler kazandırdık.
    //bu sayede ürünü yönettiğim classta model buildir abstaract clasını kullanarak iki varklı ürün getirme seçeneği oluşturduk
    
    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }

    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();

        public abstract ProductViewModel GetProductViewModel();

    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * 0.90m;
            model.DiscountApplied = true;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Drink";
            model.ProductName = "Tea";
            model.UnitPrice = 30m;

        }

        public override ProductViewModel GetProductViewModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Drink";
            model.ProductName = "Tea";
            model.UnitPrice = 30m;

        }
        public override ProductViewModel GetProductViewModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder product)
        {
            product.GetProductData();
            product.ApplyDiscount();
        }
    }
}
