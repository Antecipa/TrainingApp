using Antecipa.Trainning.Domain.Buyers;

namespace Antecipa.Trainning.Infrastructure
{
    public static class BuyerRepositoryFactory
    {
        public static IBuyerRepository Create(string name)
        {
            if(name=="EF")
                return new BuyerEFRepository();



            return new BuyerMemoryRepository();
        }
    }
}