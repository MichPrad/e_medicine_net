namespace DoctorApp.Application.Model
{
    using DoctorApp.Application.Model.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using Windows.UI.Xaml.Media;

    public partial class Model : IData
    {
        public SolidColorBrush Color
        {
            get { return this.color; }
            set
            {
                this.color = value;

                this.RaisePropertyChanged("Color");
            }
        }
        private SolidColorBrush color;


        public string PatId
        {
            get { return this.patId; }
            set
            {
                this.patId = value;

                this.RaisePropertyChanged("PatId");
            }
        }
        private string patId;

        public DateTime ExpireDate
        {
            get { return this.expireDate; }
            set
            {
                this.expireDate = value;

                this.RaisePropertyChanged("ExpireDate");
            }
        }
        private DateTime expireDate;

        public string Lek1
        {
            get { return this.lek1; }
            set
            {
                this.lek1 = value;

                this.RaisePropertyChanged("Lek1");
            }
        }
        private string lek1;

        public string Lek2
        {
            get { return this.lek2; }
            set
            {
                this.lek2 = value;

                this.RaisePropertyChanged("Lek2");
            }
        }
        private string lek2;

        public string Dawka1
        {
            get { return this.dawka1; }
            set
            {
                this.dawka1 = value;

                this.RaisePropertyChanged("Dawka1");
            }
        }
        private string dawka1;

        public string Dawka2
        {
            get { return this.dawka2; }
            set
            {
                this.dawka2 = value;

                this.RaisePropertyChanged("Dawka2");
            }
        }
        private string dawka2;


        public int IdDoctor
        {
            get { return this.idDoctor; }
            set
            {
                this.idDoctor = value;

                this.RaisePropertyChanged("IdDoctor");
            }
        }
        private int idDoctor;

        public List<MedicalAppointmentData> AppointmentList
        {
            get { return this.appointmentList; }
            private set
            {
                this.appointmentList = value;

                this.RaisePropertyChanged("AppointmentList");
            }
        }
        private List<MedicalAppointmentData> appointmentList = new List<MedicalAppointmentData>();

        public List<PrescriptionData> PrescriptionList
        {
            get { return this.prescriptionList; }
            private set
            {
                this.prescriptionList = value;

                this.RaisePropertyChanged("PrescriptionList");
            }
        }
        private List<PrescriptionData> prescriptionList = new List<PrescriptionData>();

        public MedicalAppointmentData SelectedAppointment
        {
            get { return this.selectedAppointment; }
            set
            {
                this.selectedAppointment = value;

                this.RaisePropertyChanged("SelectedAppointment");
            }
        }
        private MedicalAppointmentData selectedAppointment;


        public PrescriptionData SelectedPrescription
        {
            get { return this.selectedPrescription; }
            set
            {
                this.selectedPrescription = value;

                this.RaisePropertyChanged("SelectedPrescription");
            }
        }
        private PrescriptionData selectedPrescription;
    }
}
