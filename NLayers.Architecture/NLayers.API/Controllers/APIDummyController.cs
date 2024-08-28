using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Presentation.Controllers;
using NLayers.BusinessLogic.Contracts;

namespace NLayers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIDummyController(IDummyManager manager) : DummyController(manager)
    {
        //public APIDummyController(IDummyManager manager): base(manager)
        //{

        //}
    }
}
