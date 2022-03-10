namespace DoctorApp.Application.View
{
    using DoctorApp.Application.Model;
    using DoctorApp.Application.Model.Data;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Windows.UI.Xaml.Data;



    public class NodeDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            NodeData nodeData = (NodeData)value;

            return String.Format("{0} at ({1},{2})", nodeData.Id, nodeData.Position.X, nodeData.Position.Y);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
