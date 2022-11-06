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
            string sqlPassword = ServerLogic.Login_anmelden_sqlPassword(entry_username.Text);

            switch (sqlPassword)
            {
                case "unknown_error":
                    txtblock_feedback.TextColor = Color.Red;
                    txtblock_feedback.Text = "Es kam zu einem Fehler. Bitte versuche es erneut";
                    return;
                case "SocketException":
                    txtblock_feedback.TextColor = Color.Red;
                    txtblock_feedback.Text = "Es konnte keine Verbindung zum Server aufgebaut werden";
                    return;
                case "":
                    txtblock_feedback.TextColor = Color.Red;
                    txtblock_feedback.Text = "Der Benutzer existiert nicht";
                    return;
                default:
                    break;
            }

            bool result = SecurePasswordHasher.Verify(entry_password.Text, sqlPassword);
            if (!result)
            {
                txtblock_feedback.TextColor = Color.Red;
                txtblock_feedback.Text = "Das Passwort ist falsch";
                return;
            }
            Variables.SetUsername("123");
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