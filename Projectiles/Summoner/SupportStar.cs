
using Conquest.Assets.GUI;
using Conquest.Buffs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Humanizer.In;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace Conquest.Projectiles.Summoner
{
    public class SupportStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.tileCollide = false;
            Projectile.width = 38;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.minion = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
        }
        int timer;
        int choice;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<StarSpirit>());

            }
            if(ETData.etPoints[0][6].unlocked != true)
            {
                Projectile.Kill();
            }
            if (player.HasBuff(ModContent.BuffType<StarSpirit>()))
            {
                Projectile.timeLeft = 2;
            }
            timer++;
            Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
            if (Projectile.Center.X < player.Center.X - 1)
            {
                Projectile.velocity = (player.Center + new Vector2(-1, -50) - Projectile.Center) / Projectile.Center.Distance(player.Center) * 10;

            }
            else if (Projectile.Center.X > player.Center.X + 1)
            {
                Projectile.velocity = (player.Center + new Vector2(1, -50) - Projectile.Center) / Projectile.Center.Distance(player.Center) * 10;

            }
            Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f) ? -1 : 1;

            if (player.dead || !player.active)
            {
                Projectile.Kill();
            }
            if (timer == 900)
            {
                choice = Main.rand.Next(1, 4);
            }
            if (choice == 1)
            {
                SoundEngine.PlaySound(SoundID.Item4, Projectile.position);
                player.AddBuff(ModContent.BuffType<SupportStarBuff1>(), 840);
                for (int i = 0; i < 10; i++)
                {
                    Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center, speed, Main.rand.Next(16, 18));

                }
                choice = 0;
                timer = 0;

            }
            if (choice == 2)
            {
                SoundEngine.PlaySound(SoundID.Item4, Projectile.position);
                for (int i = 0; i < 10; i++)
                {
                    Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center, speed, Main.rand.Next(16, 18));

                }

                player.AddBuff(ModContent.BuffType<SupportStarBuff2>(), 840);
                choice = 0;
                timer = 0;
            }
            if (choice == 3)
            {
                SoundEngine.PlaySound(SoundID.Item4, Projectile.position);
                for (int i = 0; i < 10; i++)
                {
                    Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center, speed, Main.rand.Next(16, 18));

                }
                choice = 0;
                timer = 0;
                for (int i = 0; i < 3; i++)
                {
                    Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ItemID.Heart);

                }

            }
            if (choice == 4)
            {
                SoundEngine.PlaySound(SoundID.Item4, Projectile.position);
                for (int i = 0; i < 10; i++)
                {
                    Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center, speed, Main.rand.Next(16, 18));

                }
                choice = 0;
                timer = 0;
                Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ItemID.Star);
            }

        }

    }
    public class SupportStarBuff1 : ModBuff
    {
        
            public override void SetStaticDefaults()
            {
                
            }
            public override void Update(Player player, ref int buffIndex)
            {
                player.GetDamage(DamageClass.Magic) += 0.10f;

            }
        
    }
    public class SupportStarBuff2 : ModBuff
    {
        
            public override void SetStaticDefaults()
            {

            }
            public override void Update(Player player, ref int buffIndex)
            {
                player.GetCritChance(DamageClass.Magic) += 0.10f;

            }
        
    }

}

