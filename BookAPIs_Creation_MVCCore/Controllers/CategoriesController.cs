using BookAPIs_Creation_MVCCore.DTO;
using BookAPIs_Creation_MVCCore.Serivces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController:Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        // api/Categories/
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDTO>))]

        public IActionResult GetCategories()
        {
            var categories = categoryRepository.GetCategories().ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var CategoryList = new List<CategoryDTO>();

            foreach (var item in categories)
            {
                CategoryList.Add(new CategoryDTO()
                {
                    id = item.id,
                    name = item.name
                });
            }
            return Ok(CategoryList);
        }

        // api/Country/countryID
        [HttpGet("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CategoryDTO))]
        public IActionResult GetCategory(int categoryId)
        {
            if (!categoryRepository.CategoryExist(categoryId))
                return NotFound();
            var countries = categoryRepository.GetCategory(categoryId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = new CategoryDTO()
            {
                id = countries.id,
                name = countries.name
            };

            return Ok(category);
        }


        [HttpGet("book/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDTO>))]
        public IActionResult GetCategoryForBook(int bookId)
        {
            var countries = categoryRepository.GetCategoryForBook(bookId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var CategoryList = new List<CategoryDTO>();

            foreach (var item in countries)
            {
                CategoryList.Add(new CategoryDTO()
                {
                    id = item.id,
                    name = item.name
                });
            }

            return Ok(CategoryList);
        }

        // Todo GetBooksForCategory

    }
}
