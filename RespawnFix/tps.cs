using CommandSystem;
using System;
using Exiled.API.Features;
using RespawnFix;

namespace FoxtUtils.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class TpsCommand : ICommand
    {
        public string Command { get; } = "tps";
        public string[] Aliases { get; } = { };
        public string Description { get; } = " Check the tps.";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Tps: " + Server.Tps;
            return true;
        }
    }
}

