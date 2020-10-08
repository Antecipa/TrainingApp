using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Antecipa.Trainning.Domain.Buyers;
using NUnit.Framework;
using NUnit.Framework.Api;

namespace Antecipa.Trainning.Domain.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SetNameShouldNotAcceptEmptyOrNullValues()
        {
            //criar um nova instancia de buyer
            /// new Buyer()
            /// ter um factory de buyer
            //Mocks and Stubs

            Assert.Throws<ArgumentNullException>(()=> new Buyer()
            {
                Name = "",
            });

            Assert.Pass();
        }

        [Test]
        public void SetNameShouldAppendYourNameIs()
        {
            //criar um nova instancia de buyer
            /// new Buyer()
            /// ter um factory de buyer
            //Mocks and Stubs
            var expectedValue = "Your name Is Michel";
            var buyer =  new Buyer()
            {
                Name = "Michel",
            };

            Assert.AreEqual(expectedValue,buyer.Name);
        }


        [Test]
        public void AddSupplierShouldThrowExceptionIfSupplierIsNull()
        {   
            var buyer =  new Buyer()
            {
                Name = "Michel",
            };

            //var supplier = new Supplier();
            Assert.Throws<ArgumentNullException>(()=>  buyer.AddSupplier(null));
        }

        
        [Test]
        public void AddSupplier_Should_ThrowException_If_Supplier_AlreadyExists()
        {   
            var buyer =  new Buyer()
            {
                Name = "Michel",
            };

            var supplier1 = new Supplier()
            {
                Name = "Welbert & Diego TEC LTDA"
            };
            
            buyer.AddSupplier(supplier1);

            var supplier2 = new Supplier()
            {
                Name = "Welbert & Diego TEC LTDA"
            };

            //var supplier = new Supplier();
            Assert.Throws<SupplierExistsException>(()=> buyer.AddSupplier(supplier2) );
        }


        [Test]
        [TestCase(1)]
        [TestCase(3)]
        public void CountSupplier_ShouldReturn_AddedQtd(int expectedCount)
        {   
            var buyer =  new Buyer()
            {
                Name = "Michel"
            };

            for (int i = 0; i < expectedCount; i++)
            {
                var supplier1 = new Supplier()
                {
                    Name = $"Welbert & Diego TEC LTDA {i}"
                };

                buyer.AddSupplier(supplier1);
            }


            Assert.IsNotNull(buyer.Suppliers);
            
            Assert.AreEqual(expectedCount,buyer.Suppliers.Count);
        }

        
        [Test]
    
        public void RemoveSupplier_ShouldThrowEceptionIfNameIsNullOrEmpty()
        {   
            var buyer =  new Buyer()
            {
                Name = "Michel"
            };

            Assert.Throws<ArgumentNullException>(()=>  buyer.RemoveSupplier(string.Empty));
        }


        [Test]

        public void RemoveSupplier_ShouldReturn_Exception_If_Supplier_DoesNotExists()
        {
            var buyer = new Buyer()
            {
                Name = "Michel"
            };

            for (int i = 0; i < 3; i++)
            {
                var supplier1 = new Supplier()
                {
                    Name = $"Welbert & Diego TEC LTDA {i}"
                };
                buyer.AddSupplier(supplier1);
            }

            var name = $"Welbert & Diego TEC LTDA";

            Assert.Throws<SupplierDoesNotExistsException>(()=>  buyer.RemoveSupplier(name));
         
        }


        [Test]

        public void RemoveSupplier()
        {
            var buyer = new Buyer()
            {
                Name = "Michel"
            };

            for (int i = 0; i < 3; i++)
            {
                var supplier1 = new Supplier()
                {
                    Name = $"Welbert & Diego TEC LTDA {i}"
                };
                buyer.AddSupplier(supplier1);
            }

            var name = $"Welbert & Diego TEC LTDA 1";

            buyer.RemoveSupplier(name);
        
            Assert.AreEqual(2,buyer.Suppliers.Count);

            var oldSupllier = buyer.GetSupplier(name);

            Assert.IsNull(oldSupllier);
        }
    }

    //Visual Studio 
    //Resharper 
}