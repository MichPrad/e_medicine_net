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
    using DoctorApp.Application.View;
    using Windows.UI;

    public sealed partial class UstawieniaPage : Page
    {

        public IData Model { get; private set; }

        public IController Controller { get; private set; }
    
        public UstawieniaPage()
        {
            this.InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;

            mainPage.Background = Model.Color;
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

        private void Button_Yellow(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Color = new SolidColorBrush(Colors.LightYellow);
                mainPage.Background = Model.Color;
            }
            catch (Exception)
            {
            }

        }

        private void Button_Blue(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Color = new SolidColorBrush(Colors.CornflowerBlue);
                mainPage.Background = Model.Color;
            }
            catch (Exception)
            {
            }

        }

        private void Button_Gray(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Color = new SolidColorBrush(Colors.Gray);
                mainPage.Background = Model.Color;
            }
            catch (Exception)
            {
            }

        }
    }
}
