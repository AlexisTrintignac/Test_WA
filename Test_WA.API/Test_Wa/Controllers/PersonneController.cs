using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Test_Wa.Data.Domain;
using Test_Wa.Data.Dto;
using Test_Wa.Repository.Interface;
using Microsoft.AspNetCore.Cors;

namespace Test_Wa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowSpecificOrigin")]

    public class PersonneController : ControllerBase
    {
        private IPersonneRepository personneRepository;

        public PersonneController(IPersonneRepository personneRepository)
        {
            this.personneRepository = personneRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonne([FromBody] CreatePersonne personne)
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

        [HttpGet("{nomEntreprise}")]
        public async Task<IActionResult> GetPersonnesByEntreprise(string nomEntreprise)
        {
            List<PersonneDetails> personnes = await this.personneRepository.GetPersonnesByEntreprise(nomEntreprise);
            return Ok(personnes);
        }

        [HttpGet("WithoutEmploi/{dateDebut}/{dateFin}")]
        public async Task<IActionResult> GetPersonnesWithoutEmploi(DateTime dateDebut, DateTime dateFin)
        {
            List<Personne> personnes = await this.personneRepository.GetPersonnesWithoutEmploi(dateDebut, dateFin);
            return Ok(personnes);
        }

        [HttpGet("WithEmploi/{dateDebut}/{dateFin}")]
        public async Task<IActionResult> GetPersonnesWithEmploi(DateTime dateDebut, DateTime dateFin)
        {
            List<Personne> personnes = await this.personneRepository.GetPersonnesWithEmploi(dateDebut, dateFin);
            return Ok(personnes);
        }
    }
}
