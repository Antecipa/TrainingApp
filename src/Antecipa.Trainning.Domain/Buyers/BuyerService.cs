using System;
using System.Linq;
using Antecipa.Trainning.CrossCutting;

namespace Antecipa.Trainning.Domain.Buyers
{
    public class BuyerService
    {
        private readonly IBuyerRepository _repository;
        private readonly ILogger _logger;

        public BuyerService(IBuyerRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public void TransferInvoice(Buyer from,Buyer to, Invoice invoice)
        {
            if (@from == null) throw new ArgumentNullException(nameof(@from));
            if (to == null) throw new ArgumentNullException(nameof(to));
            if (invoice == null) throw new ArgumentNullException(nameof(invoice));


            _logger.Info("Getting buyer by Id ");


            var buyerA = _repository.GetById(from.Id);

            if(buyerA is null)
                throw  new Exception("Buyer not found");

            var buyerB = _repository.GetById(to.Id);

            if(buyerB is null)
                throw  new Exception("Buyer not found");

            var fromInvoice = buyerA.Invoices.SingleOrDefault(i => i.Id == invoice.Id);

            if(fromInvoice is null)
                throw  new Exception("Invoice not found");


            buyerA.RemoveInvoice(fromInvoice);

            buyerB.AddInvoice(fromInvoice);

           _repository.Save();

        }
    }
}