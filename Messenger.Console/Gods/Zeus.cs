using System;
using Messenger.Console.Interfaces;
using Messenger.Console.Models;

namespace Messenger.Console.Gods
{
    class Zeus : IGod
    {
        private readonly Hermes<IncidenceMessage> _messenger;
        private readonly Random _randomizer;

        public Zeus()
        {
            _randomizer = new Random();
            _messenger = new Hermes<IncidenceMessage>("zeus");
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
                var message = new IncidenceMessage
                {
                    Id = Guid.NewGuid().ToString(),
                    EventDate = DateTime.Now,
                    TenantCode = "MaritzCX",
                    ApplicationSource = "Pledge",
                    Content = $"Incidence {index}",
                    StartDate = GetDate(index, true),
                    EndDate = GetDate(index, false),
                    MachineName = GetMachine(index)
                };

                _messenger.AddMessage(message);
            }
        }

        public void ListMessages()
        {
            var messages = _messenger.GetMessages();

            foreach (var message in messages)
            {
                System.Console.WriteLine($"{message.Content} - Machine: {message.MachineName}, " +
                    $"Started: {message.StartDate:dd/MM/yyyy}, Ended: {message.EndDate:dd/MM/yyyy}");
            }
        }

        private DateTime GetDate(int index, bool isBeforeNow)
        {
            var offset = _randomizer.Next(1, 25);

            if (isBeforeNow)
            {
                offset = offset*-1;
            }

            return DateTime.Now.AddDays(offset);
        }

        private static string GetMachine(int index)
        {
            var modulus = index % 3;

            switch (modulus)
            {
                case 1:
                    return "Alpha";
                case 2:
                    return "Beta";
                default:
                    return "Charlie";
            }
        }
    }
}
