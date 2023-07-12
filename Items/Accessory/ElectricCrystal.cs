using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Conquest.Assets.Common;
using Conquest.Items.Materials;

namespace Conquest.Items.Accessory
{
    public class ElectricCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Electro Crystal");
            // Tooltip.SetDefault("Weapons have a chance to inflict electrified against enemies");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 6));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 4;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().ElectroCrystal = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Diamond, 5)
            .AddIngredient(ItemID.StoneBlock, 20)
          .AddIngredient(ModContent.ItemType<JellyfishTentacle>(), 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}
