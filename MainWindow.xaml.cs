using RegistroDeUsuarios.UI.Registros;
using System.Windows;

namespace RegistroDeUsuarios
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

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            rRoles r = new rRoles();
            r.Show();

        }
    }
}
