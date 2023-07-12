using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Accessory
{
    public class SnailShell : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Increases Defense by 10, reduces speed by 10%");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 10;
            player.moveSpeed -= 0.1f;
        }
    }
}
