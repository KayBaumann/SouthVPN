using System.Threading.Tasks;

namespace SouthVPN
{
    public class FakeVpnService : IVpnService
    {
        private bool isConnected = false;
        private string currentServer = "";

        public async Task<bool> ConnectAsync(string serverName)
        {
            await Task.Delay(1000); // Simuliert Verbindung
            isConnected = true;
            currentServer = serverName;
            return true;
        }

        public async Task<bool> DisconnectAsync()
        {
            await Task.Delay(500); // Simuliert Trennung
            isConnected = false;
            currentServer = "";
            return true;
        }

        public string GetStatus()
        {
            return isConnected ? $"Verbunden mit {currentServer}" : "Nicht verbunden";
        }
    }
}
