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
    public class DandukeRelic : ModItem
    {
        public override void SetDefaults()
        {

            Item.DefaultToPlaceableTile(ModContent.TileType<DandukeRelicTile>());

            Item.width = 30;
            Item.height = 48;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Master;
            Item.value = 750000;
        }
    }
}

