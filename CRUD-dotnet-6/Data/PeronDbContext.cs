using CRUD_dotnet_6.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_dotnet_6.Data
{
    public class PeronDbContext : DbContext
    {
        public PeronDbContext(DbContextOptions<PeronDbContext> options) : base(options)
        {        }
        public DbSet<PersonModel> Persons { get; set; }

        public PersonModel AddPerson(PersonModel model)
        {
            Persons.Add(model);
            SaveChanges();

            return model;
        }

        public bool DeletePersonById(int id)
        {
            PersonModel person = GetPersonById(id);
            if (person == null)
                return false;

            Persons.Remove(person);
            SaveChanges();

            return true;
        }

        public PersonModel EditPerson(PersonModel model)
        {
            Persons.Update(model);
            SaveChanges();

            return model;
        }

        public List<PersonModel> GetAllPersons()
        {
            var persons = Persons.ToList();

            return persons;
        }

        public PersonModel GetPersonById(int id)
        {
            PersonModel model = Persons.FirstOrDefault(p => p.Id == id);

            return model;
        }
    }
}
