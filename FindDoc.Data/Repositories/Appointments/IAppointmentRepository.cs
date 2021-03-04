using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FindDoc.Data.Entity.Appointments;

namespace FindDoc.Data.Repositories.Appointments
{
    public interface IAppointmentRepository: IGenericRepository<Appointment>
    {
        public Task<List<Appointment>> GetAppointmentsForDoctorById(string doctorId, CancellationToken cancellationToken);
    }
}
