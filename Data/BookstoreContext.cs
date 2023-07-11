using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreMH.Data;

public class BookstoreContext : IdentityDbContext<ApplicationUser>
{
    public BookstoreContext(DbContextOptions<BookstoreContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}
