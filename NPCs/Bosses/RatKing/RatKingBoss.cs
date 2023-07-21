
using Conquest.Items.BossBags;
using Conquest.Items.Tile;
using Conquest.Items.Weapons.Magic;
using Conquest.Items.Weapons.Melee;
using Conquest.Items.Weapons.Ranged;
using Conquest.NPCs.Bosses.Anubis;
using Conquest.NPCs.Miniboss.Bruiser;
using Conquest.Projectiles.Hostile;
using Conquest.Projectiles.Melee;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace Conquest.NPCs.Bosses.RatKing
{
    [AutoloadBossHead]
    internal class RatKingBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 17;
        }
        public override void SetDefaults()
        {
            NPC.width = 88;
            NPC.height = 158;
            NPC.damage = 65;
            NPC.defense = 50;
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
            NPC.aiStyle = -1;
            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/RatKing");
            }
        }
        public override void AI()
        {
            NPC.TargetClosest();
            Player target = Main.player[NPC.target];
            switch (AI_State)
            {
                case (float)ActionState.Idle:
                    Notice();
                    break;
                case (float)ActionState.SkyBeams:
                    Attack1();
                    break;
                case (float)ActionState.SwordSlash:
                    SwordSlash();
                    break;
                case (float)ActionState.Chillforasec:
                    Chillin();
                    break;
                case (float)ActionState.SwordSlash2:
                    SwordSlash2();
                    break;
            }
        } 
        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];
        private void Notice()
        {
            if (Main.player[NPC.target].Distance(NPC.Center) < 1250f)
            {
                AI_Timer++;

                if (AI_Timer >= 20)
                {
                    AI_State = (float)ActionState.SkyBeams;
                    AI_Timer = 0;
                }
            }
            else
            {
                NPC.TargetClosest(true);

                if (!NPC.HasValidTarget || Main.player[NPC.target].Distance(NPC.Center) > 500f)
                {
                    AI_State = (float)ActionState.SkyBeams;
                    AI_Timer = 0;
                }
            }
        }
        public override void OnSpawn(IEntitySource source)
        {
            var the = NPC.GetSource_FromAI();
            Vector2 spawnpos = NPC.Center + new Vector2(0f, (float)NPC.height / 2f);
            NPC.NewNPC(the, (int)spawnpos.X, (int)spawnpos.Y, ModContent.NPCType<Mouse>());
        }
        private void Attack1()
        {
            Player target = Main.player[NPC.target];
            AI_Timer++;
            if(AI_Timer == 60)
            {
                Meteors();
            }
            if (AI_Timer == 120)
            {
                Meteors();
            }
            if (AI_Timer == 180)
            {
                Meteors();
            }
            if (AI_Timer >= 181)
            {
                AI_Timer = 0;
                AI_State = (float)ActionState.SwordSlash;
            }

        }

        private void SwordSlash()
        {
            AI_Timer++;
            if(AI_Timer == 21)
            {
                var source = NPC.GetSource_FromAI();
                Vector2 position = NPC.Center;
                Vector2 targetPosition = Main.player[NPC.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 30f;
                int type = ModContent.ProjectileType<RatKingMoonSlash>();
                int damage = NPC.damage;
                Projectile.NewProjectile(source, position, direction * speed, type, damage / 3, 0f, Main.myPlayer);
            }
            if(AI_Timer >= 41)
            {
                AI_Timer = 0;
                AI_State = (float)ActionState.Chillforasec;
            }
        }
        private void Chillin()
        {
            AI_Timer++;
            if(AI_Timer >= 61)
            {
                AI_Timer = 0;
                AI_State = (float)ActionState.SwordSlash2;
            }
        }
        private void SwordSlash2()
        {
            AI_Timer++;
            if (AI_Timer == 30)
            {
                var source = NPC.GetSource_FromAI();
                Vector2 position = NPC.Center;
                Vector2 targetPosition = Main.player[NPC.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 25f;
                int type = ModContent.ProjectileType<RatKingMoonSlash2>();
                int damage = NPC.damage;
                Projectile.NewProjectile(source, position, direction * speed, type, damage / 2, 0f, Main.myPlayer);

                AI_Timer = 0;
                AI_State = (float)ActionState.Idle;
            }
           
        }
        static void AABBLineVisualizer(Vector2 lineStart, Vector2 lineEnd, float lineWidth)
        {
            Texture2D blankTexture = Terraria.GameContent.TextureAssets.Extra[195].Value;
            Vector2 texScale = new Vector2((lineStart - lineEnd).Length(), lineWidth) * 0.00390625f;//1/256, texture is 256x256
            Main.EntitySpriteDraw(blankTexture, (lineStart) - Main.screenPosition, null, Color.Red, (lineEnd - lineStart).ToRotation(), new Vector2(0, 128), texScale, SpriteEffects.None);
        }
        private void Meteors()
        {
            Player target = Main.player[NPC.target];
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                float speed = 90f;
                int type = ModContent.ProjectileType<RatKingBeam>();
                int damage = NPC.damage / 4;
                var entitySource = NPC.GetSource_FromAI();
                for (int ir = 0; ir < 5; ir++)
                {
                    Vector2 positionNew = Vector2.Lerp(new Vector2(target.Center.X - 600, target.Center.Y - 800), new Vector2(target.Center.X + 600, target.Center.Y - 800), (float)ir / 5);
                    float rotation = (float)Math.Atan2(positionNew.Y - (target.position.Y + (target.height * 0.5f)), positionNew.X - (target.position.X + (target.width * 0.5f)));
                    Vector2 velocity = new Vector2((float)((Math.Cos(rotation) * speed) * -1), (float)((Math.Sin(rotation) * speed) * -1));
                    Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y) * .2f;
                    Projectile.NewProjectile(entitySource, positionNew, perturbedSpeed, type, damage, 0f, Main.myPlayer);
                }
            }
        }
        private enum ActionState
        {
           Idle,
           SkyBeams,
           SwordSlash,
           Chillforasec,
           SwordSlash2,
        }
        private enum Frame
        {
            Idle1,
            Idle2,
            Idle3,
            Idle4,
            Swing1,
            Swing2,
            Swing3,
            Swing4,
            AltSwing1,//nope
            AltSwing2,//nope
            AltSwing3,
            AltSwing4,
            AltSwing5,
            AltSwing6,
            AltSwing7,
            AltSwing8,
            AltSwing9,
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            NPC.spriteDirection = NPC.direction;
            switch (AI_State)
            {
                case (float)ActionState.Idle: case (float)ActionState.SkyBeams:
                case (float)ActionState.Chillforasec:
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
                    break;
                case (float)ActionState.SwordSlash:
                    if (NPC.frameCounter < 10)
                    {
                        NPC.frame.Y = (int)Frame.Swing1 * frameHeight;
                    }
                    else if (NPC.frameCounter < 20)
                    {
                        NPC.frame.Y = (int)Frame.Swing2 * frameHeight;
                    }
                    else if (NPC.frameCounter < 30)
                    {
                        NPC.frame.Y = (int)Frame.Swing3 * frameHeight;
                    }
                    else if (NPC.frameCounter < 40)
                    {
                        NPC.frame.Y = (int)Frame.Swing4 * frameHeight;
                    }
                    else
                    {
                        NPC.frameCounter = 0;
                    }
                    break;
                case (float)ActionState.SwordSlash2:
                    if (NPC.frameCounter < 10)
                    {
                        NPC.frame.Y = (int)Frame.AltSwing3 * frameHeight;
                    }
                    else if (NPC.frameCounter < 20)
                    {
                        NPC.frame.Y = (int)Frame.AltSwing4 * frameHeight;
                    }
                    else if (NPC.frameCounter < 30)
                    {
                        NPC.frame.Y = (int)Frame.AltSwing5 * frameHeight;
                    }
                    else if (NPC.frameCounter < 40)
                    {
                        NPC.frame.Y = (int)Frame.AltSwing6 * frameHeight;
                    }
                    else if (NPC.frameCounter < 50)
                    {
                        NPC.frame.Y = (int)Frame.AltSwing7 * frameHeight;
                    }
                    else if (NPC.frameCounter < 60)
                    {
                        NPC.frame.Y = (int)Frame.AltSwing8 * frameHeight;
                    }
                    else if (NPC.frameCounter < 70)
                    {
                        NPC.frame.Y = (int)Frame.AltSwing9 * frameHeight;
                    }
                    else
                    {
                        NPC.frameCounter = 0;
                    }
                    break;
            }



        }

    }
}
