using System.Collections.Generic;
using System.Windows;

namespace SouthVPN
{
    public partial class ServerSelectionWindow : Window
    {
        private readonly IVpnService vpnService = new FakeVpnService();

        public ServerSelectionWindow()
        {
            InitializeComponent();
            LoadServers();
        }

        private void LoadServers()
        {
            var servers = new List<string>
            {
                "Swiss-Test-Server",
                "Germany-Test-Server",
                "Austria-Test-Server"
            };

            serverComboBox.ItemsSource = servers;
            serverComboBox.SelectedIndex = 0;
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (serverComboBox.SelectedItem is string selectedServer)
            {
                statusText.Text = "Verbindung wird aufgebaut...";
                bool success = await vpnService.ConnectAsync(selectedServer);
                statusText.Text = success
                    ? $"✅ Verbunden mit {selectedServer}"
                    : "❌ Verbindung fehlgeschlagen";
            }
            else
            {
                statusText.Text = "Bitte wähle einen Server aus.";
            }
        }
    }
}
