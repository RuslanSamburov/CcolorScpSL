using CommandSystem;
using Exiled.Permissions.Extensions;
using System;
using System.Linq;

namespace Ccolor.Commands.Admin
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class CcolorStart : ICommand, IUsageProvider
    {
        public string Command => "start";

        public string[] Aliases => [];

        public string Description => "autoccolor start 0-255(red) 0-255(green) 0-255(blue) 10";

        public string[] Usage => [ "0-255", "100-255", "255-255", "time(second)"];

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission($"accrolor.{Command}"))
            {
                response = "У Вас недостаточно прав";
                return false;
            }

            if (arguments.Count < 4)
            {
                response = "Заполните все аргументы!\nАргументы: " + string.Join(", ", Usage);
                return false;
            }

            string[] red = arguments.At(0).Split('-');
            string[] green = arguments.At(1).Split('-');
            string[] blue = arguments.At(2).Split('-');

            if (red.Count() != 2 || green.Count() != 2 || blue.Count() != 2)
            {
                response = "Неверный формат цветов";
                return false;
            }

            if (!float.TryParse(arguments.At(3), out float time))
            {
                response = "Время должно быть числом!";
                return false;
            }

            Plugin.Singleton._colorService.Start(red, green, blue, time);

            response = "Дискотека запущена!";
            return true;
        }
    }
}
