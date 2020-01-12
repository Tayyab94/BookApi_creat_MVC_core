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
    public class CountryController:Controller
    {
        private readonly ICountryRepository countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }


        // api/Country/counry
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDTO>))]

        public IActionResult GetCountries()
        {
            var countries = countryRepository.GetCountries().ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var CountyList = new List<CountryDTO>();

            foreach (var item in countries)
            {
                CountyList.Add(new CountryDTO()
                {
                    id = item.id,
                    name = item.name
                });
            }
            return Ok(CountyList);
        }

        // api/Country/countryID
        [HttpGet("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDTO))]
        public IActionResult GetCountry(int countryId)
        {
            if (!countryRepository.CoutryExist(countryId))
                return NotFound();
            var countries = countryRepository.GetCountry(countryId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var County = new CountryDTO()
            {
                id = countries.id,
                name = countries.name
            };

            return Ok(County);
        }


        [HttpGet("author/{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDTO))]
        public IActionResult GetCountryOfAuthor(int authorId)
        {
            var countries = countryRepository.GetCounytyOfAuthor(authorId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var County = new CountryDTO()
            {
                id = countries.id,
                name = countries.name
            };

            return Ok(County);

        }


        //api/countries/countryId/author
        [HttpGet("{countryId}/author")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDTO>))]

        public IActionResult GetAuthorsFromCountry(int countryId)
        {
            if (!countryRepository.CoutryExist(countryId))
                return NotFound();

            var author = countryRepository.GetAuthorFromCountry(countryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authorDTO_list = new List<AuthorDTO>();

            foreach (var item in author)
            {
                authorDTO_list.Add(new AuthorDTO
                {
                     Id=item.id,
                      FirstName=item.first_Name,
                       LastName=item.last_NameW
                });
            }

            return Ok(authorDTO_list);
        }
    }
}
