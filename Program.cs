﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YearCursWork
{
    public partial class App : Application
    {
        public static string DefaultImageId = "default_image";
        public static string ImageIdToSave = null;
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("************************************************************************");

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}