using System;
using FindDoc.Data.Repositories.ApplicationUsers;
using FindDoc.Data.Repositories.Appointments;

namespace FindDoc.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    { 
        IAppointmentRepository _appointmentRepository { get; }
        IApplicationUserRepository _applicationUserRepository { get; }

        int Complete();
    }
}
