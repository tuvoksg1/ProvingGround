using System;
using Messenger.Console.Interfaces;

namespace Messenger.Console.Gods
{
    class Athena : IGod
    {
        private readonly Hermes<Message> _messenger;

        public Athena()
        {
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

            while (index++ < 25)
            {
                var message = new Message
                {
                    Id = Guid.NewGuid().ToString(),
                    EventDate = DateTime.Now,
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
    }
}
