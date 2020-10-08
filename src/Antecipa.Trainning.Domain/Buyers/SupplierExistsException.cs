using System;

namespace Antecipa.Trainning.Domain.Buyers
{
    public class SupplierExistsException:Exception
    {
        public SupplierExistsException() : base("This supplier already exists")
        {
                
        }
    }
}