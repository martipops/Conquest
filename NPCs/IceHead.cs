using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.NPCs
{
    public class IceHead : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ice Head");
            Main.npcFrameCount[NPC.type] = 5;
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = -1

            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow,

                new FlavorTextBestiaryInfoElement("This fish is found in the underground tundra. It has a large ice block for a head, which it drags along the bottom of pockets of water."),

            });
        }
        public override void SetDefaults()
        {
            NPC.width = 58;
            NPC.height = 22;
            NPC.damage = 20;
            NPC.defense = 0;
            NPC.lifeMax = 55;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.65f;
            NPC.aiStyle = 16;
            NPC.noGravity = true;
            NPC.npcSlots = 0;
            AIType = NPCID.CorruptGoldfish;
            NPC.dontTakeDamageFromHostiles = false;
        }
        private enum Frame
        {
            Frame1,
            Frame2,
            Frame3,
            Frame4,
            Frame5
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IceFish1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IceFish2").Type, 1f);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneSnow && spawnInfo.Player.ZoneRockLayerHeight && spawnInfo.Water)
            {
                return 0.3f;
            }
            else
                return 0f;
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            NPC.spriteDirection = NPC.direction;

            if (NPC.frameCounter < 5)
            {
                NPC.frame.Y = (int)Frame.Frame1 * frameHeight;
            }
            else if (NPC.frameCounter < 10)
            {
                NPC.frame.Y = (int)Frame.Frame2 * frameHeight;
            }
            else if (NPC.frameCounter < 15)
            {
                NPC.frame.Y = (int)Frame.Frame3 * frameHeight;
            }
            else if (NPC.frameCounter < 16)
            {
                NPC.frame.Y = (int)Frame.Frame4 * frameHeight;
            }
            else if (NPC.frameCounter < 20)
            {
                NPC.frame.Y = (int)Frame.Frame5 * frameHeight;
            }
            else
            {
                NPC.frameCounter = 0;
            }

        }
    }
}

