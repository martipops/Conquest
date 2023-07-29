using Conquest.Assets.Common;
using System.Collections.Generic;
using System.IO;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

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
            Instance = this;

            oreTileToItem = new Dictionary<int, int>();

            oreItemToTile = new Dictionary<int, int>();
            if (Main.netMode != NetmodeID.Server)
            {
                Ref<Effect> darkDawnRef = new Ref<Effect>(ModContent.Request<Effect>("Conquest/Assets/Shaders/DarkDawnSS", AssetRequestMode.ImmediateLoad).Value);
                Filters.Scene["FlashLight"] = new Filter(new ScreenShaderData(darkDawnRef, "DarkDawnSSfl"), EffectPriority.VeryHigh);
                Filters.Scene["FlashLight"].Load();
                Filters.Scene["Distortion"] = new Filter(new ScreenShaderData(darkDawnRef, "DarkDawnSSdist"), EffectPriority.VeryHigh);
                Filters.Scene["Distortion"].Load();
          
            }
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