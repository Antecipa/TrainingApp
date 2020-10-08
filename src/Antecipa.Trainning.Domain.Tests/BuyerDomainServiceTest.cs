using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antecipa.Trainning.Domain.Buyers;
using Antecipa.Trainning.Infrastructure;
using NSubstitute;
using NUnit.Framework;

namespace Antecipa.Trainning.Domain.Tests
{
    //PROXY

    public class BuyerDomainServiceTest
    {
        private  BuyerService buyerService =null;
        private  IBuyerRepository buyerRepositoryMock =null;

        public BuyerDomainServiceTest()
        {
            buyerRepositoryMock = NSubstitute.Substitute.For<IBuyerRepository>();
        
            buyerService = new BuyerService(buyerRepositoryMock,new Logger());
        }

        [Test]

        public void TransferInvoice()
        {
            var buyerA = new Buyer()
            {
                Id = 1,
                Name = "Michel"
            };
            
            var invoice = new Invoice() {Id = 1, DueDate = DateTime.Now, Value = 10};
            buyerA.AddInvoice(invoice);

            var buyerB = new Buyer()
            {
                Id = 2,
                Name = "Michel"
            };

            buyerRepositoryMock.GetById(buyerA.Id).Returns(buyerA);
            buyerRepositoryMock.GetById(buyerB.Id).Returns(buyerB);

            buyerService.TransferInvoice(buyerA,buyerB, invoice);

            //Asserts
            buyerRepositoryMock.Received(2).GetById(Arg.Any<int>());
            buyerRepositoryMock.Received().Save();

            Assert.IsNotNull(buyerB.Invoices);
            Assert.AreEqual(1,buyerB.Invoices.Count);

        }


    }
}
