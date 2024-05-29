using Microsoft.AspNetCore.Mvc;
using Shared.Communication.Messages;
using Shared.Communication.Consumer.Host;
using Shared.Communication.Consumer.Manager;

namespace Services.Products.Consumer.Controllers;

[ApiController]
[Route("[controller]")]
public class DomainConsumerController : ConsumerController<DomainMessage>
{
    public DomainConsumerController(IConsumerManager<DomainMessage> consumerManager) : base(consumerManager)
    {
    }
}