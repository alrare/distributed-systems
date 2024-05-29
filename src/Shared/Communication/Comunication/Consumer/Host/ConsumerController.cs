using Shared.Communication.Consumer.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace Shared.Communication.Consumer.Host;

public class ConsumerController<TMessage> : Controller
{
    private readonly IConsumerManager<TMessage> _consumerManager;

    public ConsumerController(IConsumerManager<TMessage> consumerManager)
    {
        _consumerManager = consumerManager;
    }
    
    //[System.Web.Mvc.HttpPut]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[System.Web.Mvc.Route("start")]
    //public virtual IActionResult Start()
    //{
    //    _consumerManager.RestartExecution();
    //    return Ok();
        
    //}
}