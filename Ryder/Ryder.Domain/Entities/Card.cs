using Ryder.Domain.Common;
using Ryder.Domain.Enums;

namespace Ryder.Domain.Entities
{
    public class Card : BaseEntity
    {
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CVV { get; set; }
        public string ExpiredOn { get; set; }
        public Guid AppUserId { get; set; }
        public CardStatus Status { get; set; }
    }
}