using Microsoft.AspNet.SignalR.Client;

namespace BL.Managers
{
    public class SignalRConnectionManager
    {
        private readonly HubConnection hubConnection;
        private readonly IHubProxy hubProxy;

        public SignalRConnectionManager()
        {
            hubConnection = new HubConnection("http://localhost:54780/");
            hubProxy = hubConnection.CreateHubProxy("FlightsHub");
        }

        public void StartConnection()
        {
            hubConnection.Start().Wait();
        }

        public T Invoke<T>(string methodName, params object[] args)
        {
            return hubProxy.Invoke<T>(methodName, args).Result;
        }

        public void Invoke(string methodName, params object[] args)
        {
            hubProxy.Invoke(methodName, args);
        }
    }
}
