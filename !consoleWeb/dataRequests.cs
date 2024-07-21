using Microsoft.VisualBasic;
using Npgsql;
namespace dataRequests
{
    class readInfo
    {
        static readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1510;Timeout=10;SslMode=Prefer";

        public static string readUsers(int user_id, string chooseInfo = "1111")
        {
            var connect = new NpgsqlConnection(conString);
            connect.Open();
            var cmd = connect.CreateCommand();
            cmd.CommandText = $"SELECT * FROM users WHERE user_id = {user_id}";

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string userInfo = "";
                if (chooseInfo[0] != '0')
                {
                    userInfo += $"ID: {reader["user_id"]}, ";
                }
                if (chooseInfo[1] != '0')
                {
                    userInfo += $"Имя: {reader["user_name"]}, ";
                }
                if (chooseInfo[2] != '0')
                {
                    userInfo += $"Пароль: {reader["user_password"]}, ";
                }
                if (chooseInfo[3] != '0')
                {
                    userInfo += $"Root права: {reader["user_root"]}, ";
                }
                return userInfo.TrimEnd(' ', ',');
            }
            else
            {
                return "Несуществующий пользователь!";
            }
        }
    }
}
