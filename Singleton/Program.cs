using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        // Sadece insert update delete yaptığı için singleton yapılabilir hale getiricem
        private static CustomerManager _customerManager;
        private static object _lockObject = new object();
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }

            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}
