using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgaSANItion_v2.Classes;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrgaSANItion_v2.Nav_Tabbed_Main.OrganisationPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eintragung : ContentPage
    {
        public Eintragung()
        {
            InitializeComponent();
            InitializeCheckboxes();
        }

        private void InitializeCheckboxes()
        {
            string[] array = ServerLogic.Eintragung_initializeCheckboxes();
            if(array == null)
            {
                txtblock_feedback.TextColor = Color.Red;
                txtblock_feedback.Text = "Es gab ein Problem mit der Serververbindung. Deine bisherige Auswahl konnte nicht geladen werden";
                return;
            }
            checkbox_sani_montag.IsChecked = array[0] == "True";
            checkbox_sani_dienstag.IsChecked = array[1] == "True";
            checkbox_sani_mittwoch.IsChecked = array[2] == "True";
            checkbox_sani_donnerstag.IsChecked = array[3] == "True";
            checkbox_sani_freitag.IsChecked = array[4] == "True";
            checkbox_springer_montag.IsChecked = array[5] == "True";
            checkbox_springer_dienstag.IsChecked = array[6] == "True";
            checkbox_springer_mittwoch.IsChecked = array[7] == "True";
            checkbox_springer_donnerstag.IsChecked = array[8] == "True";
            checkbox_springer_freitag.IsChecked = array[9] == "True";
        }

        private void btn_übernehmen_Clicked(object sender, EventArgs e)
        {
            string[] array = new string[10];
            array[0] = checkbox_sani_montag.IsChecked ? "true" : "false";
            array[1] = checkbox_sani_dienstag.IsChecked ? "true" : "false";
            array[2] = checkbox_sani_mittwoch.IsChecked ? "true" : "false";
            array[3] = checkbox_sani_donnerstag.IsChecked ? "true" : "false";
            array[4] = checkbox_sani_freitag.IsChecked ? "true" : "false";
            array[5] = checkbox_springer_montag.IsChecked ? "true" : "false";
            array[6] = checkbox_springer_dienstag.IsChecked ? "true" : "false";
            array[7] = checkbox_springer_mittwoch.IsChecked ? "true" : "false";
            array[8] = checkbox_springer_donnerstag.IsChecked ? "true" : "false";
            array[9] = checkbox_springer_freitag.IsChecked ? "true" : "false";
            bool confirmation = ServerLogic.Eintragung_eintragung(array);
            if (confirmation)
            {
                txtblock_feedback.TextColor = Color.Green;
                txtblock_feedback.Text = "Deine Änderungen wurden erfolgreich gespeichert";
            }
            else
            {
                txtblock_feedback.TextColor = Color.Red;
                txtblock_feedback.Text = "Es gab einen Fehler. Bitte versuche es erneut";
            }
        }
    }
}