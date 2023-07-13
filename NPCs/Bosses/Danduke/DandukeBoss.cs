
using Conquest.Assets.Systems;
using Conquest.Items.BossBags;
using Conquest.Items.Tile;
using Conquest.Items.Weapons.Magic;
using Conquest.Items.Weapons.Melee;
using Conquest.Items.Weapons.Ranged;
using Conquest.Projectiles.Hostile;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.NPCs.Bosses.Danduke
{
    [AutoloadBossHead]

    public class DandukeBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;
        }
        public override void SetDefaults()
        {
            NPC.lifeMax = 5500;
            NPC.damage = 0;
            NPC.defense = 26;
            NPC.knockBackResist = 0f;
            NPC.width = 30;
            NPC.height = 38;
            NPC.velocity.X *= 10f;
            NPC.velocity.Y *= 10f;
            NPC.boss = true;
            NPC.lavaImmune = false;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.BossBar = ModContent.GetInstance<Conquest.BossBar.DandukeBossBar>();

            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[]
                {
                    BuffID.ChaosState
                }
            };


            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/DandukeTheme");
            }
        }
        private int frameCounter = 0;
        public static bool dandukeAlive = false;

      
      
        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.DownedDuke, -1);
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<DandukeBossBag>()));
            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<DandukeRelic>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DandukeTrophy>(), 10));
            npcLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<WindSong>(), ModContent.ItemType<DesertDandelion>(), ModContent.ItemType<Petal>(), ModContent.ItemType<BombingStaff>()));

        }
        private bool stage2;

        public override void AI()
        {
            Main.windSpeedCurrent = 0.8f;
            dandukeAlive = true;
            Player player = Main.player[NPC.target];
            if (player.dead)
            {
                NPC.velocity.Y -= 0.1f;
                NPC.EncourageDespawn(10);
                return;
            }

            if (++frameCounter >= 5 && !stage2)
            {
                frameCounter = 0;
                NPC.frame.Y += NPC.frame.Height;
                if (NPC.frame.Y >= NPC.frame.Height * 3)
                {
                    NPC.frame.Y = 0;
                }
            }
            if (++frameCounter >= 5 && stage2)
            {
                frameCounter = 0;
                NPC.frame.Y += NPC.frame.Height;
                if (NPC.frame.Y >= NPC.frame.Height * 6)
                {
                    NPC.frame.Y = NPC.frame.Height * 3;
                }
            }
            if (NPC.life <= (NPC.lifeMax / 2) && NPC.life != NPC.lifeMax)
            {
                stage2 = true;

            }

            switch (AI_State)
            {
                case (float)ActionState.Attack:
                    Attack();
                    break;
                case (float)ActionState.Attack2:
                    Attack2();
                    break;
                case (float)ActionState.Attack3:
                    Attack3();
                    break;
                case (float)ActionState.Attack4:
                    Attack4();
                    break;
                case (float)ActionState.Attack5:
                    Attack5();
                    break;
                case (float)ActionState.Attack6:
                    Attack6();
                    break;
                case (float)ActionState.Attack7:
                    Attack7();
                    break;


            }
            if (NPC.Center.Distance(player.Center) > 500)
            {
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                //Main.NewText("Get back here!", 176, 224, 230);
                NPC.Center = player.Center + new Vector2(0, -100) + new Vector2(Main.rand.Next(-50, 50), Main.rand.Next(-50, 50));
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
            }

          


            
        }
        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];
        private enum ActionState
        {
            Attack,
            Attack2,
            Attack3,
            Attack4,
            Attack5,
            Attack6,
            Attack7,
        }
        private enum Frame
        {
            Idle1,
            Idle2,
            Idle3,
            Idle4,
            Idle5,
            Idle6,
            
        }
        private void Attack()
        {
            AI_Timer++;
            Player player = Main.player[NPC.target];
            if(AI_Timer == 60)
            {
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, (player.Center - NPC.Center) / NPC.Center.Distance(player.Center) * 10, ModContent.ProjectileType<Dandelion>(), 28, 0, 255, 0, 0);
                AI_State = (float)ActionState.Attack2;
                AI_Timer = 0;

            }

        }
        private void Attack2()
        {
            AI_Timer++;
            Player player = Main.player[NPC.target];
            if (AI_Timer == 180)
            {
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-10, -5), ModContent.ProjectileType<SeedBomb>(), 42, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-7.5f, -5), ModContent.ProjectileType<SeedBomb>(), 42, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-5, -5), ModContent.ProjectileType<SeedBomb>(), 42, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-2.5f, -5), ModContent.ProjectileType<SeedBomb>(), 42, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(0, -5), ModContent.ProjectileType<SeedBomb>(), 42, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(2.5f, -5), ModContent.ProjectileType<SeedBomb>(), 42, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(5, -5), ModContent.ProjectileType<SeedBomb>(), 42, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(7.5f, -5), ModContent.ProjectileType<SeedBomb>(), 42, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(10, -5), ModContent.ProjectileType<SeedBomb>(), 42, 0, 255, 0, 0); 
                AI_State = (float)ActionState.Attack3;
                AI_Timer = 0;

            }

        }
        private void Attack3()
        {
            AI_Timer++;
            Player player = Main.player[NPC.target];
            if (AI_Timer == 180)
            {
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(0, 10), ModContent.ProjectileType<Dandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(8, 8), ModContent.ProjectileType<Dandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-8, 8), ModContent.ProjectileType<Dandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(10, 0), ModContent.ProjectileType<Dandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-10, 0), ModContent.ProjectileType<Dandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(8, -8), ModContent.ProjectileType<Dandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-8, -8), ModContent.ProjectileType<Dandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(0, -10), ModContent.ProjectileType<Dandelion>(), 38, 0, 255, 0, 0);
                if (stage2)
                {
                    AI_State = (float)ActionState.Attack4;
                    AI_Timer = 0;
                }
                else if (!stage2)
                {
                    AI_State = (float)ActionState.Attack;
                    AI_Timer = 0;
                }
            
            }

             
        }
        private void Attack4()
        {
            AI_Timer++;
            Player player = Main.player[NPC.target];
            if (AI_Timer == 240)
            {

                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(0, 10), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(7, 7), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-7, 7), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(10, 0), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-10, 0), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(7, -7), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-7, -7), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(0, -10), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(5, 9), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(5, -9), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-5, 9), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-5, -9), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(9, 5), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(9, -5), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-9, 5), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-9, -5), ModContent.ProjectileType<DangerousDandelion>(), 38, 0, 255, 0, 0);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                NPC.Center = player.Center + new Vector2(0, -100) + new Vector2(Main.rand.Next(-50, 50), Main.rand.Next(-50, 50));
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);


                AI_State = (float)ActionState.Attack5;
                AI_Timer = 0;
            }


        }
        private void Attack5()
        {
            AI_Timer++;
            Player player = Main.player[NPC.target];
            if (AI_Timer == 240)
            {
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, (player.Center - NPC.Center) / NPC.Center.Distance(player.Center) * 15, ModContent.ProjectileType<SuperSeedBomb>(), 38, 0, 255, 0, 0);
                AI_State = (float)ActionState.Attack6;
                AI_Timer = 0;
            }


        }
        private void Attack6()
        {
            AI_Timer++;
            Player player = Main.player[NPC.target];
            if (AI_Timer == 360)
            {
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-7.75f, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-7.5f, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-7, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-6, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(-4, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(0, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(4, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(6, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(7, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(7.5f, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0);
                Projectile.NewProjectile(NPC.InheritSource(NPC), NPC.Center, new Vector2(7.75f, -5), ModContent.ProjectileType<SuperSeedBomb>(), 60, 0, 255, 0, 0); AI_State = (float)ActionState.Attack6;
                AI_Timer = 0;
                AI_State = (float)ActionState.Attack7;

            }


        }
        private void Attack7()
        {
            Vector2 direction = Main.player[NPC.target].Center - NPC.Center;
            direction.Normalize();
            direction *= 6f;
            const int AmountOfProjectiles = 3;
            AI_Timer++;
            if (AI_Timer == 121)
            {
                for (int i = 0; i < AmountOfProjectiles; ++i)
                {
                    Projectile.NewProjectileDirect(NPC.GetSource_FromAI(), NPC.Center, direction.RotatedByRandom(MathHelper.Pi / 4) * Main.rand.NextFloat(0.5f, 1f), ModContent.ProjectileType<DangerousDandelion>(), 40 / 3, 1, Main.myPlayer, 0, 0);
                }
            }
            if (AI_Timer == 241)
            {
                for (int i = 0; i < AmountOfProjectiles; ++i)
                {
                    Projectile.NewProjectileDirect(NPC.GetSource_FromAI(), NPC.Center, direction.RotatedByRandom(MathHelper.Pi / 4) * Main.rand.NextFloat(0.5f, 1f), ModContent.ProjectileType<DangerousDandelion>(), 40 / 3, 1, Main.myPlayer, 0, 0);
                }
                AI_Timer = 0;
                AI_State = (float)ActionState.Attack5;
            }
        }
    }
}


    

