using Exiled.API.Enums;
using Features = Exiled.API.Features;
using server = Exiled.Events.Handlers.Server;

namespace RespawnFix
{
    public class Plugin : Features.Plugin<Config>
    {
        public override string Name { get; } = "RespawnFix";
        public override string Author { get; } = "Caty Foxt";
        public override PluginPriority Priority { get; } = PluginPriority.High;

        private static readonly Plugin InstanceValue = new Plugin();
        public static Plugin StaticInstance => InstanceValue;

        public override void OnEnabled()
        {
            if (Config.IsEnabled) 
                server.RoundStarted += SpawnFix.OnRoundStarted;
        }

        public override void OnDisabled()
        {
            if (Config.IsEnabled)
                server.RoundStarted -= SpawnFix.OnRoundStarted;
        }
    }

}
