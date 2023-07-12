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
    internal class SeedBomb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("种子炸弹");
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
            Projectile.light = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

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
                Projectile.rotation = Projectile.velocity.ToRotation();
            }
            if (timer >= 60)
            {
                Projectile.rotation = Projectile.velocity.ToRotation();
                if (Main.rand.NextBool())
                {
                    Projectile.velocity.X = 0.5f;
                }
                else
                {
                    Projectile.velocity.X = -0.5f;
                }
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.Kill();
        }
    }
}
