using Terraria.Net;
using Terraria.GameContent.NetModules;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;

namespace Conquest.Items.Materials
{
    public class ThankYou : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 11));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            // Tooltip.SetDefault("Temp Item");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 22;
            Item.rare = 10;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(gold: 2);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.LunarBar, 1)
           .AddIngredient(ItemID.FragmentNebula, 1)
           .AddIngredient(ItemID.FragmentSolar, 1)
           .AddIngredient(ItemID.FragmentStardust, 1)
           .AddIngredient(ItemID.FragmentVortex, 1)

           .AddTile(TileID.LunarCraftingStation)
           .Register();


        }
    }
}
