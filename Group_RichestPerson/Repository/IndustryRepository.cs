using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class IndustryRepository
    {
        private BtnTopWordRichestContext _context;
        public List<Industry> GetAllIndustry()
        {
            _context = new BtnTopWordRichestContext();
            return _context.Industries.ToList();
        }

        public Industry GetById(int id)
        {
            _context = new BtnTopWordRichestContext();

            return _context.Industries.Find(id);
        }

        public void UpdateIndustry(Industry industry)
        {
           _context = new();
           _context.Update(industry);
           _context.SaveChanges();
        }

        public void AddIndustry(Industry industry)
        {
            _context = new();
            _context.Add(industry);
            _context.SaveChanges();
        }

		public void DeleteIndustry(Industry industry)
		{
            _context = new();
            _context.Remove(industry);
            _context.SaveChanges();
        }
	}
}
