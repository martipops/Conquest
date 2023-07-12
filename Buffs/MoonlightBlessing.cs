using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Buffs
{
    public class MoonlightBlessing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Moonlight Blessing");
            // Description.SetDefault("Increased Damage and Crit Chance");
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Melee) += 0.20f;
            player.GetCritChance(DamageClass.Melee) += 20f;

        }
    }
}