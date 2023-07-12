using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Conquest.Assets.Common;

namespace Conquest.Projectiles.Summoner
{
    internal class EmeraldWall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;

        }

        public override void SetDefaults()
        {
            Projectile.width = 122;
            Projectile.height = 154;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }

        private int timer = 0;
        private int killTimer = 0;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            timer++;
            if (timer < 5)
            {
                Projectile.frame = 0;
            }
            if (timer >= 5 && timer < 10)
            {
                Projectile.frame = 1;
            }
            if (timer >= 10 && timer < 15)
            {
                Projectile.frame = 2;
            }
            if (timer >= 15)
            {
                Projectile.frame = 3;
            }

            if (player.Center.Distance(Projectile.Center) <= 75)
            {
                player.GetModPlayer<MyPlayer>().emerald = true;
            }
            else if (player.Center.Distance(Projectile.Center) > 75)
            {
                player.GetModPlayer<MyPlayer>().emerald = false;
            }

            if (timer >= 480 || player.GetModPlayer<MyPlayer>().emeraldBoom)
            {
                Boom();
            }
        }

        public void Boom()
        {
            killTimer++;
            if (killTimer < 5)
            {
                Projectile.frame = 4;
            }
            if (killTimer >= 5)
            {
                Projectile.frame = 5;
            }
            if (killTimer >= 10)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-20, 20), Main.rand.Next(-20, 20)), ModContent.ProjectileType<EmeraldWallSharp>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-20, 20), Main.rand.Next(-20, 20)), ModContent.ProjectileType<EmeraldWallSharp>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-20, 20), Main.rand.Next(-20, 20)), ModContent.ProjectileType<EmeraldWallSharp>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-20, 20), Main.rand.Next(-20, 20)), ModContent.ProjectileType<EmeraldWallSharp>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-20, 20), Main.rand.Next(-20, 20)), ModContent.ProjectileType<EmeraldWallSharp>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-20, 20), Main.rand.Next(-20, 20)), ModContent.ProjectileType<EmeraldWallSharp>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-20, 20), Main.rand.Next(-20, 20)), ModContent.ProjectileType<EmeraldWallSharp>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-20, 20), Main.rand.Next(-20, 20)), ModContent.ProjectileType<EmeraldWallSharp>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Projectile.Kill();
            }
        }
        public override void Kill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];
            player.GetModPlayer<MyPlayer>().emeraldCD = 480;
        }
    }
}
