namespace Doctor.Application.Controller
{
    using Doctor.Application.Model;
    using Doctor.Application.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;

            this.GetDoctorAppointmentsCommand = new ControllerCommand(this.GetDoctorAppointments);

            this.GetTodaysDoctorAppointmentsCommand = new ControllerCommand(this.GetTodaysDoctorAppointments);

            this.GetAllDoctorPrescriptionsCommand = new ControllerCommand(this.GetAllDoctorPrescriptions);

            this.AddPrescriptionCommand = new ControllerCommand(this.AddPrescription);

            this.DeletePrescriptionCommand = new ControllerCommand(this.DeletePrescription);

            this.DeleteAppointmentCommand = new ControllerCommand(this.DeleteAppointment);
        }
    }
}
