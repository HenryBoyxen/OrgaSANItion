using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgaSANItion_v2.Nav_Tabbed_Main.OrganisationPages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrgaSANItion_v2.Nav_Tabbed_Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Organisation : ContentPage
    {
        public Organisation()
        {
            InitializeComponent();
        }

        private async void btn_eintragung_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Eintragung());
        }

        private async void btn_austragung_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Austragung());
        }

        private async void btn_eventplanung_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Eventplanung()); 
        }
    }
}