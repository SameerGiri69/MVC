using Microsoft.AspNetCore.Mvc;
using WEBSITE101.DTO;
using WEBSITE101.Interface;
using WEBSITE101.Model;

namespace WEBSITE101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {

        private readonly IOwnerRepository _ownerRepository;
        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwner(int ownerId)
        {
            var exists = _ownerRepository.OwnerExists(ownerId);
            if (exists == false)
                return NotFound();
            var owner = _ownerRepository.GetOwner(ownerId);
            return Ok(owner);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddOwner(OwnerDto ownerObj)
        {
            var owner = _ownerRepository.AddOwner(ownerObj);
            if (owner == false)
                return NotFound();
            return Ok();
        }
        [HttpPut("{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateOwner(OwnerDto ownerObj)
        {
            var rowsAffected = _ownerRepository.UpdateOwner(ownerObj);
            if (rowsAffected == false)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOwner(int ownerId)
        {
            var result = _ownerRepository.DeleteOwner(ownerId);
            if (result == false)
                return BadRequest();
            return Ok();

        }


    }
}
