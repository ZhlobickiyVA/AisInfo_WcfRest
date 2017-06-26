using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LibraryService
{

  public interface IConnectString
  {
    string GetTextQuery();

  }




  public class SelectToData
  {
    string NameConnectionString;

    string SelectCount = ConfigurationManager.AppSettings["CountSelect"];



    public SelectToData(string NameConnString)
    {
      this.NameConnectionString = NameConnString;
    }



    public DataSet GetDatasetToBase(IConnectString conn)
    {
      string Connect = ConfigurationManager.ConnectionStrings[this.NameConnectionString].ConnectionString;

      SqlConnection connection = new SqlConnection(Connect);
      SqlCommand Command = new SqlCommand()
      {
        Connection = connection,
        CommandType = CommandType.Text,
        CommandText = conn.GetTextQuery()
      };
      SqlDataAdapter data = new SqlDataAdapter()
      {
        SelectCommand = Command
      };
      DataSet ds = new DataSet();
      data.Fill(ds);
      connection.Close();
      return ds;
    }

    public DataSet GetDatasetToBase(string SQL)
    {
      string Connect = ConfigurationManager.ConnectionStrings[this.NameConnectionString].ConnectionString;

      SqlConnection connection = new SqlConnection(Connect);
      SqlCommand Command = new SqlCommand()
      {
        Connection = connection,
        CommandType = CommandType.Text,
        CommandText = SQL
      };
      SqlDataAdapter data = new SqlDataAdapter()
      {
        SelectCommand = Command
      };
      DataSet ds = new DataSet();
      data.Fill(ds);
      connection.Close();

      return ds;
    }


















  }
}