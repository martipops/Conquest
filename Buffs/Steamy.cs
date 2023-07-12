
using System.Numerics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Buffs
{
    public class Steamy : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // Description.SetDefault("While holding pain train, increased fire rate and crit chance but halved defense\nThis buff will be removed if your not holding pain train");
            // DisplayName.SetDefault("Conductor");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.rand.NextBool(4))
            {
                int Steamy = Dust.NewDust(player.position, player.width, player.height, DustID.SteampunkSteam);
                Main.dust[Steamy].velocity.Y *= 0.4f;
                Main.dust[Steamy].noGravity = true;

            }
            player.GetAttackSpeed(DamageClass.Ranged) += 0.50f;
            player.GetCritChance(DamageClass.Ranged) += 10f;
        }

    }
}

