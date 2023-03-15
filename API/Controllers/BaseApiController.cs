using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
        // _mediator가 있으면 리턴 없으면 생성해서 리턴 
        private IMediator _mediator;
        
        // '??=' :  httpcontext의 모든권한을Mediator에게 넘겨준다. 
        protected IMediator Mediator => _mediator ??= 
        HttpContext.RequestServices.GetService<IMediator>();
    }
}