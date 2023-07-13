using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Conquest.Projectiles.Hostile
{
    internal class SuperSeedBomb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("超级种子炸弹");
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 18;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.alpha = 0;
            Projectile.light = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        private int frameCounter = 0;
        private int timer = 0;
        public override void AI()
        {
            timer++;
            if (timer < 60)
            {
                Projectile.velocity *= 0.99f;
                Projectile.rotation = -Projectile.velocity.ToRotation();
            }
            if (timer == 60)
            {
                Projectile.velocity.Y *= -1;
                Projectile.velocity = (Main.LocalPlayer.Center - Projectile.Center) / Projectile.Center.Distance(Main.LocalPlayer.Center);
                Projectile.rotation = Projectile.velocity.ToRotation();
            }
            if (timer >= 60)
            {
                Projectile.velocity.Y += 0.1f;
            }
            if (timer >= 120 && Main.rand.NextFloat() >= 0.95)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity * 0, ModContent.ProjectileType<Boom_>(), Projectile.damage / 2, 0, 255, 0, 0);
                Projectile.Kill();
            }

            if (++frameCounter >= 5)
            {
                frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;

                }
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity * 0, ModContent.ProjectileType<Boom_>(), Projectile.damage / 2, 0, 255, 0, 0);
            Projectile.Kill();
        }
    }
}
