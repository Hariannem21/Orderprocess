using System;
using Microsoft.AspNetCore.Mvc;
using OrderProcess.API.Contexts;

namespace OrderProcess.API.Controllers
{
    [ApiController]
    [Route("api/testdatabase")]
    public class DummyController : ControllerBase
    {
        private readonly ProcessOrderContext _ctx;

        public DummyController(ProcessOrderContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        [HttpGet]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
