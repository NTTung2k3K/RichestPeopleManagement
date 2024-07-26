using Repository;
using Repository.Models;

namespace Services
{
    public class RichestPersonService
    {
        private RichestPersonRepository _repository = new RichestPersonRepository();
        public List<RichestPerson> GetAll()
        {
            return _repository.GetAllRichestPersons();
        }
        public void Add(RichestPerson richestPerson)
        {
             _repository.AddRichest(richestPerson);
        }
        public void Update(RichestPerson richestPerson)
        {
             _repository.UpdateRichest(richestPerson);
        }
        public void Delete(RichestPerson richestPerson)
        {
             _repository.DeleteRichest(richestPerson);
        }
        public RichestPerson GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<RichestPerson> Search(string? name,int? rank,string? tag)
        {
            var list = _repository.GetAllRichestPersons();
            if (!string.IsNullOrEmpty(name)) 
            { 
                list = list.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            if (rank != -1)
            {
                list = list.Where(x => x.Rank == rank).ToList();
            }
            if(!string.IsNullOrEmpty(tag))
            {
                list = list.Where(x => x.Industry.IndustryName == tag || x.Country.CountryName == tag).ToList();
            }

            return list;

        }

    }
}
