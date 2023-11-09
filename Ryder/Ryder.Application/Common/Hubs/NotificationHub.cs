using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Ryder.Application.Common.Hubs
{
    public class NotificationHub : Hub
    {
		public async Task JoinAvailableRidersGroup(string connectionId)
		{
			await Groups.AddToGroupAsync(connectionId, "AvailableRiders");
		}

		public async Task LeaveAvailableRidersGroup(string connectionId)
		{
			await Groups.RemoveFromGroupAsync(connectionId, "AvailableRiders");
		}

		public async Task SendRequestToAvailableRiders(string message)
		{
			// Send a message to all available riders in the "AvailableRiders" group
			await Clients.Group("AvailableRiders").SendAsync("IncomingRequest", message);
		}
	}
}