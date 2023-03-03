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
    public partial class AllDuties : ContentPage
    {
        public AllDuties()
        {
            InitializeComponent();
            InitializeAllDuties();
        }
        private void InitializeAllDuties()
        {
            Queue<string> queue;
            try
            {
                Client client = new Client();
                client.WriteString("Calender_initializeAllDuties");
                client.ReadString();
                client.WriteString(Variables.GetUsername());
                queue = (Queue<string>)client.ReadObject();
                client.Dispose();
            }
            catch
            {
                return;
            }

            if (queue.Count == 0)
            {
                Label label = new Label()
                {
                    Text = "Du bist für keine Dienste eingeteilt",
                    FontSize = 22
                };
                stacklayout_main.Children.Add(label);
                return;
            }
            CreateLabel("Datum", 0, 0, 22);
            CreateLabel("Funktion", 0, 1, 22);
            for (int i = 0; i < queue.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    CreateLabel(queue.Peek(), i + 1, j, 18);
                    queue.Dequeue();
                }
            }
        }

        private void CreateLabel(string text, int row, int column, int fontsize)
        {
            Label label = new Label();
            label.Text = text;
            label.FontSize = fontsize;
            label.SetValue(Grid.RowProperty, row);
            label.SetValue(Grid.ColumnProperty, column);
            grid_main.Children.Add(label);
        }
    }
}