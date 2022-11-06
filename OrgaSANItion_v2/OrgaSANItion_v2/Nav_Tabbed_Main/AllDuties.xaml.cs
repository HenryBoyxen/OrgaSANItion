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
            Queue<string> queue = ServerLogic.AllDuties_initializeAllDuties();
            for (int i = 0; i < queue.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    CreateLabel(queue.Peek(), i + 1, j);
                    queue.Dequeue();
                }
            }
        }

        private void CreateLabel(string text, int row, int column)
        {
            Label label = new Label();
            label.Text = text;
            label.SetValue(Grid.RowProperty, row);
            label.SetValue(Grid.ColumnProperty, column);
            grid_main.Children.Add(label);
        }
    }
}