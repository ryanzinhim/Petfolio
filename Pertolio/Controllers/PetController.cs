using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petfolio.aplication.UseCases.Pet.Register;
using Petfolio.aplication.UseCases.Pet.Update;
using Petfolio.comunication.Request;
using Petfolio.comunication.Responses;

namespace Pertolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private static readonly List<RegisterPet> _pet = new();
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterPet), StatusCodes.Status201Created)]
        public IActionResult Register([FromBody] RegisterPet request)
        {
            var response = new RegisterPetUseCases().execute(request);
            _pet.Add(request);
            int id = _pet.Count + 1;

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RegisterPet>), StatusCodes.Status201Created)]
        public IActionResult GetAll()
        {
            return Ok(_pet);
        }
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult Update([FromRoute] int id, [FromBody] RegisterPet request)
        {
            var UseCase = new UpdatePetUseCase();
            UseCase.execute(id, request);

            return NoContent();
        }
    }
}
