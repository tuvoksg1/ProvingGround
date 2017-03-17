using System;
using Messenger.Console.Interfaces;
using Messenger.Console.Models;

namespace Messenger.Console.Gods
{
    class Ares : IGod
    {
        private readonly Hermes<PledgeRun> _messenger;
        private readonly Random _randomizer;

        public Ares()
        {
            _randomizer = new Random();
            _messenger = new Hermes<PledgeRun>();
        }

        public void AddMessages()
        {
            var count = _messenger.GetMessageCount();

            if (count != 0)
            {
                return;
            }

            var index = 0;

            while (index++ < 50)
            {
                var message = new PledgeRun
                {
                    StartDate = GetDate(true),
                    EndDate = GetDate(false),
                    TenantCode = "MaritzCX",
                    ApplicationSource = "Pledge",
                    Content = $"Pledge {index}",
                    RecordsProcessed = GetCount(),
                    TotalFail = GetCount(),
                    TotalPass = GetCount(),
                    FileName = GetFile(index),
                    RunId = Guid.NewGuid().ToString(),
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
            return _randomizer.Next(250, 500);
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

        private DateTime GetDate(bool isBeforeNow)
        {
            var offset = _randomizer.Next(1, 25);

            if (isBeforeNow)
            {
                offset = offset * -1;
            }

            return DateTime.Now.AddDays(offset);
        }
    }
}
