namespace Doctor.Application.Model
{
    using Doctor.Application.Model.Data;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public interface INetwork
    {

        MedicalAppointmentData[] GetMedicalAppointments(int IdDoctor);

        MedicalAppointmentData[] GetTodaysMedicalAppointments(int IdDoctor);

        PrescriptionData[] GetPrescriptions(int IdDoctor);

        void AddPrescriptionPost(int IdDoctor, string IdPat, DateTime expire, string lek1, string lek2, string dawka1, string dawka2);

        void DeleteAppointment(int id);
        void DeletePrescription(int id);
    }
}
