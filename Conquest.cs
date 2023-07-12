using Conquest.Assets.Common;
using System.Collections.Generic;
using System.IO;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Conquest
{
	public class Conquest : Mod
	{
        public static Dictionary<int, int> oreTileToItem;
        public static Dictionary<int, int> oreItemToTile;
        public static Conquest Instance;
        public static float DropChance = 1f;
        public static Mod SubworldLibrary;
        public override void Load()
        {
            oreTileToItem = new Dictionary<int, int>();
            oreItemToTile = new Dictionary<int, int>();
        }
        public override void Unload()
        {
            oreTileToItem = null;
            oreItemToTile = null;
        }
        public override void PostSetupContent()
        {
            for (int item = 0; item < ItemLoader.ItemCount; item++)
            {
                Item test = new Item();
                test.SetDefaults(item);
                int tile = test.createTile;
                if (tile > -1 && tile < TileLoader.TileCount && TileID.Sets.Ore[tile])
                {
                    if (!oreTileToItem.ContainsKey(tile))
                    {
                        oreTileToItem.Add(tile, item);
                    }

                    if (!oreItemToTile.ContainsKey(item))
                    {
                        oreItemToTile.Add(item, tile);
                    }
                }
            }
        }
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            NetHandler.HandlePackets(reader, whoAmI);
        }

    }
}