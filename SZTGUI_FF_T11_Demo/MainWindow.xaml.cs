
using System.Windows;

namespace SZTGUI_FF_T11_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NewGame newGameWin = new NewGame();
            newGameWin.ShowDialog();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
