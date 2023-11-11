using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace WebApp.Socket{

  public class ListeningQueryChanges{

 /*   public HubCallerContext? callerContext {get; set;}
    public IHubCallerClients<IClientProxy>? hubCallerClients {get; set;}
    
    public static ConcurrentDictionary<string, ListeningQueryChanges> client = new ConcurrentDictionary<string, ListeningQueryChanges>();

    public string _connectionString {get;set;}
    public string _query {get;set;}
    public string _nameMessage {get;set;}

    public delegate void MessageReceived(object sender, string name_message);
    public event MessageReceived? OnMessageReceived = null;

    ServiceBroker broker;

    public ListeningQueryChanges(){
      
    }

    public void SetData(string connectionString, string SQLquery, string name_message){
      _connectionString = connectionString;
      _query = SQLquery;
      _nameMessage = name_message;
    }

    public void StartListen(){
      broker = new ServiceBroker(_connectionString, _query, _nameMessage);
      broker.OnMessageReceived += new ServiceBroker.MessageReceived(broker_InformationReceived);
      broker.StartListen();
    }

    public void StopListen(){
      broker.StopListen();
    }

    public void broker_InformationReceived(object sender, string name_message){
      if(OnMessageReceived != null){
        OnMessageReceived(this, new string("Skip"));
        this.StartListen();
      }
    }*/

  }

}