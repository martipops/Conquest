using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Conquest.NPCs.Night
{
    public class CRTZombie : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];
        }
        public override void SetDefaults()
        {
            NPC.noGravity = true;
            NPC.width = 34;
            NPC.height = 46;
            NPC.damage = 20;
            NPC.defense = 30;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 500f;
            NPC.knockBackResist = 0f;
            AIType = NPCID.Zombie;
            AnimationType = NPCID.Zombie;
            NPC.aiStyle = 3;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedBoss3)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.2f;
            }
            else return 0f;
        }
    }
}
