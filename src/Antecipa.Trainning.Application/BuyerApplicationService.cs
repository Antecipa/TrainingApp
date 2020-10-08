using System;
using System.Collections.Generic;
using Antecipa.Trainning.Domain;
using Antecipa.Trainning.Domain.Buyers;

namespace Antecipa.Trainning.Application
{
    public class BuyerApplicationService:IBuyerApplicationService
    {
        private readonly IBuyerRepository _buyerRepository;
        private readonly IUnityOfWork _unityOfWork;

        public BuyerApplicationService(IBuyerRepository buyerRepository,IUnityOfWork unityOfWork)
        {
            _buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
            _unityOfWork = unityOfWork;
        }

        public void AddBuyer(BuyerAddCommand command)
        {
            
        }

        public void AddBuyer(Buyer buyer)
        {
            if (buyer == null) throw new ArgumentNullException(nameof(buyer));

            var currentBuyer = _buyerRepository.GetById(buyer.Id);

            if(currentBuyer!=null)
                throw  new Exception("Buyer already exist.");

            currentBuyer.Name = "joao";

            buyer.AddContact(new Contact()
            {
                Description = "michel"
            });

            _buyerRepository.Add(buyer);

            _unityOfWork.Commit();
        }  
        
        public IList<Buyer> GetAll()
        {
            var buyers = _buyerRepository.GetAll();

            if(buyers==null)
                return new List<Buyer>();

            return buyers;
        }
    }

    public class BuyerAddCommand

    {
        public string Name { get; set; }
    }
}