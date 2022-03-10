namespace DoctorApp.Application.View
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;

    using System.ComponentModel;

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

    public sealed partial class MainPage : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;

            listPanel.Background = Model.Color;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Name.Text ="Twoje id: "+Model.IdDoctor.ToString();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage), null);
        }

        private void Button_Click_yourPrescriptions(object sender, RoutedEventArgs e)
        {
            Controller.GetAllDoctorPrescriptionsCommand.Execute(null);
            this.Frame.Navigate(typeof(ReceptyPage), null);
        }

        private void Button_Click_schedule(object sender, RoutedEventArgs e)
        {
            Controller.GetDoctorAppointmentsCommand.Execute(null);
            this.Frame.Navigate(typeof(TerminarzPage), null);
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WypiszReceptePage), null);
        }

        private void Button_settings(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UstawieniaPage), null);
        }

    }
}
