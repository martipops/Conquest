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
using Conquest.NPCs.Bosses.Anubis;
using Terraria.Audio;

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
            NPC.lifeMax = 200000;
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
           
            if (timer == 480)
            {
                var entitySource = NPC.GetSource_FromAI();
                Projectile.NewProjectile(entitySource, NPC.Center.X, NPC.Center.Y, Main.rand.Next(0, 0), Main.rand.Next(0, 0), ModContent.ProjectileType<CheeseRelease>(), 100, 0f, Main.myPlayer);
            }
            if(timer >= 720)
            {
                float speed = 10f;
                int type = ModContent.ProjectileType<Cheese2>();
                int damage = 65;
                var entitySource = NPC.GetSource_FromAI();
               
                for (int ir = 0; ir < 7; ir++)
                {
                    Vector2 positionNew = Vector2.Lerp(new Vector2(NPC.Center.X - 800, NPC.Center.Y + 800), new Vector2(NPC.Center.X - 800, NPC.Center.Y - 800), (float)ir / 7);
                    Vector2 velocity = new Vector2(speed, 0);

                    Projectile.NewProjectile(entitySource, positionNew, velocity, type, damage / 4, 0f, Main.myPlayer);
                }


                    timer = 0;
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
