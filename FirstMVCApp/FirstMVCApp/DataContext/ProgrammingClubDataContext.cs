using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.DataContext
{
    public class ProgrammingClubDataContext : DbContext
    {
        public ProgrammingClubDataContext(DbContextOptions<ProgrammingClubDataContext> options) : base(options) { }

        public DbSet<AnnouncementModel> Annoucements { get; set; }

        // public DbSet<MemberModel> Members { get; set; }
        // public DbSet<MembershipModel> Memberships { get; set; }
    }
}
