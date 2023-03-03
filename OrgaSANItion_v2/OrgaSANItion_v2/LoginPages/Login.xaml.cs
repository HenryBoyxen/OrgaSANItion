using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgaSANItion_v2.Nav_Tabbed_Main;
using OrgaSANItion_v2.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrgaSANItion_v2.LoginPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btn_anmelden_Clicked(object sender, EventArgs e)
        {
            //Return if username or password is null
            if (entry_username.Text == null || entry_password.Text == null)
            {
                txtblock_feedback.TextColor = Color.Red;
                txtblock_feedback.Text = "Der Benutzername und das Passwort dürfen nicht leer sein";
                return;
            }
            //Get password fitting to username or "" if the username doesnt exist
            string sqlPassword;
            try
            {
                Client client = new Client();
                client.WriteString("Anmelden_anmelden");
                client.ReadString();
                client.WriteString(entry_username.Text);
                sqlPassword = client.ReadString();
                client.Dispose();
            }
            catch
            {
                txtblock_feedback.TextColor = Color.Red;
                txtblock_feedback.Text = "Eine Verbindung zum Server ist nicht möglich";
                return;
            }
            //return if there is no Password -> User doesnt exist
            if(sqlPassword == "")
            {
                txtblock_feedback.TextColor = Color.Red;
                txtblock_feedback.Text = "Der Benutzer existiert nicht";
                return;
            }
            //Verify Password
            bool result = SecurePasswordHasher.Verify(entry_password.Text, sqlPassword);
            if (!result)
            {
                txtblock_feedback.TextColor = Color.Red;
                txtblock_feedback.Text = "Das Passwort ist falsch";
                return;
            }
            Variables.SetUsername(entry_username.Text);
            Nav_Tabbed nav_Tabbed = new Nav_Tabbed();
            await Navigation.PushAsync(nav_Tabbed);
        }

        private async void btn_registrieren_Clicked(object sender, EventArgs e)
        {
            Register register = new Register();
            await Navigation.PushAsync(register);
        }

        private async void btn_passwortzurücksetzen_Clicked(object sender, EventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword();
            await Navigation.PushAsync(resetPassword);
        }
    }
}