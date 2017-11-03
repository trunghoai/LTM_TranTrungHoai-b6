﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Vidu_client1
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            byte[] data = new byte[1024];
            string stringData; int recv;
            sock.Connect(iep); Console.WriteLine("Connected to server");
            recv = sock.Receive(data); stringData = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine("Received: {0}", stringData); while (true)
            {
                stringData = Console.ReadLine();
                if (stringData == "exit")
                    break;
                data = Encoding.ASCII.GetBytes(stringData);
                sock.Send(data, data.Length, SocketFlags.None); data = new byte[1024];
                recv = sock.Receive(data);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine("Received: {0}", stringData);
            }
            sock.Close();
        }
    }
}
