using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SZTGUI_FF_T11_Demo.VM;

namespace SZTGUI_FF_T11_Demo
{
    /// <summary>
    /// Interaction logic for GameResults.xaml
    /// </summary>
    public partial class GameResults : Window
    {
        //GameResultsVM VM;

        public GameResults()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
