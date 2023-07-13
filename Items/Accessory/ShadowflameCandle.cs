using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Items.Accessory
{
    public class ShadowflameCandle : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Magic) += 8;
            player.GetDamage(DamageClass.Magic) += 0.12f;

        }
    }
}
