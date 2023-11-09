using Ryder.Domain.Common;
using Ryder.Domain.Enums;

namespace Ryder.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string ReferenceNumber { get; set; }
        public Guid OrderId { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Amount { get; set; }
    }
}