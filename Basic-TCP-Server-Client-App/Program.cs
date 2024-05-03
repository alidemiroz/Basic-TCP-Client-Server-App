using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Basic_TCP_Server_Client_App
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 8000;
            const string host = "localhost";

            try
            {
                TcpClient client = new TcpClient(host,port);

                Console.WriteLine($"Sunucuya ({host}:{port}) bağlanıldı.");

                NetworkStream stream = client.GetStream();

                string message = "Merhaba Sunucu.";

                byte[] buffer = Encoding.ASCII.GetBytes(message);

                stream.Write(buffer, 0, buffer.Length);

                buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                string reply = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                Console.WriteLine($"Sunucu cevabı: {reply}");

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }
        }
    }
}

