using MySql.Data.MySqlClient;

namespace AddDataToBD2;

public static class DBConnection
{
    private static string _connString = "server=10.10.1.24;port=3306;database=pro1_12;user=user_01;password=user01pro;";
    private static MySqlConnection _connector;
    
    public static void AddData(string sql)
    {
        _connector = new MySqlConnection(_connString);
        MySqlCommand command = new MySqlCommand(sql, _connector);
        command.ExecuteNonQuery();
    }
    
    public static MySqlDataReader GetData(string sql)
    {
        MySqlCommand command = new MySqlCommand(sql, _connector);
        MySqlDataReader reader = command.ExecuteReader();

        return reader;
    }
    
    public static void Open()
    {
        _connector = new MySqlConnection(_connString);
        _connector.Open();
    }

    public static void Exit()
    {
        _connector.Close();
    }
}