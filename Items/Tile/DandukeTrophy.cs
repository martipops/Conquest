using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Conquest.Tiles;

namespace Conquest.Items.Tile
{
    public class DandukeTrophy : ModItem
    {
        public override void SetDefaults()
        {

            Item.DefaultToPlaceableTile(ModContent.TileType<DandukeTrophyTile>());

            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Blue;
            Item.value = 750000;
        }
    }
}
