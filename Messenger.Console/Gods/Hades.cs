using System;
using Messenger.Console.Interfaces;
using Messenger.Console.Models;

namespace Messenger.Console.Gods
{
    class Hades : IGod
    {
        private readonly Hermes<InvoiceMessage> _messenger;
        private readonly Random _randomizer;

        public Hades()
        {
            _randomizer = new Random();
            _messenger = new Hermes<InvoiceMessage>("hades");
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
                var message = new InvoiceMessage
                {
                    Id = Guid.NewGuid().ToString(),
                    EventDate = DateTime.Now,
                    TenantCode = "MaritzCX",
                    ApplicationSource = "Pledge",
                    Content = $"Invoice {index}",
                    RecordsProcessed = GetCount(),
                    Country = GetCountry(index),
                    Dealer = GetDealer(index)
                };

                _messenger.AddMessage(message);
            }
        }

        public void ListMessages()
        {
            var messages = _messenger.GetMessages();

            foreach (var message in messages)
            {
                System.Console.WriteLine($"{message.Content} - Country: {message.Country}, " + 
                    $"Dealer: {message.Dealer}, Records: {message.RecordsProcessed}");
            }
        }

        private int GetCount()
        {
            return _randomizer.Next(250, 500);
        }

        private static string GetCountry(int index)
        {
            var modulus = index % 4;

            switch (modulus)
            {
                case 1:
                    return "Germany";
                case 2:
                    return "Spain";
                case 3:
                    return "France";
                default:
                    return "Italy";
            }
        }

        private static string GetDealer(int index)
        {
            var modulus = index % 5;

            switch (modulus)
            {
                case 1:
                    return "Volvo";
                case 2:
                    return "Fiat";
                case 3:
                    return "Nissan";
                case 4:
                    return "Ford";
                default:
                    return "Volkswagen";
            }
        }
    }
}
