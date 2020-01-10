using BookAPIs_Creation_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Serivces
{
   public interface ICountryRepository
    {
         ICollection<Country> GetCountries();
        Country GetCountry(int countryId);
        Country GetCounytyOfAuthor(int authorId);

        ICollection<Author> GetAuthorFromCountry(int countryId);

        bool CoutryExist(int countryId);

    }
}
