namespace DoctorApp.Application.Controller
{
    using DoctorApp.Application.Model;
    using DoctorApp.Application.Utilities;
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
        }
    }
}
