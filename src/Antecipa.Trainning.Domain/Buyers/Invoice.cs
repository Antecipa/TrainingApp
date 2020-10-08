using System;

namespace Antecipa.Trainning.Domain.Buyers
{
    public class Invoice:ValueObject
    {
        public int Id { get; set; }
        public Buyer Buyer { get; set; }

        public Supplier Supplier { get; set; }

        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }

    }
}