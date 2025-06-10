using System.Windows;
using System.Windows.Controls;

namespace SouthVPN
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

        // App beenden
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Verbindung (simuliert)
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ServerComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedServer = selectedItem.Content.ToString();
                MessageBox.Show($"Verbinde mit {selectedServer} ...", "Verbindung", MessageBoxButton.OK, MessageBoxImage.Information);

                // TODO: Hier kannst du echte VPN-Logik einbauen
            }
            else
            {
                MessageBox.Show("Bitte wähle einen Server aus.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Zurück zum Login-Fenster
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
