using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Tiles
{
    public class EnchantedSandstone : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            //DustType = ModContent.DustType<Sparkle>();
            //ItemDrop = ModContent.ItemType<EnchantedSandstoneItem>();
            AddMapEntry(new Color(138, 43, 226));

        }
        /*
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        */
    }
}
