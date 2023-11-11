using Microsoft.AspNetCore.SignalR;

namespace WebApp.Socket{

  public class Signal : Hub
  {
    //public ListeningQueryChanges sb_alerts = new ListeningQueryChanges();
    public async Task SendMessage(string user, string message)
    {
      await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    /*public override async Task OnDisconnectedAsync(Exception exception)
    {
        Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }*/

    /*public async Task StartListenAlerts(int user_id){
      
      sb_alerts = ListeningQueryChanges.client.GetOrAdd(Context.ConnectionId,sb_alerts);
      sb_alerts.callerContext = Context;
      sb_alerts.hubCallerClients = Clients;

      sb_alerts.SetData(
        @"Data Source=usilpooii.mysql.database.azure.com;Port=3306;Database=usilingii_db;User Id=usil_root;Password=675&mF{~D-P=;SslMode=Required;MultipleActiveResultSets=true;", 
        $"select * from conversation c inner join message m on c.conversation_id  = m.conversation_id inner join text_message tm on m.message_id  = tm.message_id where c.client_id  = {user_id}", 
        "LISTEN_ALERTS"
      );

      sb_alerts.OnMessageReceived += new ListeningQueryChanges.MessageReceived(sbAlertsInformationReceived);
      sb_alerts.StartListen();
      await Clients.Caller.SendAsync("Alert listening started");

    }

    public async Task StopListenAlerts(int user_id){
      sb_alerts = ListeningQueryChanges.client.GetOrAdd(Context.ConnectionId,sb_alerts);
      sb_alerts.OnMessageReceived -= sbAlertsInformationReceived;
      await Clients.Caller.SendAsync("Alert listening stopped");
    }

    private static void sbAlertsInformationReceived(object sender, string message){
      var sb = (ListeningQueryChanges) sender;
      HubCallerContext hCallerContext = sb.callerContext;
      IHubCallerClients<IClientProxy> hubClients = sb.hubCallerClients;
      hubClients.Caller.SendAsync($"The message {message} indicates a change" + DateTime.Now.ToString());
    }*/

  }

}
