namespace DoctorApp.Application.View
{
    using DoctorApp.Application.Model.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Data;

    class MedicalAppointmentDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            MedicalAppointmentData appointmentData = (MedicalAppointmentData)value;

            return String.Format("{0} w {1}", appointmentData.StartDateOfTheVisit, appointmentData.Place.Name);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
