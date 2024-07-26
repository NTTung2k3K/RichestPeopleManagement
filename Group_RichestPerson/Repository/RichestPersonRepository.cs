using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Repository.Models;
using System.Data.SqlClient;

namespace Repository
{
    public class RichestPersonRepository
    {
        private BtnTopWordRichestContext _context;
        public List<RichestPerson> GetAllRichestPersons()
        {
            _context = new BtnTopWordRichestContext();
            return _context.RichestPeople.Include(x => x.Country).Include(x => x.Industry).OrderBy(x => x.Rank).ToList();
        }
        public RichestPerson GetById(int id)
        {
            _context = new BtnTopWordRichestContext();

            return _context.RichestPeople.Find(id);
        }
        public void UpdateRichest(RichestPerson person)
        {
            using (_context = new BtnTopWordRichestContext())
            {
                _context.RichestPeople.Update(person);
                     _context.SaveChanges();
                var allRichestPeople = _context.RichestPeople.ToList();

                var sortedRichestPeople = allRichestPeople
                    .OrderByDescending(rp => rp.NetWorth)
                    .ToList();

                for (int i = 0; i < sortedRichestPeople.Count; i++)
                {
                    sortedRichestPeople[i].Rank = i + 1;
                }

                _context.SaveChanges();
            }
        }

        public void AddRichest(RichestPerson person)
        {
            using (_context = new BtnTopWordRichestContext())
            {

                _context.RichestPeople.Add(person);

                _context.SaveChanges();

                var allRichestPeople = _context.RichestPeople.ToList();

                var sortedRichestPeople = allRichestPeople
                    .OrderByDescending(rp => rp.NetWorth)
                    .ToList();

                for (int i = 0; i < sortedRichestPeople.Count; i++)
                {
                    sortedRichestPeople[i].Rank = i + 1;
                }

                _context.SaveChanges();
            }
        }

        public void DeleteRichest(RichestPerson person)
        {
            using (var context = new BtnTopWordRichestContext())
            {
                var personToDelete =  context.RichestPeople.Find(person.RichestPersonId);
                if (personToDelete == null)
                {
                    throw new InvalidOperationException("The person to be deleted does not exist.");
                }

                var rankAdded = personToDelete.Rank;
                var listRichestHigherThan = context.RichestPeople
                    .Where(x => x.Rank > rankAdded)
                    .ToList();

                foreach (var richestPerson in listRichestHigherThan)
                {
                    richestPerson.Rank--;
                }

                context.RichestPeople.Remove(personToDelete);

                context.SaveChanges();
            }
        }

    }
}
