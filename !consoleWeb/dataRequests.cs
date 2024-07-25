using Npgsql;
using System.Text.RegularExpressions;
namespace dataRequests
{
    class data
    {
        static readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1510;Timeout=10;SslMode=Prefer";


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


    }
    class dataChek
    {

        public static bool chekConditions(string user_data, params string[] parameter)
        {
            for (int i = 0; i < parameter.Length; i++)
            {
                string[] parts = parameter[i].Split(';');
                string key = parts[0].ToLower();
                string value = parts[1];
                switch (key)
                {
                    case "maxlength":
                        if (user_data.Length > int.Parse(value))
                        {
                            return true;
                        }
                        break;
                    case "minlength":
                        if (user_data.Length < int.Parse(value))
                        {
                            return true;
                        }
                        break;
                    case "uniq":
                        switch (value)
                        {
                            case "login":
                                if (user_data == data.readUsers(user_data, "01000"))
                                {
                                    return true;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case "anylangex":
                        switch (value) 
                        {
                            case "en":
                                if(IsEnglish(user_data))
                                    return false;
                                else
                                    return true;
                            case "ru":
                                if (IsRussian(user_data))
                                    return false;
                                else
                                    return true;
                            case "china":
                                if (IsChinese(user_data))
                                    return false;
                                else
                                    return true;
                        }
                    break;
                    default:
                        return false;
                }
            }

            return false;
        }
        private static bool IsEnglish(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9\s\-.,]+$");
        }
        private static bool IsRussian(string input)
        {
            return Regex.IsMatch(input, @"[\u0400-\u04FF]+");
        }
        private static bool IsChinese(string input)
        {
            return Regex.IsMatch(input, @"[\u4e00-\u9fff]+");
        }


    }
}
