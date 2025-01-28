using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Application.Features.Owners.V1.Commands.CreateOwner;
using PropertiesApi.Application.Features.Owners.V1.Commands.CreateProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PropertiesApi.Tests.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class TestController : ControllerBase
    {
        private readonly IRequestHandler<CreatePropertyCommand, BaseResponse<String>> _propertyCommandHandler;

        public TestController(
            IRequestHandler<CreatePropertyCommand, BaseResponse<String>> propertyCommandHandler
            )
        {
            _propertyCommandHandler = propertyCommandHandler;
          
        }

        [HttpPost]
        public async Task<bool> TestCreateProperty([FromBody] CreatePropertyCommand command)
        {
            var res = await _propertyCommandHandler.Handle(command,CancellationToken.None);
            return res.Succeeded;
        }

        //[HttpGet("{orderId}")]
        //public async Task<IActionResult> GetOrder(int orderId)
        //{
        //    var query = new GetOrderQuery { OrderId = orderId };
        //    var response = await _getOrderHandler.Handle(query);
        //    return Ok(response);
        //}
    }

}
