using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();
            client.Run();

            Console.ReadKey();

        }
    }
}
