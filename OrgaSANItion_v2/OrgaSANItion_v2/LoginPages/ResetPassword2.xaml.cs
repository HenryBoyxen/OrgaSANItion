using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrgaSANItion_v2.LoginPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassword2 : ContentPage
    {
        public ResetPassword2()
        {
            InitializeComponent();
        }

        private async void btn_weiter_Clicked(object sender, EventArgs e)
        {
            //@TODO Check if new password & code is correct
            Login login = new Login();
            await Navigation.PushAsync(login);
        }
    }
}