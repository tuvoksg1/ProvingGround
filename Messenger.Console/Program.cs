﻿using Messenger.Console.Gods;

namespace Messenger.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var god = new Ares();
            god.AddMessages();
            god.ListMessages();

            System.Console.ReadLine();
        }
    }
}
