using Repository.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class IndustryService
    {
        private IndustryRepository _repository = new IndustryRepository();
        public List<Industry> GetAll()
        {
            return _repository.GetAllIndustry();
        }
        public Industry GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Add(Industry industry)
        {
             _repository.AddIndustry(industry);
        }

        public void Update(Industry industry)
        {
             _repository.UpdateIndustry(industry);
        }

        public void Delete(Industry industry)
        {
             _repository.DeleteIndustry(industry);
        }

        public List<Industry> Search(string? name)
        {
            var list = _repository.GetAllIndustry();
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.IndustryName.ToLower().Contains(name.ToLower())).ToList();
            }

            return list;

        }
    }
}
