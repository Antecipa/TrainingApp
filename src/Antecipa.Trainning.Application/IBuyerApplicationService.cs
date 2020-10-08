using System.Collections;
using System.Collections.Generic;
using Antecipa.Trainning.Domain.Buyers;

namespace Antecipa.Trainning.Application
{
    public interface IBuyerApplicationService
    {
        void AddBuyer(Buyer buyer);
        IList<Buyer> GetAll();
    }
}