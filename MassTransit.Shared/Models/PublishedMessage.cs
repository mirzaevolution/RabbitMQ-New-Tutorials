using System;

namespace MassTransit.Shared.Models
{
    public class PublishedMessage
    {
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public string Message { get; set; }
    }
}
