using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Buffs.Consumable
{
    public class PigsEarBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pig's Ear");
            // Description.SetDefault("Grants +10% Magic Damage, but you feel slower");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Magic) += 0.10f;
            player.moveSpeed -= 0.40f;
            player.accRunSpeed -= 0.50f;
        }
    }
}
