using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrgaSANItion_v2.Nav_Tabbed_Main.OrganisationPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eventplanung : ContentPage
    {
        public Eventplanung()
        {
            InitializeComponent();
            //initialisierung mit database statt false
            bool eventExists = true;
            if (eventExists)
                DisplayEvents();
            else
                DisplayNoEvents();
        }

        private void DisplayEvents()
        {
            Button button = CreateEventButton("Tag der Tür");
            Button button2 = CreateEventButton("Tag der Türen");
            Button button3 = CreateEventButton("Tag der Tür");
            Button button4 = CreateEventButton("Tag der Türen");
            Button button5 = CreateEventButton("Tag der Tür");
            Button button6 = CreateEventButton("Tag der Türen");
            stacklayout_main.Children.Add(button);
            stacklayout_main.Children.Add(button2);
            stacklayout_main.Children.Add(button3);
            stacklayout_main.Children.Add(button4);
            stacklayout_main.Children.Add(button5);
            stacklayout_main.Children.Add(button6);
        }

        private Button CreateEventButton(string eventName)
        {
            Button button = new Button()
            {
                HeightRequest = 150,
                Text = eventName,
                FontSize = 18
            };
            return button;
        }

        private void DisplayNoEvents()
        {
            Label label = new Label()
            {
                FontSize = 18,
                Text = "Aktuell sind keine Events in Planung",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            stacklayout_main.Children.Add(label);
        }
    }
}