using System.ComponentModel.DataAnnotations;

namespace MassTransit.Producer.Models.Messages
{
    public class PostMessageRequest
    {
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
