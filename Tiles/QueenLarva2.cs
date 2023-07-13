using Assortedarmaments.NPCs.Bosses;
using Conquest.NPCs.Bosses;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Conquest.Tiles
{
    public class QueenLarva2 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
            AnimationFrameHeight = 54;
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Antlion Eggs");
            AddMapEntry(new Color(234, 0, 0), name);

        }
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter >= 8)
            {
                frame++;
                frameCounter = 0;
                if (frame >= 7)
                {
                    frame = 0;
                }
            }
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            return false;
        }
        public override void MouseOver(int i, int j)
        {
            Main.LocalPlayer.cursorItemIconEnabled = true;
            Main.LocalPlayer.cursorItemIconID = -1;


            if (NPC.downedBoss1)
                Main.LocalPlayer.cursorItemIconText = "Disturb the eggs!";
            else
                Main.LocalPlayer.cursorItemIconText = "Touching it seems to do nothing...";
        }
        public override bool RightClick(int i, int j)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<AntlionQueen>()))
                return false;

            if (Main.netMode != NetmodeID.MultiplayerClient && NPC.downedBoss1)
            {
                Main.NewText("The Antlion Queen has awoken!", 175, 75, 255);
                int npcID = NPC.NewNPC(new EntitySource_TileBreak(i, j), i * 16, j * 16 - 600, ModContent.NPCType<AntlionQueen>());
                Main.npc[npcID].netUpdate2 = true;
                // scrapped, but will save for future (;
                /*WorldGen.KillTile(i, j);
                if (!Main.tile[i, j].HasTile && Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
                }
                */

            }
            //this probably doesnt work in multiplayer
            return true;
        }
    }
}
