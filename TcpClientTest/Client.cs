using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TcpClientTest
{
    public class Client
    {
        public async void Run()
        {
            Console.WriteLine("入力してください");
            string msg = Console.ReadLine();

            if (msg == null || msg.Length == 0)
            {
                return;
            }

            string ip = "192.168.102.123";
            int port = 12345;


            using (var tcpClient = new TcpClient(ip, port))
            using (var stream = tcpClient.GetStream())
            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter(stream))
            {
                Console.WriteLine("サーバー({0}:{1})と接続しました({2}:{3})。",
                ((System.Net.IPEndPoint)tcpClient.Client.RemoteEndPoint).Address,
                ((System.Net.IPEndPoint)tcpClient.Client.RemoteEndPoint).Port,
                ((System.Net.IPEndPoint)tcpClient.Client.LocalEndPoint).Address,
                ((System.Net.IPEndPoint)tcpClient.Client.LocalEndPoint).Port);

                await writer.WriteLineAsync(msg);
                await writer.WriteLineAsync();

                await writer.FlushAsync();

                string line;
                do
                {
                    line = await reader.ReadLineAsync();
                    // 受信メッセージ
                    if (line != "") Console.WriteLine($"message form Server:{line}");

                } while (!String.IsNullOrWhiteSpace(line));
            }

            Console.WriteLine("end connection");
        }
    }
}
