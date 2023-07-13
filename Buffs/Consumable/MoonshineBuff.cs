using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Buffs.Consumable
{
    public class MoonshineBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Moonshine");
            // Description.SetDefault("Grants +10 defense, but you feel slow");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 10;
            player.moveSpeed -= 0.40f;
            player.accRunSpeed -= 0.50f;
        }
    }
}
