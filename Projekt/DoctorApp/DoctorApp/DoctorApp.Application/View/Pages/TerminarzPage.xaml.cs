namespace DoctorApp.Application.View
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    using DoctorApp.Application.Model;
    using DoctorApp.Application.Controller;
    using DoctorApp.Application.Utilities;
    using DoctorApp.Application.View.Pages;

    public sealed partial class TerminarzPage : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }
        public TerminarzPage()
        {
            this.InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;

            terminarzPage.Background = Model.Color;
        }
        private void Click_goBack(object sender, RoutedEventArgs e)
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
    }
}
