using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace Ccolor.Commands.Admin
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class CcolorStop : ICommand
    {
        public string Command => "stop";

        public string[] Aliases => [];

        public string Description => "Останавливает дискотеку";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission($"accrolor.{Command}"))
            {
                response = "У Вас недостаточно прав";
                return false;
            }

            Plugin.Singleton._colorService.Stop();

            response = "Дискотека остановлена!";
            return true;
        }
    }
}
