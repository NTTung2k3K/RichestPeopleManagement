using Repository.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CountryService
    {
        private CountryRepository _repository = new CountryRepository();
        public List<Country> GetAll()
        {
            return _repository.GetAllCountry();
        }
        public Country GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Add(Country country)
        {
             _repository.AddCountry(country);
        }

        public void Update(Country country)
        {
             _repository.UpdateCountry(country);
        }

        public void Delete(Country country)
        {
             _repository.DeleteCountry(country);
        }

        public List<Country> Search(string? name)
        {
            var list = _repository.GetAllCountry();
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.CountryName.ToLower().Contains(name.ToLower())).ToList();
            }

            return list;

        }
    }
}
