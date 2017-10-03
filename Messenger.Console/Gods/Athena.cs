using System;
using Messenger.Console.Interfaces;

namespace Messenger.Console.Gods
{
    class Athena : IGod
    {
        private readonly Hermes<Message> _messenger;
        private readonly Random _randomizer;

        public Athena()
        {
            _randomizer = new Random();
            _messenger = new Hermes<Message>("athena");
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
                var message = new Message
                {
                    Id = Guid.NewGuid().ToString(),
                    EventDate = GetDate(),
                    TenantCode = "MaritzCX",
                    ApplicationSource = "Pledge",
                    Content = $"Event {index}"
                };

                _messenger.AddMessage(message);
            }
        }

        public void ListMessages()
        {
            var messages = _messenger.GetMessages();

            foreach (var message in messages)
            {
                System.Console.WriteLine(message.Content);
            }
        }

        private DateTime GetDate()
        {
            var offset = _randomizer.Next(1, 30) * -1;

            return DateTime.Now.AddDays(offset);
        }
    }
}
