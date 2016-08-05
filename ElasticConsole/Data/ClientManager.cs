using System;
using System.Collections.Generic;
using System.Linq;
using ElasticConsole.Models;

namespace ElasticConsole.Data
{
    internal class ClientManager
    {
        private readonly Repository _repository;

        public ClientManager()
        {
            _repository = new Repository();
        }

        public void Run()
        {
            UpdateClient();
        }

        private void DeleteClient()
        {
            _repository.QueryClients();

            _repository.DeleteClient("foo");
            _repository.DeleteClient("foo");
            _repository.DeleteClient("commandlineid");

            _repository.QueryClients();
        }

        private void UpdateClient()
        {
            const string handle = "js.tokenmanager";
            var model = _repository.FindClient(handle).FirstOrDefault();

            Console.WriteLine($"Id before update: {model?.Id}");

            if (model != null)
            {
                model.Type = ClientType.Native;
                model.LoginRedirectLinks = new List<string>
                {
                    "http://localhost:5000/index.html"
                };
                model.LogoutRedirectLinks = new List<string>
                {
                    "http://localhost:5000/signout.html"
                };
                model.TrustedDomains = new List<string>
                {
                    "http://localhost:5000",
                    "http://localhost:5001",
                    "http://localhost:5002"
                };
            }

            _repository.UpdateClient(model);

            model = _repository.FindClient(handle).FirstOrDefault();

            Console.WriteLine($"Id after update: {model?.Id}");
            Console.WriteLine($"Client update complete for {model?.Handle}");
        }
    }
}
