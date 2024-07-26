using _consoleWeb;
using dataRequests;
using System.Xml.Linq;
using visual;
namespace allCommands
{
    class mainCommands
    {
        public static void identifyCommand(string command)
        {
            switch (command)
            {
                case "/respeed":
                    reSpeedCommand();
                    break;
                case "/help":
                    infoCommandCommand();
                    break;
                case "/maincommands":
                    mainCommandsCommand();
                    break;
                case "/reg":
                    registerCommand();
                    break;
                case "/bye":
                    deleteAccountCommand();
                    break;
                case "/log":
                    loginCommand();
                    break;
                case "/logout":
                    logoutCommand();
                    break;
                case "/load":
                    loadPageCommand();
                    break;
                case "/contentcreate":
                    createContentCommand();
                    break;
                case "/contentdelete":
                    deleteContentCommand();
                    break;
                case "/me":
                    viewProfileCommand();
                    break;
                case "/changeme":
                    changeProfileCommand();
                    break;
                default:
                    customWrite.writeLine("Несуществующая комманда!");
                    break;
            }
        }
        private static void infoCommandCommand()
        {
            customWrite.writeLine("Добро пожаловать в социальную сеть !console. Эта сеть была создана для тех, кто ценит минимализм, эффективность и эстетику консольных приложений.");
            customWrite.writeLine("Использование !console требует минимальных усилий, так как все действия выполняются через простые текстовые команды.");
            customWrite.writeLine("Наслаждайтесь эффективностью и простотой социальной сети !console");
            customWrite.writeLine("/mainСommands - Показать все доступные команды и их описание");
        }
        private static void mainCommandsCommand()
        {
            customWrite.writeLine("/reSpeed - Изменить скорость вывода текста в консоль");
            customWrite.writeLine("/reg - Зарегистрироваться");
            customWrite.writeLine("/bye - Удалить аккаунт");
            customWrite.writeLine("/log - Войти в систему");
            customWrite.writeLine("/logout - Выйти из системы");
            customWrite.writeLine("/load - Загрузить страницу");
            customWrite.writeLine("/contentCreate - Создать контент");
            customWrite.writeLine("/contentDelete - Удалить контент");
            customWrite.writeLine("/me - Просмотреть профиль");
            customWrite.writeLine("/changeMe - Изменить профиль");
        }
        private static void registerCommand()
        {
            // запрос на создание логина
            customWrite.write("Логин для входа: ");
            string login = Console.ReadLine().ToLower().TrimEnd(' ');
            // проверка на соответствие стандартам
            if (dataChek.chekFalseConditions(login, "minLength;4", "maxLength;16", "lang;en") || dataChek.chekFalseConditions(login, "hasnotspacechar;0"))
            {
                customWrite.writeLine("Не удалось создать пользователя!\nОбратите внимание на следущие требования к логину пользователя:");
                customWrite.writeLine("\tМинимальная длинна 4 символа\n\tМаксимальная длинна 16 символов\n\tДолжен быть уникальным для каждого пользователя\n\tМожет состаять только из латинских букв и цифр\n\tНе может содержать в себе пробел(ы)");
                program.Main();
            }
            // запрос на создание имени профиля
            customWrite.write("Имя профиля: ");
            string name = Console.ReadLine().Trim(' ');
            // проверка на соответствие стандартам
            if (dataChek.chekFalseConditions(name, "minLength;4", "maxLength;16", "hasnotspacechar;0"))
            {
                customWrite.writeLine("Не удалось создать пользователя!\nОбратите внимание на следущие требования к имени пользователя:");
                customWrite.writeLine("\tМинимальная длинна 4 символа\n\tМаксимальная длинна 16 символов\n\tНе может содержать в себе пробел(ы)");
                program.Main();
            }

            // запрос на создание пароля
            customWrite.write("Пароль для входа: ");
            string password = Console.ReadLine().TrimEnd(' ');
            // проверка на соответствие стандартам
            if (dataChek.chekFalseConditions(password, "minlength;8", "maxlength;32", "specialChar;1", "hasNotSpaceChar;0"))
            {
                customWrite.writeLine("Не удалось создать пользователя!\nОбратите внимание на следущие требования к паролю пользователя:");
                customWrite.writeLine("\tМинимальная длинна 8 символов\n\tМаксимальная длинна 32 символов\n\tДолжен содержать минимум 1 спецсимвол\n\tНе может содержать в себе пробел(ы)");
                program.Main();
            }

            // создание пользователя
            data.createUser(login, name, password);
            customWrite.writeLine("Пользователь успешно создан!");
        }
        private static void deleteAccountCommand()
        {
            // Логика для команды DeleteAccount
        }
        private static void loginCommand()
        {
            // Логика для команды Login
        }
        private static void logoutCommand()
        {
            // Логика для команды Logout
        }
        private static void loadPageCommand()
        {
            // Логика для команды LoadPage
        }
        private static void createContentCommand()
        {
            // Логика для команды CreateContent
        }
        private static void deleteContentCommand()
        {
            // Логика для команды DeleteContent
        }
        private static void viewProfileCommand()
        {
            // Логика для команды ViewProfile
        }
        private static void changeProfileCommand()
        {
            // Логика для команды ChangeProfile
        }
        private static void reSpeedCommand()
        {
            customWrite.write("Выберите скорость (0, fast, normal, slow): ");
            string request = Console.ReadLine().ToLower();
            customWrite.setSpeed(request);
        }
    }
}
