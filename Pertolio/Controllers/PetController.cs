using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petfolio.aplication.UseCases.Pet.Register;
using Petfolio.aplication.UseCases.Pet.Update;
using Petfolio.comunication.Request;
using Petfolio.comunication.Responses;
using Petfolio.Comunication.Responses;

namespace Pertolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private static readonly List<RegisterPet> _pet = new();
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterPet), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]

        public IActionResult Register([FromBody] RegisterPet request)
        {
            var response = new RegisterPetUseCases().execute(request);
            _pet.Add(request);
            int id = _pet.Count + 1;

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RegisterPet>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_pet);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<RegisterPet>), StatusCodes.Status200OK)]

        public IActionResult Get(int id) 
        { 

            return Ok(_pet[id]);
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
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseRegisterPet), StatusCodes.Status204Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404BadRequest)]
        public IActionResult Delete (int id)
        {

            return NoContent

        }
    }
}
