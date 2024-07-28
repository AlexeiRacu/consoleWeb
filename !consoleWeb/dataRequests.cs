using Npgsql;
using System.Text.RegularExpressions;
namespace dataRequests
{
    class dataRequest
    {
        static readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1510;Timeout=10;SslMode=Prefer";

        private static string user = "";

        public static string readUsers(int user_id, string chooseInfo = "11111")
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
                    userInfo += $"{reader["user_id"]}, ";
                }
                if (chooseInfo[1] != '0')
                {
                    userInfo += $"{reader["user_login"]}, ";
                }
                if (chooseInfo[2] != '0')
                {
                    userInfo += $"{reader["user_name"]}, ";
                }
                if (chooseInfo[3] != '0')
                {
                    userInfo += $"{reader["user_password"]}, ";
                }
                if (chooseInfo[4] != '0')
                {
                    userInfo += $"{reader["user_root"]}, ";
                }
                connect.Close();
                return userInfo.TrimEnd(' ', ',');
            }
            else
            {
                return "Несуществующий пользователь!";
            }
        }

        public static string readUsers(string user_login, string chooseInfo = "11111")
        {
            var connect = new NpgsqlConnection(conString);
            connect.Open();
            var cmd = connect.CreateCommand();
            cmd.CommandText = $"SELECT * FROM users WHERE user_login = '{user_login}'";

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string userInfo = "";
                if (chooseInfo[0] != '0')
                {
                    userInfo += $"{reader["user_id"]}, ";
                }
                if (chooseInfo[1] != '0')
                {
                    userInfo += $"{reader["user_login"]}, ";
                }
                if (chooseInfo[2] != '0')
                {
                    userInfo += $"{reader["user_name"]}, ";
                }
                if (chooseInfo[3] != '0')
                {
                    userInfo += $"{reader["user_password"]}, ";
                }
                if (chooseInfo[4] != '0')
                {
                    userInfo += $"{reader["user_root"]}, ";
                }
                connect.Close();
                return userInfo.TrimEnd(' ', ',');
            }
            else
            {
                return "Несуществующий пользователь!";
            }
        }

        public static void createUser(string login, string name, string password, string root = "false")
        {
            var connect = new NpgsqlConnection(conString);
            connect.Open();
            var cmd = connect.CreateCommand();
            cmd.CommandText = $"INSERT INTO users (user_login, user_name, user_password, user_root) VALUES('{login}','{name}', '{password}', {(root.ToLower())})";
            cmd.ExecuteNonQuery();
        }

        public static void loginUser(string login)
        {
            user = login;
        }
        public static void logoutUser()
        {
            user = "";
        }
    }
    class dataChek
    {
        public static bool chekFalseConditions(string user_data, params string[] parameter)
        {
            for (int i = 0; i < parameter.Length; i++)
            {
                string[] parts = parameter[i].Split(';');
                string key = parts[0].ToLower();
                string value = parts[1];
                switch (key)
                {
                    case "maxlength":
                        if (user_data.Length > byte.Parse(value))
                        {
                            return true;
                        }
                        break;
                    case "minlength":
                        if (user_data.Length < byte.Parse(value))
                        {
                            return true;
                        }
                        break;
                    case "uniq":
                        switch (value)
                        {
                            case "login":
                                if (user_data == dataRequest.readUsers(user_data, "01000"))
                                {
                                    return true;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case "lang":
                        switch (value)
                        {
                            case "en":
                                if (Regex.IsMatch(user_data, @"^[a-zA-Z0-9\s\-.,]+$"))
                                    return false;
                                else
                                    return true;
                            case "ru":
                                if (Regex.IsMatch(user_data, @"[\u0400-\u04FF]+"))
                                    return false;
                                else
                                    return true;
                            case "china":
                                if (Regex.IsMatch(user_data, @"[\u4e00-\u9fff]+"))
                                    return false;
                                else
                                    return true;
                        }
                        break;
                    case "specialchar":
                        byte specialCharCount = (byte)Regex.Count(user_data, @"[^a-zA-Z0-9 ]+");
                        if (specialCharCount >= byte.Parse(value))
                            return false;
                        else
                            return true;
                    case "hasnotspecialchar":
                        specialCharCount = (byte)Regex.Count(user_data, @"[^a-zA-Z0-9 ]+");
                        if (specialCharCount > byte.Parse(value))
                            return true;
                        else
                            return false;
                    case "hasnotspacechar":
                        byte spaceCharCount = (byte)Regex.Count(user_data, @"\s");
                        if (spaceCharCount > byte.Parse(value))
                            return true;
                        else
                            return false;
                }
            }
            return false;
        }
    }
}
