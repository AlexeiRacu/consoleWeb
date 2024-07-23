using Npgsql;
namespace dataRequests
{
    class data
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
                connect.Close();
                return userInfo.TrimEnd(' ', ',');
            }
            else
            {
                return "Несуществующий пользователь!";
            }
        }
        public static void createUser(string name, string password, string root = "false")
        {
            var connect = new NpgsqlConnection(conString);
            connect.Open();
            var cmd = connect.CreateCommand();
            cmd.CommandText = "INSERT INTO users (user_name, user_password, user_root) VALUES(@name, @password, @root)";

            // Преобразование значения root в логическое значение
            bool rootBool = root.ToLower() == "true";

            // Добавление параметров запроса
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("root", rootBool);

            // Выполнение запроса на вставку данных
            cmd.ExecuteNonQuery();

            connect.Close();
        }
    }
}
