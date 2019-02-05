using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            productDirector.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.DiscountedPrice);

            Console.ReadLine();

        }
    }
    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class PrdocutBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder:PrdocutBuilder
    {
        ProductViewModel _model = new ProductViewModel();
        public override void GetProductData()
        {
            _model.Id = 1;
            _model.CategoryName = "Beverages";
            _model.ProductName = "Chai";
            _model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            _model.DiscountedPrice = _model.UnitPrice * (decimal) 0.90;
            _model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return _model;
        }
    }

    class OldCustomerProductBuilder:PrdocutBuilder
    {
        ProductViewModel _model = new ProductViewModel();
        public override void GetProductData()
        {
            _model.Id = 1;
            _model.CategoryName = "Beverages";
            _model.ProductName = "Chai";
            _model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            _model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return _model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(PrdocutBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
