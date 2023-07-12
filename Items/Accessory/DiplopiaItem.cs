using Conquest.Assets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Accessory
{
    [AutoloadEquip(EquipType.Face)]
    public class DiplopiaItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Diplopia");
            // Tooltip.SetDefault("Your seeing double!\nOre drops are now doubled!");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 2));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;


        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Blue;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().Diplopia = true;
        }
    }
}
