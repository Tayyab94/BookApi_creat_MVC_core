using BookAPIs_Creation_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Serivces
{
    public class CounytyRepository : ICountryRepository
    {
        private readonly BookDbContext context;

        public CounytyRepository(BookDbContext context)
        {
            this.context = context;
        }

        public bool CoutryExist(int countryId)
        {
            return context.Countries.Any(s => s.id==countryId);
        }

        public ICollection<Author> GetAuthorFromCountry(int countryId)
        {
            return context.Authors.Where(c => c.Country.id == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return context.Countries.OrderBy(s=>s.name).ToList();
        }

        public Country GetCountry(int countryId)
        {
            return context.Countries.Where(s => s.id == countryId).FirstOrDefault();
        }

        public Country GetCounytyOfAuthor(int authorId)
        {
            return context.Authors.Where(x => x.id == authorId).Select(c => c.Country).FirstOrDefault();
        }
    }
}
