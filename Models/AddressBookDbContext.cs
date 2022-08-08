using Microsoft.EntityFrameworkCore;

namespace AddressBook.Models
{
    public class AddressBookDbContext:DbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options) : base(options)
        {
        }

        public DbSet<AddressBookContacts> AddressBook { get; set; }
    }
}
