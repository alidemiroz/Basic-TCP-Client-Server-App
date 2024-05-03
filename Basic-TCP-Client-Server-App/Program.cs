using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Basic_TCP_Client_Server_App
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 8000;
            const string host = "localhost";

            try
            {
                TcpListener server = new TcpListener(IPAddress.Parse(host), port);

                server.Start();

                Console.WriteLine($"Sunucu {host}:{port} portunda başlatıldı.");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();

                    NetworkStream stream = client.GetStream();

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    Console.WriteLine($"Alınan mesaj: {message}");

                    byte[] reply = Encoding.ASCII.GetBytes($"Sunucu cevabı: {message}");
                    stream.Write(reply, 0, reply.Length);

                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }
            


        }
    }
}

