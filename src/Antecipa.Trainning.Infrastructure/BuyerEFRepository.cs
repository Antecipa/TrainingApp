using System;
using System.Collections.Generic;
using System.Linq;
using Antecipa.Trainning.Domain;
using Antecipa.Trainning.Domain.Buyers;

namespace Antecipa.Trainning.Infrastructure
{
    public class BuyerEFRepository:IBuyerRepository
    {
        private List<Buyer> buyers = new List<Buyer>();

        public Buyer GetById(int id)
        {
            return buyers.SingleOrDefault(b => b.Id == id);
        }

        public Buyer GetByName(string name)
        {
            return buyers.SingleOrDefault(b => b.Name == name);
        }

        public List<Invoice> GetInvoicesBy(int buyerId)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetInvoicesBySupplier(int supplierId)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContactsBy(int buyer)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            
        }

        public void Add(Buyer currentBuyer)
        {
            throw new NotImplementedException();
        }

        public List<Buyer> GetAll()
        {
            return new List<Buyer>()
            {

                new Buyer(){Name = "michel"},
                new Buyer(){Name = "michel3"},
                new Buyer(){Name = "michel4"},
                new Buyer(){Name = "michel5"},
                new Buyer(){Name = "michel6"},
                new Buyer(){Name = "michel7"},
                new Buyer(){Name = "michel98"}
            };
        }
    }
}
