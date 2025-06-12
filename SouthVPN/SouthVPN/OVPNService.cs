using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SouthVPN
{
	public class OpenVpnService : IVpnService
	{
		private Process? vpnProcess;

		public Task<bool> ConnectAsync(string serverName)
		{
			
			string configPath = Path.Combine("openvpn-configs", "server.ovpn");

			if (!File.Exists(configPath))
				return Task.FromResult(false);

			vpnProcess = new Process();
			vpnProcess.StartInfo.FileName = "\"C:\\Program Files\\OpenVPN\\bin\\openvpn.exe\""; 
			vpnProcess.StartInfo.Arguments = $"--config \"{configPath}\"";
			vpnProcess.StartInfo.CreateNoWindow = true;
			vpnProcess.StartInfo.UseShellExecute = false;
			vpnProcess.StartInfo.RedirectStandardOutput = true;
			vpnProcess.StartInfo.RedirectStandardError = true;

			vpnProcess.Start();

			return Task.FromResult(true);
		}

		public Task<bool> DisconnectAsync()
		{
			if (vpnProcess != null && !vpnProcess.HasExited)
			{
				vpnProcess.Kill();
				vpnProcess.Dispose();
				vpnProcess = null;
				return Task.FromResult(true);
			}
			return Task.FromResult(false);
		}

		public string GetStatus()
		{
			return vpnProcess != null && !vpnProcess.HasExited ? "Verbunden" : "Nicht verbunden";
		}
	}
}
