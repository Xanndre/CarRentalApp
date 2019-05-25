using CarRentalAPI.Data;
using CarRentalAPI.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalAPI.Services
{
    public class ClientService
    {
        private CarDbContext _carDbContext;

        public ClientService(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }

        public int Create(Client client)
        {
            _carDbContext.Clients.Add(client);
            _carDbContext.SaveChanges();
            return client.Id;
        }

        public List<Client> ReadAll()
        {
            return _carDbContext.Clients.ToList();
        }

        public Client Read(int id)
        {
            return _carDbContext.Clients.SingleOrDefault(client => client.Id == id);
        }

        public void Delete(int id)
        {
            Client client = Read(id);
            if (client == null)
                throw new ArgumentNullException("There's no client with such an id");
            _carDbContext.Clients.Remove(client);
            _carDbContext.SaveChanges();
        }
    }
}
