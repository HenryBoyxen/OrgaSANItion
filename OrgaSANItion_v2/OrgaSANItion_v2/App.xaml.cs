using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OrgaSANItion_v2.Nav_Tabbed_Main;
using OrgaSANItion_v2.LoginPages;

namespace OrgaSANItion_v2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Login());
            //MainPage = new Nav_Tabbed();
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
