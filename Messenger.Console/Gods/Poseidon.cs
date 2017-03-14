using System;
using Messenger.Console.Interfaces;
using Messenger.Console.Models;

namespace Messenger.Console.Gods
{
    class Poseidon : IGod
    {
        private readonly Hermes<TraceMessage> _messenger;
        private readonly Random _randomizer;

        public Poseidon()
        {
            _randomizer = new Random();
            _messenger = new Hermes<TraceMessage>("poseidon");
        }

        public void AddMessages()
        {
            var count = _messenger.GetMessageCount();

            if (count != 0)
            {
                return;
            }

            var index = 0;

            while (index++ < 25)
            {
                var message = new TraceMessage
                {
                    Id = Guid.NewGuid().ToString(),
                    EventDate = DateTime.Now,
                    TenantCode = "MaritzCX",
                    ApplicationSource = "Pledge",
                    Content = $"Trace {index}",
                    TotalFail = GetCount(),
                    TotalPass = GetCount(),
                    FileName = GetFile(index),
                    JobId = Guid.NewGuid().ToString()
                };

                _messenger.AddMessage(message);
            }
        }

        public void ListMessages()
        {
            var messages = _messenger.GetMessages();

            foreach (var message in messages)
            {
                System.Console.WriteLine($"{message.Content} - File: {message.FileName}, " +
                    $"Pass: {message.TotalPass}, Fail: {message.TotalFail}");
            }
        }

        private int GetCount()
        {
            return _randomizer.Next(1, 250);
        }

        private static string GetFile(int index)
        {
            var modulus = index % 3;

            switch (modulus)
            {
                case 1:
                    return "First.config";
                case 2:
                    return "Second.config";
                default:
                    return "Third.config";
            }
        }
    }
}
