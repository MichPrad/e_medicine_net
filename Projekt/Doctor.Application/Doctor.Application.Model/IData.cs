namespace Doctor.Application.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.ComponentModel;
    using Doctor.Application.Model.Data;

    public interface IData : INotifyPropertyChanged
    {
        string PatId {get; set;}
        DateTime ExpireDate {get; set;}
        string Lek1 { get; set; }
        string Lek2 { get; set; }
        string Dawka1 { get; set; }
        string Dawka2 { get; set; }

        int IdDoctor { get; set; }

        List<MedicalAppointmentData> AppointmentList { get; }

        MedicalAppointmentData SelectedAppointment { get; set; }

        List<PrescriptionData> PrescriptionList { get; }

        PrescriptionData SelectedPrescription { get; set; }
    }
}
