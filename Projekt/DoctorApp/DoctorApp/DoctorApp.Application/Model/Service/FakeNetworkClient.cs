namespace DoctorApp.Application.Model
{
    using DoctorApp.Application.Model.Data;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class FakeNetworkClient : INetwork
    {
        public MedicalAppointmentData[] GetMedicalAppointments(int Id)
        {
            throw new NotImplementedException();
        }

        public MedicalAppointmentData[] GetTodaysMedicalAppointments(int Id)
        {
            throw new NotImplementedException();
        }

        public PrescriptionData[] GetPrescriptions(int IdDoctor)
        {
            throw new NotImplementedException();
        }

        public void AddPrescriptionPost(int IdDoctor, string IdPat, DateTime expire, string lek1, string lek2, string dawka1, string dawka2)
        {
            throw new NotImplementedException();
        }

    }
}
