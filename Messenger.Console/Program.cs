using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Messenger.Console.Gods;

namespace Messenger.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var god = new Ares();
            //god.AddMessages();
            //god.ListMessages();
            //JsonBuilder.Build();
            RunPost();
            System.Console.ReadLine();
        }

        private static void RunPost()
        {
            try
            {
                Postman.Spam();

                //var taskList = new List<Task> { Task.Factory.StartNew(() => Postman.Spam()).Unwrap() };
                //Task.WaitAll(taskList.ToArray());

                //foreach (var runTask in taskList)
                //    System.Console.WriteLine((runTask as Task<string>)?.Result);
            }
            catch (Exception error)
            {
                while (error != null)
                {
                    System.Console.WriteLine(error.Message);
                    error = error.InnerException;
                }
            }
        }
    }
}
