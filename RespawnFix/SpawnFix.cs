using MEC;
using PlayerRoles;
using Exiled.API.Features;
using System.Collections.Generic;

namespace RespawnFix
{
    public class SpawnFix
    {

        public static void OnRoundStarted()
        {

            foreach (Exiled.API.Features.Player player in Exiled.API.Features.Player.List)
            {
                player.IsGodModeEnabled = true;
                player.Role.Set(player.Role.Type, Exiled.API.Enums.SpawnReason.ForceClass, PlayerRoles.RoleSpawnFlags.All);
            }

            Timing.RunCoroutine(Timer(), "SpawnFixTimer");
        }


        public static IEnumerator<float> Timer()
        {

            foreach (Exiled.API.Features.Player player in Exiled.API.Features.Player.List)
                player.IsGodModeEnabled = true;

            yield return Timing.WaitForSeconds(1.5f);

            foreach (Exiled.API.Features.Player player in Exiled.API.Features.Player.List)
                player.IsGodModeEnabled = false;

            foreach (Exiled.API.Features.Player player in Exiled.API.Features.Player.List)
            {
                player.Role.Set(player.Role.Type, Exiled.API.Enums.SpawnReason.ForceClass, PlayerRoles.RoleSpawnFlags.All);
                Log.Debug("Succesfully fixed player to: " + player.Role.Type);

                Timing.KillCoroutines("SpawnFixTimer");
            }

        }

    }
}
