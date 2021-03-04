using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FindDoc.Data.Context;
using FindDoc.Data.Entity.Appointments;
using Microsoft.EntityFrameworkCore;

namespace FindDoc.Data.Repositories.Appointments
{
    public class AppointmentRepository: GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext applicationDbContext): base(applicationDbContext)
        {}

        public async Task<List<Appointment>> GetAppointmentsForDoctorById(string doctorId, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Appointments.Where(x => x.DoctorId == doctorId).ToListAsync(cancellationToken);
        }
    }
}
