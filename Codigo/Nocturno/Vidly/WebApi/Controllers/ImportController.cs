using BusinessLogicInterface;
using BusinessLogicInterface.Utils;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/importers")]
    public class ImportController : ControllerBase
    {
        private readonly IImporterLogic importLogic;
        public ImportController(IImporterLogic importLogic)
        {
            this.importLogic = importLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.importLogic.GetNames());
        }

        [HttpPost]
        public IActionResult Post([FromBody]ImporterModel import)
        {
            this.importLogic.Import(import);
            return Ok();
        }
    }
}