using System.Collections.Generic;

namespace Antecipa.Trainning.Domain.Buyers
{
    public interface IBuyerRepository//: Repository
    {
        Buyer GetById(int id);
        Buyer GetByName(string name);

        List<Invoice> GetInvoicesBy(int buyerId);
        List<Invoice> GetInvoicesBySupplier(int supplierId);

        List<Contact> GetContactsBy(int buyer);

        void Save();
        void Add(Buyer currentBuyer);
        List<Buyer> GetAll();
    }
}