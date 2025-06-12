using System.Threading.Tasks;

namespace SouthVPN
{
	public interface IVpnService
	{
		Task<bool> ConnectAsync(string serverName);
		Task<bool> DisconnectAsync();
		string GetStatus();
	}
}
