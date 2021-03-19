using AutoMapper;
using Electronic.API.Controllers.Resources;
using Electronic.API.Core.Models;
using Electronic.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronic.API.Controllers
{
    [Route("/api/categories")]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IElectronicRepository electronicRepository
            , IMapper mapper, IUnitOfWork unitOfWork)
            : base(electronicRepository, mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(string name = null)
        {
            var categories = await _electronicRepository.GetCategories(name);

            return Ok(_mapper.Map<IEnumerable<KeyValuePairResource>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _electronicRepository.GetCategory(id);

            if (category == null)
                return NotFound();

            return Ok(_mapper.Map<KeyValuePairResource>(category));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] KeyValuePairResource categoryResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _electronicRepository.IsCategoryNameUnique(categoryResource.Name))
            {
                ModelState.AddModelError("Name", "This Category name used before.");
                return BadRequest(ModelState);
            }

            var category = _mapper.Map<Category>(categoryResource);
            _electronicRepository.AddCategory(category);
            await _unitOfWork.ConfirmChanges();

            return Ok(_mapper.Map<KeyValuePairResource>(category));
        }
    }
}
