namespace Doctor.Application.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using System.ComponentModel;
    using System.Windows.Input;
    using Doctor.Application.Model;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ICommand GetDoctorAppointmentsCommand { get; }

        ICommand GetTodaysDoctorAppointmentsCommand { get; }

        ICommand GetAllDoctorPrescriptionsCommand { get; }

        ICommand AddPrescriptionCommand { get; }

        ICommand DeletePrescriptionCommand { get; }

        ICommand DeleteAppointmentCommand { get; }
        Task AddPrescriptionAsync();
        Task GetDoctorAppointmentsAsync();
        Task GetTodaysDoctorAppointmentsAsync();

        Task GetAllDoctorPrescriptionsAsync();
        Task DeletePrescriptionAsync();
        Task DeleteAppointmentAsync();

    }
}
