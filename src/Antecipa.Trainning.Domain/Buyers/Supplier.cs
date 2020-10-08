using System.Collections.Generic;

namespace Antecipa.Trainning.Domain.Buyers
{
    public class Supplier: Entity
    {
     
        public string Name { get; set; }

        public Document Document { get; set; }

        public List<Contact> Contacts { get; private set ; }

        //metodos 

    }
}