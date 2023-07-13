using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Buffs.Consumable
{
    public class RyeWhiskeyBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rhy Whiskey");
            // Description.SetDefault("Grants +10% summoning Damage, and lowered gravity");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Summon) += 0.10f;
            player.slowFall = true;
        }
    }
}
