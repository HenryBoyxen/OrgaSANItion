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
    public partial class ResetPassword : ContentPage
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private async void btn_senden_Clicked(object sender, EventArgs e)
        {
            //@TODO Check if username and email are correct
            ResetPassword2 newPage = new ResetPassword2();
            await Navigation.PushAsync(newPage);
        }
    }
}