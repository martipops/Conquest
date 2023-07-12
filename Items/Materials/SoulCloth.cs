using Terraria.Net;
using Terraria.GameContent.NetModules;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Conquest.Items.Materials
{
    public class SoulCloth : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            // Tooltip.SetDefault("Forged from beyond");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 22;

            Item.maxStack = 999;
            Item.value = Item.sellPrice(copper: 99); // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                      .AddIngredient(ModContent.ItemType<SoulPiece>(), 3)
                       .AddIngredient(ItemID.Silk, 1)
                      .AddTile(TileID.Anvils)
                      .Register();
        }
    }


}
