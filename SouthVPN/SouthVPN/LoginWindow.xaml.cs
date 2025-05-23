using System.Windows;

namespace SouthVPN
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Password;

            if (username == "admin" && password == "vpn123")
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login fehlgeschlagen", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
