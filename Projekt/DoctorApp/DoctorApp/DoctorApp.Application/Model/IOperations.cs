namespace DoctorApp.Application.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOperations
    {
        void LoadMedicalAppointmentsList();

        void LoadTodaysMedicalAppointmentsList();

        void LoadPrescriptionList();

        void AddPrescriptionObject();
    }
}
