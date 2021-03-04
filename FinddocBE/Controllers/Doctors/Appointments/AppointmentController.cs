using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindDoc.Data.Entity;
using FindDoc.Data.Entity.Appointments;
using FindDoc.Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace FinddocBE.Controllers.Doctors.Appointments
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController: ControllerBase
    {

        public AppointmentController()
        {
        }
    }
}
