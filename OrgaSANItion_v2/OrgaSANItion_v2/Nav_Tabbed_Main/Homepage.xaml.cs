﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgaSANItion_v2.Classes;
using OrgaSANItion_v2.Nav_Tabbed_Main.OrganisationPages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrgaSANItion_v2.Nav_Tabbed_Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        public Homepage()
        {
            InitializeComponent();
            InitializeTextblocks();
        }

        private void InitializeTextblocks()
        {
            //initialize Heutige Sanis & Springer
            string[] content;
            try
            {
                Client client = new Client();
                client.WriteString("GetSanisAndSpringerFromDate");
                client.ReadString();
                client.WriteString(DateTime.Now.ToShortDateString());
                content = (string[])client.ReadObject();
                client.Dispose();
            }
            catch
            {
                return;
            }

            if (content == null)
                return;
            if (content[0] != "null")
                txt_block_sani1.Text = content[0];
            else
                txt_block_sani1.Text = "Heute ist kein 1. Sani eingeteilt";
            if (content[1] != "null")
                txt_block_sani2.Text = content[1];
            else
                txt_block_sani2.Text = "Heute ist kein 2. Sani eingeteilt";
            if (content[2] != "null")
                txt_block_springer1.Text = content[2];
            else
                txt_block_springer1.Text = "Heute ist kein 1. Springer eingeteilt";
            if (content[3] != "null")
                txt_block_springer2.Text = content[3];
            else
                txt_block_springer2.Text = "Heute ist kein 2. Springer eingeteilt";
            
            //initialize Dein nächster Dienst
            string[] dateAndFunction = new string[2];
            try
            {
                Client client = new Client();
                client.WriteString("HomePage_initializeNextDuty");
                client.ReadString();
                client.WriteString(Variables.GetUsername());
                dateAndFunction[0] = client.ReadString();
                client.WriteString("next");
                dateAndFunction[1] = client.ReadString();
                client.Dispose();
            }
            catch
            {
                return;
            }

            if (dateAndFunction[0] != "null")
                txt_block_nächsterdienst.Text = dateAndFunction[0] + " als " + dateAndFunction[1];
            else
                txt_block_nächsterdienst.Text = "Du bist noch nicht eingeteilt";
        }

        private void btn_versäumterdienst_Clicked(object sender, EventArgs e)
        {

        }

        private async void btn_krankmelden_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Austragung());
        }
    }
}