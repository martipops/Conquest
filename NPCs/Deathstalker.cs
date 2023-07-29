
using Conquest.Items.Materials;
using Conquest.Items.Weapons.Ranged;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
namespace Conquest.NPCs
{
    public class Deathstalker : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 15; // make sure to set this for your modnpcs.
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = -1

            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

        }

        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];
        public override void SetDefaults()
        {
            NPC.width = 64;
            NPC.height = 46;
            NPC.aiStyle = -1;
            NPC.damage = 35;
            NPC.defense = 30;
            NPC.lifeMax = 300;
            NPC.HitSound = SoundID.NPCHit31;
            NPC.DeathSound = SoundID.NPCDeath34;
            NPC.value = 255f;
            NPC.aiStyle = 3;
            NPC.knockBackResist = 0;
            NPC.npcSlots = 1;
            AIType = NPCID.BlueArmoredBones; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
            AnimationType = NPCID.BlueArmoredBones;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert,

                new FlavorTextBestiaryInfoElement("Deathstalkers have evolved to have better stamina for chasing their prey and a massive stinger, at the cost of their claws."),


            });
        }
        public override void AI()
        {

            NPC.TargetClosest(true);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PainTrain>(), 100));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DeathstalkerShell>(), 2));

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
            if (NPC.CountNPCS(ModContent.NPCType<Deathstalker>()) == 2)
            {
                return SpawnCondition.DesertCave.Chance * 0f;
            }
            else
                return SpawnCondition.DesertCave.Chance * 0.01f;
        }
    }
}
