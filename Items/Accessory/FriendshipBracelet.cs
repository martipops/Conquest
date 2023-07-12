using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria;

namespace Conquest.Items.Accessory
{
    public class FriendshipBracelet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Summon Damage");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += 0.10f;
        }
    }
}
