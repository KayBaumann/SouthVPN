using System.Windows;

namespace SouthVPN
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text.Trim();
            string password = passwordBox.Password.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Bitte Benutzername und Passwort eingeben.");
                return;
            }

            if (DatabaseHelper.UserExists(username))
            {
                MessageBox.Show("Benutzername ist bereits vergeben.");
                return;
            }

            bool success = DatabaseHelper.RegisterUser(username, password);
            if (success)
            {
                MessageBox.Show("Registrierung erfolgreich!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Registrierung fehlgeschlagen.");
            }
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
