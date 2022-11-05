﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private async void btn_diensteanzeigen_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllDuties());
        }
    }
}