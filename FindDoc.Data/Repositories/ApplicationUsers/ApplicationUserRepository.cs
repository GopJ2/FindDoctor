using System;
using System.Threading.Tasks;
using FindDoc.Data.Context;
using FindDoc.Data.Entity;

namespace FindDoc.Data.Repositories.ApplicationUsers
{
    public class ApplicationUserRepository: GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { }

      
    }
}
