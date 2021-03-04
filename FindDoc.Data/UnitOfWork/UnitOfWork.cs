using System;
using FindDoc.Data.Context;
using FindDoc.Data.Repositories.ApplicationUsers;
using FindDoc.Data.Repositories.Appointments;

namespace FindDoc.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IAppointmentRepository _appointmentRepository { get; }

        public IApplicationUserRepository _applicationUserRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _appointmentRepository = new AppointmentRepository(_context);
            _applicationUserRepository = new ApplicationUserRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
