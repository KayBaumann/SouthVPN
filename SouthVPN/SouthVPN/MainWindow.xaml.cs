using System.Windows;
using System.Windows.Controls;

namespace SouthVPN
{
	public partial class MainWindow : Window
	{
		private readonly IVpnService vpnService = new OpenVpnService();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private async void ConnectButton_Click(object sender, RoutedEventArgs e)
		{
			// Da nur ein Server da ist, nehmen wir immer den einen
			if (ServerListBox.SelectedItem is ListBoxItem item)
			{
				string serverName = item.Content.ToString(); // z.B. "SouthVPN Server"
				bool connected = await vpnService.ConnectAsync("server.ovpn"); // Hier der Pfad zur config

				if (connected)
				{
					MessageBox.Show($"Verbunden mit {serverName}", "VPN", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				else
				{
					MessageBox.Show("Verbindung fehlgeschlagen.", "VPN", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Kein Server verfügbar.");
			}
		}

		private async void LogoutButton_Click(object sender, RoutedEventArgs e)
		{
			await vpnService.DisconnectAsync();

			LoginWindow login = new LoginWindow();
			login.Show();
			this.Close();
		}
	}
}
