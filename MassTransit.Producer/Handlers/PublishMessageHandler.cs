using MassTransit.Producer.Commands;
using MassTransit.Shared.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MassTransit.Producer.Handlers
{
    public class PublishMessageHandler : IRequestHandler<PublishMessageCommand, string>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public PublishMessageHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task<string> Handle(PublishMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _publishEndpoint.Publish<PublishedMessage>(new PublishedMessage
                {
                    Message = request.Message,
                    CreatedBy = request.CreatedBy,
                    CreatedAtUtc = request.CreatedAtUtc
                });
                return "Message sent successfully";
            }
            catch(Exception ex)
            {
                return $"Message failed to send. Error: {ex.Message}";
            }
        }
    }
}
