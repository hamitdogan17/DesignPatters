using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();
        }
    }
    //cross cutting concern ler
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }

    interface ILogging
    {
        void Log();
    }
    interface ICashing
    {
        void Cashe();
    }
    interface IAuthorize
    {
        void CheckUser();
    }
    interface IValidate
    {
        void Validate();
    }
    class Cashing : ICashing
    {
        public void Cashe()
        {
            Console.WriteLine("Cashed!");
        }
    }
    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked!");
        }
    }
    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("User checked!");
        }
    }

    class CustomerManager
    {
        private CrossCuttingConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Cashing.Cashe();
            _concerns.Authorize.CheckUser();
            _concerns.Logging.Log();
            _concerns.Validation.Validate();

            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICashing Cashing;
        public IAuthorize Authorize;
        public IValidate Validation;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Cashing = new Cashing();
            Authorize = new Authorize();
            Validation = new Validation();
        }
    }
}
