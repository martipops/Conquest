
using Conquest.Items.Materials;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Conquest.NPCs.Graveyard
{
    public class Ghostling : ModNPC
    {
        public bool Hit;

        int timer;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 3;
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = -1

            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }
        private enum ActionState
        {
            Check,
            Chase,
            Stop,
            Teleport,
            Fade,

        }
        public override void SetDefaults()
        {
            NPC.width = 42;
            NPC.height = 45;
            NPC.damage = 15;
            NPC.defense = 10;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit54;
            NPC.DeathSound = SoundID.NPCDeath52;
            NPC.value = 60f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1;
            NPC.lavaImmune = false;
            NPC.noGravity = true;
            NPC.noTileCollide = true;


        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard,

                new FlavorTextBestiaryInfoElement(""),


            });
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];
            NPC.spriteDirection = player.Center.X < NPC.Center.X ? -1 : 1;
            switch (AI_State)
            {
                case (float)ActionState.Check:
                    FallAsleep();
                    break;
                case (float)ActionState.Chase:
                    chase();
                    break;
                case (float)ActionState.Stop:
                    stop();
                    break;
                case (float)ActionState.Teleport:
                    Teleport();
                    break;
            }

        }

        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];
        private void FallAsleep()
        {
            NPC.TargetClosest(true);

            if (NPC.HasValidTarget && Main.player[NPC.target].Distance(NPC.Center) < 500f)
            {
                // Since we have a target in range, we change to the Notice state. (and zero out the Timer for good measure)
                AI_State = (float)ActionState.Chase;
                AI_Timer = 0;
            }
        }
        public bool activate;
        private void chase()
        {
            activate = true;
            NPC.friendly = false;

            if (Main.player[NPC.target].Distance(NPC.Center) < 450f)
            {
                Player target = Main.player[NPC.target];
                Vector2 ToPlayer = NPC.DirectionTo(target.Center) * 2;
                NPC.velocity = ToPlayer;
                AI_Timer++;
                if (Hit)
                {
                    Hit = false;
                    AI_State = (float)ActionState.Stop;
                    AI_Timer = 0;
                }
                if (AI_Timer >= 360)
                {
                    AI_State = (float)ActionState.Stop;
                    AI_Timer = 0;
                }
            }


        }
        private void stop()
        {
            AI_Timer++;
            NPC.friendly = true;
            NPC.alpha++;
            NPC.velocity *= 0;
            if (NPC.alpha == 255)
            {
                AI_State = (float)ActionState.Teleport;
                AI_Timer = 0;
            }
        }
        private void Teleport()
        {
            Player player = Main.player[NPC.target];

            NPC.alpha--;
            if (activate)
            {
                activate = false;
                NPC.position = player.position + new Vector2(0, -200);
            }
            if (NPC.alpha == 0)
            {
                AI_State = (float)ActionState.Chase;
                AI_Timer = 0;
            }

        }
        private enum Frame
        {
            Frame1,
            Frame2,
            Frame3
        }
        public override void OnKill()
        {

            for (int i = 0; i < 5; i++)
            {
                Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.SteampunkSteam);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            //NPC.spriteDirection = NPC.direction;

            if (NPC.frameCounter < 10)
            {
                NPC.frame.Y = (int)Frame.Frame1 * frameHeight;
            }
            else if (NPC.frameCounter < 20)
            {
                NPC.frame.Y = (int)Frame.Frame2 * frameHeight;
            }
            else if (NPC.frameCounter < 30)
            {
                NPC.frame.Y = (int)Frame.Frame3 * frameHeight;
            }
            else
            {
                NPC.frameCounter = 0;
            }

        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulPiece>(), 10));

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneGraveyard && !Main.dayTime)
            {
                return 0.3f;
            }
            else
                return 0f;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            Hit = true;
        }

    }
}
