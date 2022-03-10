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
    using Windows.UI;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class LoginPage : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }
        public LoginPage()
        {
            this.InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;

            Model.Color = new SolidColorBrush(Colors.CornflowerBlue);
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


        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
