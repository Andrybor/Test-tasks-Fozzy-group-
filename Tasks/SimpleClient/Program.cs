using System;

namespace SimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SimpleServiceReference.SimpleServiceClient();
            try
            {
                var result = client.GetData(123);
                Console.WriteLine(result);
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot connect to server");
            }

            Console.ReadKey();
        }
    }
}
