using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrgaSANItion_v2.LoginPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void btn_registrieren_Clicked(object sender, EventArgs e)
        {
            //return if any entry is empty
            if (entry_benutzername.Text == null || entry_vorname.Text == null || entry_Nachname.Text == null ||
                entry_email.Text == null || picker_schule.SelectedItem == null || entry_passwort.Text == null ||
                entry_passwortwiederholen.Text == null)
                return;
            Login login = new Login();
            await Navigation.PushAsync(login);
        }
    }
}