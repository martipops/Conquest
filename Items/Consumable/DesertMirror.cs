
using Conquest.Assets.GUI.Chart;
using SubworldLibrary;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Consumable
{
    public class DesertMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Used to teleport to the Antlion Nest");

        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.rare = 5;
            Item.maxStack = 1;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item6;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2 && player.whoAmI == Main.myPlayer)
            {
                GrandChart.GSB = true;
            }
            return base.CanUseItem(player);

        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.MagicMirror, 1)
                .AddIngredient(ItemID.CopperBar, 8)
                .AddTile(TileID.DemonAltar)
                .Register();

            CreateRecipe(1)
                .AddIngredient(ItemID.MagicMirror, 1)
                .AddIngredient(ItemID.TinBar, 8)
                .AddTile(TileID.DemonAltar)
                .Register();


        }
    }
}
