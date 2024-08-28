using Microsoft.AspNetCore.Mvc;
using NLayers.BusinessLogic.Contracts;
using NLayers.BusinessLogic.Managers;

namespace NLayer.Presentation.Controllers
{
    public class DummyController(IDummyManager dummyManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> DummyMethod()
        {
            dummyManager.ManagerDummyMethod();
            return Ok();
        }
    }
}
