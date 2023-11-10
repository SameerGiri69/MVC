using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using WEBSITE101.DTO;
using WEBSITE101.Interface;
using WEBSITE101.Model;

namespace WEBSITE101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpPost]
        public IActionResult AddCategory(string name)
        {
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.Name = name;

            var result = _categoryRepository.AddCategory(categoryDto);
            if (result == false)
                return BadRequest();
            return Ok();
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int id)
        {
            var result = _categoryRepository.GetCategory(id);
            if(result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut]
        [ProducesResponseType(400)]
        public IActionResult UpdateCategory(CategoryDto categoryDto)
        {
            var result = _categoryRepository.UpdateCategory(categoryDto);
            if(result == false)
                return NotFound();
            return Ok();
        }
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryRepository.DeleteCategory(id);
            if(result == false) return NotFound();
            return Ok();
        }




    }
}
