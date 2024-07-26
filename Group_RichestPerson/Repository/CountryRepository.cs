using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CountryRepository
    {
        private BtnTopWordRichestContext _context;
        public List<Country> GetAllCountry()
        {
            _context = new BtnTopWordRichestContext();
            return _context.Countries.ToList();
        }

        public Country GetById(int id)
        {
            _context = new BtnTopWordRichestContext();

            return _context.Countries.Find(id);
        }

        public void UpdateCountry(Country country)
        {
            _context = new();
            _context.Update(country);
            _context.SaveChanges();
        }

        public void AddCountry(Country country)
        {
            _context = new();
            _context.Add(country);
            _context.SaveChanges();
        }

        public void DeleteCountry(Country country)
        {
            _context = new();
            _context.Remove(country);
            _context.SaveChanges();
        }
    }
}
