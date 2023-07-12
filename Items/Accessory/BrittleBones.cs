
using Conquest.Assets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Accessory
{
    public class BrittleBones : ModItem
    {

        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Everything hurts\nGoing under 100 health causes your bones to break\nWhen your bones are broken you gain 0 defense, 0 life regneration, and +50% more damage\nGoing over 100 health removes the changed stats");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Green;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().Bones = true;

        }




    }
}