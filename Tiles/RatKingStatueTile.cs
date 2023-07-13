using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;

using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Conquest.Items.Tile;

namespace Conquest.Tiles
{
    internal class RatKingStatueTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileID.Sets.FramesOnKillWall[Type] = false;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.addTile(Type);

        }

        public override bool RightClick(int i, int j)
        {
            /*if(UnlockEvents.ratVic == false)
            {
				return false;
            }
			*/
            int x = i - Main.tile[i, j].TileFrameX / 16 % 2;
            int y = j - Main.tile[i, j].TileFrameY / 16 % 3;

            Point position = new Point(x - 1, y - 1);

            for (int z = 0; z < 15; z++)
            {
                Dust.NewDust(position.ToWorldCoordinates(), 32, 48, DustID.Stone, 0.5f, 0.5f, 0, default, 1.5f);
            }
            //NPC.SpawnBoss((int)(Main.LocalPlayer.position.X), (int)(Main.LocalPlayer.position.Y + 1000), ModContent.NPCType<RatKing>(), Main.LocalPlayer.whoAmI);
            Main.tile[x, y].ClearTile();
            Main.tile[x, y + 1].ClearTile();
            Main.tile[x, y + 2].ClearTile();
            Main.tile[x + 1, y].ClearTile();
            Main.tile[x + 1, y + 1].ClearTile();
            Main.tile[x + 1, y + 2].ClearTile();


            return true;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<RatKingStatue>());
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<RatKingStatue>();
        }
    }
}
