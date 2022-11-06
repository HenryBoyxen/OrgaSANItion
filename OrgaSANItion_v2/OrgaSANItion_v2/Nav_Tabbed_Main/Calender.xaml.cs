using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgaSANItion_v2.Classes;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrgaSANItion_v2.Nav_Tabbed_Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calender : ContentPage
    {
        public Calender()
        {
            InitializeComponent();
            InitializeTextblocks();
        }
        private void InitializeTextblocks()
        {
            string[] content = ServerLogic.GetSanisAndSpringerFromDate(DateTime.Now);
            SetContentOfTextblocks(content);
        }

        private void SetContentOfTextblocks(string[] content)
        {
            if (content == null)
                return;
            if (content[0] != "null")
                txt_block_sani1.Text = content[0];
            else
                txt_block_sani1.Text = "Für das ausgewählte Datum ist kein 1. Sani eingeteilt";
            if (content[1] != "null")
                txt_block_sani2.Text = content[1];
            else
                txt_block_sani2.Text = "Für das ausgewählte Datum ist kein 2. Sani eingeteilt";
            if (content[2] != "null")
                txt_block_springer1.Text = content[2];
            else
                txt_block_springer1.Text = "Für das ausgewählte Datum ist kein 1. Springer eingeteilt";
            if (content[3] != "null")
                txt_block_springer2.Text = content[3];
            else
                txt_block_springer2.Text = "Für das ausgewählte Datum ist kein 2. Springer eingeteilt";
        }
    
        private async void btn_diensteanzeigen_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllDuties());
        }

        private void datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            string[] content = ServerLogic.GetSanisAndSpringerFromDate(datepicker.Date);
            SetContentOfTextblocks(content);
        }
    }
}