namespace DoctorApp.Application.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using System.Windows.Input;

    public partial class Controller : IController
    {

        public ICommand GetDoctorAppointmentsCommand { get; private set; }

        public ICommand GetTodaysDoctorAppointmentsCommand { get; private set; }

        public ICommand GetAllDoctorPrescriptionsCommand { get; private set; }

        public ICommand AddPrescriptionCommand { get; private set; }


        private void AddPrescription()
        {
            this.Model.AddPrescriptionObject();
        }

        private void GetDoctorAppointments()
        {
            this.Model.LoadMedicalAppointmentsList();
        }

        private void GetTodaysDoctorAppointments()
        {
            this.Model.LoadTodaysMedicalAppointmentsList();
        }

        private void GetAllDoctorPrescriptions()
        {
            this.Model.LoadPrescriptionList();
        }

    }
}
