using Ryder.Domain.Common;

namespace Ryder.Domain.Entities
{
    public class MessageThread : BaseEntity
    {
        public string Subject { get; set; }
        public Guid LastMessageId { get; set; }
        public Guid PinnedMessageId { get; set; }
    }
}