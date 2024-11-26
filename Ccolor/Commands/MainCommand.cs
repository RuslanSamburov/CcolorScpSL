using Ccolor.Commands.Admin;
using CommandSystem;
using Exiled.Permissions.Extensions;
using System;
using System.Linq;

namespace Ccolor.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class MainCommand : ParentCommand
    {
        public override string Command => "autoccolor";

        public override string[] Aliases => ["accolor"];

        public override string Description => "Дискотека";

        public MainCommand()
        {
            LoadGeneratedCommands();
        }

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new CcolorStart());
            RegisterCommand(new CcolorStop());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Доступные команды: \n\n";

            foreach (ICommand command in AllCommands.Cast<ICommand>())
            {
                if (sender.CheckPermission($"accrolor.{command.Command}"))
                {
                    response += $"\n\n- {command.Command} ({string.Join(", ", command.Aliases)})\n{command.Description}";
                }
            }

            return false;
        }
    }
}
