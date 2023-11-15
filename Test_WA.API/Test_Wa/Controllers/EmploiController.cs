using Microsoft.AspNetCore.Mvc;
using Test_Wa.Data.Domain;
using Test_Wa.Data.Dto;
using Test_Wa.Repository.Interface;

namespace Test_Wa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmploiController : ControllerBase
    {
        private IEmploiRepository emploiRepository;

        public EmploiController(IEmploiRepository emploiRepository)
        {
            this.emploiRepository = emploiRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmploi(CreateEmploi emploi)
        {
            await this.emploiRepository.Add(emploi);
            return Ok("Emploi créer"); 
        }
    }
}
