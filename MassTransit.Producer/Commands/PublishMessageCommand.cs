using MediatR;
using System;

namespace MassTransit.Producer.Commands
{
    public class PublishMessageCommand : IRequest<string>
    {
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public string Message { get; set; }
    }
}
