using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Wa.Data.Dto;
using Test_Wa.Repository.Interface;

namespace Test_Wa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonneController : ControllerBase
    {
        private IPersonneRepository personneRepository;

        public PersonneController(IPersonneRepository personneRepository)
        {
            this.personneRepository = personneRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonne(CreatePersonne personne)
        {
            await this.personneRepository.Add(personne);
            return Ok("Personne créer");
        }

        [HttpGet("GetAllPersonnes")]
        public async Task<IActionResult> GetAllPersonnes()
        {
            List<PersonneDetails> personnes = await this.personneRepository.GetAllDetails();

            return Ok(personnes);
        }
    }
}
