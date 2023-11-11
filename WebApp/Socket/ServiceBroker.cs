using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebApp.Socket{

  public class ServiceBroker{

    private string connectionString;
    private string queryConnection;
    private string name_message;
    private SqlConnection connection;

    public delegate void MessageReceived(object sender, string name_message);
    public event MessageReceived? OnMessageReceived = null;
    public ServiceBroker(string connectionString, string SQLquery, string name_message){
      if(connectionString==""||SQLquery=="") throw new ApplicationException("You must indicate the connection string and the listen command");
      this.connectionString = connectionString;
      this.queryConnection = SQLquery;
      this.name_message = name_message;

      SqlDependency.Start(connectionString);
      connection = new SqlConnection(connectionString);
    }

    ~ServiceBroker(){
      SqlDependency.Stop(connectionString);
    }

    public void StartListen(){
      try{
        SqlCommand command = new SqlCommand(queryConnection, connection);
        command.CommandType = CommandType.Text;

        command.Notification = null;

        SqlDependency dependency = new SqlDependency(command);

        dependency.OnChange += new OnChangeEventHandler(OnChange);

        if(connection.State == ConnectionState.Closed) connection.Open();

        command.ExecuteReader(CommandBehavior.CloseConnection);
      }catch(Exception){
        throw;
      }
    }

    public void StopListen(){
      SqlDependency.Stop(connectionString);
    }

    private void OnChange(object sender, SqlNotificationEventArgs e){
      SqlDependency dependency = (SqlDependency) sender;
      
      dependency.OnChange -= OnChange;

      if(OnMessageReceived != null){
        OnMessageReceived(this, new string(name_message));
      }

    }
  }

}