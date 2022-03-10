namespace DoctorApp.Application.View.Pages
{
    using DoctorApp.Application.Controller;
    using DoctorApp.Application.Model;
    using DoctorApp.Application.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class WypiszReceptePage : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }
        public WypiszReceptePage()
        {
            this.InitializeComponent();

            arrivalDatePicker.Date= DateTime.Now;

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            Model.ExpireDate = DateTime.Now;

            this.DataContext = this.Controller;

            wypiszReceptePage.Background = Model.Color;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int doctorId = Convert.ToInt32(id.Text);
                Model.IdDoctor = doctorId;
                Controller.GetTodaysDoctorAppointmentsCommand.Execute(null);
                this.Frame.Navigate(typeof(MainPage), null);
            }
            catch (Exception ) {

                var messageDialog = new MessageDialog("Błędne dane");
                messageDialog.ShowAsync();
            }

        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller.GetTodaysDoctorAppointmentsCommand.Execute(null);
                this.Frame.Navigate(typeof(MainPage), null);
            }
            catch (Exception)
            {
            }

        }

        private void Button_Check(object sender, RoutedEventArgs e)
        {
            try
            {
                int one = Convert.ToInt32(id.Text);
                int two = Convert.ToInt32(lek1Dawka.Text);
                int three = Convert.ToInt32(lek2Dawka.Text);

            }
            catch (Exception)
            {
                var messageDialog = new MessageDialog("Błędne dane");
                messageDialog.ShowAsync();
            }
        }

        private void ArrivalDatePicker_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args1)
        {
            DateTime witam = DateTime.Now;

            DateTime arrivalDateTime = new DateTime(args1.NewDate.Value.Year, args1.NewDate.Value.Month, args1.NewDate.Value.Day,
                                       witam.Hour, witam.Minute, witam.Second);
            Model.ExpireDate = arrivalDateTime;
        }


        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
