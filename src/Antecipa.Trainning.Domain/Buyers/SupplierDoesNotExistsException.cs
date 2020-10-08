using System;

namespace Antecipa.Trainning.Domain.Buyers
{
    public class SupplierDoesNotExistsException:Exception
    {
        public SupplierDoesNotExistsException() : base("Supplier Not found")
        {
                
        }
    }
}