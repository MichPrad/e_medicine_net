namespace DoctorApp.Application.View
{
    using DoctorApp.Application.Model.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Data;

    class PrescriptionDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            PrescriptionData prescriptionData = (PrescriptionData)value;

            IEnumerable<string> lista = prescriptionData.Medicines.Select(s => s.Name + " " + s.DailyDose);

            StringBuilder stringList = new StringBuilder();

            int i = 0;
            foreach (string pre in lista)
            {
                if (i != lista.Count()-1)
                {
                    stringList.Append(pre + ", ");
                }
                else stringList.Append(pre);
                i++;
            }

            return String.Format("Pacjent:{0} Ważność:{1}, Leki: {2}", prescriptionData.IdPatient, prescriptionData.DateOfExpiration.Year, stringList);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
