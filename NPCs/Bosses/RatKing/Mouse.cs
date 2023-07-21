using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.UI;

namespace Conquest.NPCs.Bosses.RatKing
{
    internal class Mouse : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 4;
        }
        public override void SetDefaults()
        {
            NPC.width = 88;
            NPC.height = 158;
            NPC.damage = 0;
            NPC.defense = 66;
            NPC.lifeMax = 100000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.value = Item.buyPrice(gold: 5);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.noTileCollide = true;
            NPC.npcSlots = 10f;
            //NPC.aiStyle = -1;
          //  AIType = NPCID.MartianSaucer;
        }
        int timer;
        private enum Frame
        {
            Idle1,
            Idle2,
            Idle3,
            Idle4,
        }
        public override void AI()
        {
            timer++;
            NPC.TargetClosest(true);
           
            if (timer >= 480)
            {
               
            }
            float horMoveSpeed = 0.30f;
            float maxMoveSpeed = 20f;
            if (NPC.Center.X > Main.player[NPC.target].Center.X - 100)
            {
                if (NPC.velocity.X > 0)
                    NPC.velocity.X *= 0.98f;

                NPC.velocity.X -= horMoveSpeed;

                if (NPC.velocity.X < -maxMoveSpeed)
                    NPC.velocity.X = -maxMoveSpeed;
            }
            if (NPC.Center.X < Main.player[NPC.target].Center.X + 100)
            {
                if (NPC.velocity.X < 0)
                    NPC.velocity.X *= 0.98f;

                NPC.velocity.X += horMoveSpeed;

                if (NPC.velocity.X > maxMoveSpeed)
                    NPC.velocity.X = maxMoveSpeed;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            NPC.spriteDirection = NPC.direction;
            if (NPC.frameCounter < 10)
            {
                NPC.frame.Y = (int)Frame.Idle1 * frameHeight;
            }
            else if (NPC.frameCounter < 20)
            {
                NPC.frame.Y = (int)Frame.Idle2 * frameHeight;
            }
            else if (NPC.frameCounter < 30)
            {
                NPC.frame.Y = (int)Frame.Idle3 * frameHeight;
            }
            else if (NPC.frameCounter < 40)
            {
                NPC.frame.Y = (int)Frame.Idle4 * frameHeight;
            }
            else
            {
                NPC.frameCounter = 0;
            }
        }
    }
}
