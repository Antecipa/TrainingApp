using System;
using System.Collections.Generic;
using System.Linq;

namespace Antecipa.Trainning.Domain.Buyers
{
    public class Buyer: IAggregateRoot
    {
        private string _name;

        public string Name
        {
            get
            {
                return $"Your name Is {_name}";
            }
            set
            {
                if(value is null || value == string.Empty){throw  new ArgumentNullException(nameof(Name));}

                this._name = value; //$"Your name Is {value}";
            }
        }

        public int Id { get; set; }

        public List<Supplier> Suppliers { get; private set; }
        public List<Contact> Contacts { get;  set; }

        public List<Invoice> Invoices { get; set; }

        public Buyer()
        {
            
        }


        private bool SupplierExists(string name)
        {
            if(Suppliers is null)
                return false;

           return  Suppliers.Any(s => s.Name == name);
        }

        public void AddSupplier(Supplier supplier)
        {
            if (supplier == null) throw new ArgumentNullException(nameof(supplier));

            if(Suppliers == null)
                Suppliers = new List<Supplier>();

            if(SupplierExists(supplier.Name))
                throw new SupplierExistsException();

            Suppliers.Add(supplier);
        }

        public void RemoveSupplier(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            if (!SupplierExists(name))
                throw new SupplierDoesNotExistsException();

            Suppliers.Remove(GetSupplier(name));
        }

        public Supplier GetSupplier(string name)
        {
            return  Suppliers.SingleOrDefault(s => s.Name == name);
        }


        public void AddContact(Contact contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));

            var oldContact = Contacts.Where(c => c.Description == contact.Description);

            if (oldContact !=null )
                return;

            Contacts.Add(contact);
        }

        public void RemoveInvoice(Invoice invoice)
        {
            if (invoice == null) throw new ArgumentNullException(nameof(invoice));

            var  currentInvoice = Invoices.SingleOrDefault(c => c.Id == invoice.Id);

            if (currentInvoice != null)
            {
                Invoices.Remove(currentInvoice);
            }
        }

        public void AddInvoice(Invoice invoice)
        {
            if (invoice == null) throw new ArgumentNullException(nameof(invoice));

            if(Invoices==null)
                Invoices = new List<Invoice>();

            var  invoiceExist = Invoices.Any(c => c.Id == invoice.Id);

            if (invoiceExist == null )
                return;

            Invoices.Add(invoice);
        }
    }
}