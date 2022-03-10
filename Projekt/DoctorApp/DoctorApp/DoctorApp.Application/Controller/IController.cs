namespace DoctorApp.Application.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using System.ComponentModel;
    using System.Windows.Input;
    using DoctorApp.Application.Model;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ICommand GetDoctorAppointmentsCommand { get; }

        ICommand GetTodaysDoctorAppointmentsCommand { get; }

        ICommand GetAllDoctorPrescriptionsCommand { get; }

        ICommand AddPrescriptionCommand { get; }


    }
}
