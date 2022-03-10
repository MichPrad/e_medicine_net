namespace DoctorApp.Application.Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MedicalAppointmentData
    {
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public DateTime StartDateOfTheVisit { get; set; }
        public DateTime EndDateOfTheVisit { get; set; }
        public PlaceData Place { get; set; }

    }
}
