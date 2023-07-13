using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Buffs.Consumable
{
    public class West : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wild West Cocktail");
            // Description.SetDefault("Grants +10% Ranged Damage, -10 defense");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Ranged) += 0.10f;
            player.statDefense -= 10;
        }
    }
}
