﻿using ServerClasses.ServerFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerConnectionManager server = new ServerConnectionManager();
            server.StartServer();
            Console.ReadLine();
        }
    }
}
