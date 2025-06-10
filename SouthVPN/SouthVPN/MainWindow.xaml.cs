using System.Windows;
using System.Windows.Controls;

namespace SouthVPN
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // placeholder for the openvpn connection
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ServerListBox.SelectedItem is ListBoxItem item)
            {
                string serverName = item.Content.ToString();
                MessageBox.Show($"Verbinde mit {serverName} ...", "VPN", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Bitte wähle einen Server aus.");
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
