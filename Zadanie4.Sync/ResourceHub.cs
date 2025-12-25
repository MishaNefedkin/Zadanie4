using Microsoft.AspNetCore.SignalR;

namespace Zadanie4.Sync;

public class ResourceHub : Hub
{
    public async Task NotifyResourceChanged(string message)
    {
        await Clients.All.SendAsync("ResourceChanged", message);
    }
}