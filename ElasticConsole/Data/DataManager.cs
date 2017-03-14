using System;
using System.Collections.Generic;
using System.Linq;
using ElasticConsole.Models;

namespace ElasticConsole.Data
{
    internal class DataManager
    {
        private readonly Repository _repository;

        public DataManager()
        {
            _repository = new Repository();
        }

        public void Run()
        {
            RunQuery();
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

        private void FindUsersForOrg()
        {
            Console.WriteLine($"Searching for users that belong to OrgId: [{Storage.NissanId}]");

            var users = _repository.GetUsersForOrganisation(Storage.NissanId).ToList();

            Console.WriteLine($"Found {users.Count()} users");

            foreach (var user in users)
            {
                Console.WriteLine(user.UserName);
            }
        }

        private void FindClaimsForOrg()
        {
            Console.WriteLine($"Searching for claims that belong to OrgId: [{Storage.HsbcId}]");

            var claims = _repository.GetClaimsForOrganisation(Storage.HsbcId).ToList();

            Console.WriteLine($"Found {claims.Count()} claims");

            foreach (var claim in claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type} - Value: {claim.Value}");
            }
        }

        private void FindClaimsForService()
        {
            Console.WriteLine($"Searching for claims that belong to service Id: [{Storage.WebApiId}]");

            var claims = _repository.GetClaimsForService(Storage.WebApiId).ToList();

            Console.WriteLine($"Found {claims.Count()} claims");

            foreach (var claim in claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type} - Value: {claim.Value}");
            }
        }

        private void SetClaimsForUser()
        {
            const string userName = "specialUser";
            var user = _repository.FindUser(userName);

            if (user != null)
            {
                Console.WriteLine($"Found {user.Claims.Count()} claims before update");

                user.Claims.Clear();
                user.Claims.Add(new ClaimModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Owner = user.Id,
                    Type = Storage.ServiceUserClaim,
                    Value = $"{Storage.ServiceUserClaim}_claim_api"
                });

                //_repository.UpdateUser(user);
            }

            user = _repository.FindUser(userName);

            if (user != null)
            {
                Console.WriteLine($"Found {user.Claims.Count()} claims after update");

                foreach (var claim in user.Claims)
                {
                    Console.WriteLine($"Claim Type: {claim.Type} - Value: {claim.Value}");
                }
            }
        }

        private void GetClaims()
        {
            _repository.ReIndex();

            var claims = _repository.GetClaimsForEntity(Storage.AnonymousId);

            foreach (var claim in claims)
            {
                Console.WriteLine($"Value:{claim.Code}");
            }
        }
        private void RunQuery()
        {
            _repository.PrintCounts();
            GetClaims();
        }
    }
}
