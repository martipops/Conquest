
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
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Conquest.NPCs.Ocean
{
    public class SpiritJellyfish : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.PinkJellyfish];
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
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,

                new FlavorTextBestiaryInfoElement(""),

            });
        }
        private enum ActionState
        {
            Check,
            Chase,


        }
        public override void SetDefaults()
        {
            NPC.noGravity = true;
            NPC.width = 26;
            NPC.height = 26;
            NPC.aiStyle = 18;
            NPC.damage = 75;
            NPC.defense = 20;
            NPC.lifeMax = 150;
            NPC.HitSound = SoundID.NPCHit25;
            NPC.DeathSound = SoundID.NPCDeath28;
            NPC.value = 800f;
            NPC.knockBackResist = 0f;
            NPC.alpha = 20;
            AIType = NPCID.BloodJelly;
            AnimationType = NPCID.BloodJelly;
            //  NPC.CloneDefaults(NPCID.BloodJelly);

        }
        public override void OnKill()
        {
            var settings = new ParticleOrchestraSettings
            {
                PositionInWorld = NPC.Center,
                MovementVector = NPC.velocity
            };
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.RainbowRodHit, settings);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneBeach && Main.hardMode && spawnInfo.Water && !Main.dayTime)
            {

                return 0.3f;
            }
            else
                return 0f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<JellyfishTentacle>(), 3));

        }
    }


    /*   public ref float AI_State => ref NPC.ai[0];
       public ref float AI_Timer => ref NPC.ai[1];
       private void FallAsleep()
       {
           NPC.TargetClosest(true);

           if (NPC.HasValidTarget && Main.player[NPC.target].Distance(NPC.Center) < 500f)
           {
               AI_State = (float)ActionState.Chase;
               AI_Timer = 0;
           }
           else
               NPC.velocity = Vector2.Zero;
       }
       private void chase()
       {
           Player target = Main.player[NPC.target];
           NPC.friendly = false;
           // NPC.rotation = (target.Center - NPC.Center).ToRotation();
           NPC.rotation = (NPC.Center - target.Center).ToRotation();
           if (Main.player[NPC.target].Distance(NPC.Center) < 450f)
           {
               Vector2 ToPlayer = NPC.DirectionTo(target.Center) * 2;
               NPC.velocity = ToPlayer;
               AI_Timer++;

           }
           else if (AI_Timer >= 360)
           {
               AI_State = (float)ActionState.Check;
               AI_Timer = 0;
           }

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
           }

       }

    */

}




