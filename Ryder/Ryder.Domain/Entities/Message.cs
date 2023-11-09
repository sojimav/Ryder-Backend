using Ryder.Domain.Common;

namespace Ryder.Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid MessageThreadId { get; set; }
        public Guid SenderId { get; set; } //This will be an app user Id
        public string Body { get; set; }
    }
}