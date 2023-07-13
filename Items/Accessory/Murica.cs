using Conquest.Assets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Items.Accessory
{
    public class Murica : ModItem
    {
        
            public override void SetStaticDefaults()
            {
                // Tooltip.SetDefault("+10% Summon Damage");
            }

            public override void SetDefaults()
            {
                Item.accessory = true;
                Item.value = Item.sellPrice(0, 10, 0, 0);
                Item.rare = 4;
            }

            public override void UpdateAccessory(Player player, bool hideVisual)
            {
                player.GetDamage(DamageClass.Ranged) += 0.12f;
                player.GetModPlayer<MyPlayer>().America = true;

            }
        }
    }
