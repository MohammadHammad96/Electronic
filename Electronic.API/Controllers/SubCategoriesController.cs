using AutoMapper;
using Electronic.API.Controllers.Resources;
using Electronic.API.Core.Models;
using Electronic.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronic.API.Controllers
{
    [Route("/api/categories/{categoryId}/subcategories")]
    public class SubCategoriesController : BaseController
    {
        public SubCategoriesController(IElectronicRepository electronicRepository
            , IMapper mapper, IUnitOfWork unitOfWork)
            : base(electronicRepository, mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategories(int categoryId, string name = null)
        {
            var category = await _electronicRepository.GetCategory(categoryId);
            if (category == null)
                return NotFound();

            var subCategories = await _electronicRepository.GetSubCategories(categoryId, name);

            return Ok(_mapper.Map<IEnumerable<KeyValuePairResource>>(subCategories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategory(int categoryId, int id)
        {
            var category = await _electronicRepository.GetCategory(id);
            if (category == null)
                return NotFound();

            var subCategory = await _electronicRepository.GetSubCategory(categoryId, id);
            if (subCategory == null)
                return NotFound();

            return Ok(_mapper.Map<KeyValuePairResource>(subCategory));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(int categoryId
            , [FromBody] KeyValuePairResource subCategoryResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _electronicRepository.GetCategory(categoryId);
            if (category == null)
                return NotFound();

            if (!await _electronicRepository.IsSubCategoryNameUnique(categoryId, subCategoryResource.Name))
            {
                ModelState.AddModelError("Name", "This Sub category name used before.");
                return BadRequest(ModelState);
            }

            var subCategory = _mapper.Map<SubCategory>(subCategoryResource);
            _electronicRepository.AddSubCategory(category, subCategory);
            await _unitOfWork.ConfirmChanges();

            return Ok(_mapper.Map<KeyValuePairResource>(subCategory));
        }
    }
}
