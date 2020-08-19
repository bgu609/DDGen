using Newtonsoft.Json;
using System;

namespace BogusTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new SampleCustomerRepository();
            var customers = repository.GetCustomers();

            Console.WriteLine(JsonConvert.SerializeObject(customers, Formatting.Indented)); //json (들여쓰기) 형식으로 convert
        }
    }
}
