using Terraria;
using Terraria.ModLoader;
namespace Conquest.Dusts
{
    public class GhostDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true; // Makes the dust have no gravity.
            dust.noLight = true;

        }
    }
}
