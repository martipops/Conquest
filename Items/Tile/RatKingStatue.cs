using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Conquest.Tiles;

namespace Conquest.Items.Tile
{
    internal class RatKingStatue : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("鼠王雕像");
        }

        public override void SetDefaults()
        {

            Item.DefaultToPlaceableTile(ModContent.TileType<RatKingStatueTile>());

            Item.width = 32;
            Item.height = 48;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.White;
            Item.value = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.MouseStatue, 1)
                .AddIngredient(ItemID.GoldCrown, 1)
                .AddTile(TileID.DemonAltar)
                .Register();

            CreateRecipe(1)
                .AddIngredient(ItemID.MouseStatue, 1)
                .AddIngredient(ItemID.PlatinumCrown, 1)
                .AddTile(TileID.DemonAltar)
                .Register();


        }
    }
}
