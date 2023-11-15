using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Wa.Data.Dto;
using Test_Wa.Repository.Interface;

namespace Test_Wa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OccupationController : ControllerBase
    {
        private IOccupationRepository _occupationRepository;

        public OccupationController(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOccupation(CreateOccupation occupation)
        {
            await this._occupationRepository.Add(occupation);
            return Ok("Un emploie a été associé a une personne");
        }
    }
}
