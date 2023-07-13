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
    internal class DangerousDandelion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("危险飞絮");
        }
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 28;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.alpha = 0;
            Projectile.light = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        private int timer = 0;
        public override void AI()
        {
            timer++;
            if (timer >= 30 && timer < 60)
            {
                Projectile.velocity *= 0.9f;
                Projectile.velocity += new Vector2(0, -0.01f);
            }
            if (timer == 60)
            {
                Projectile.velocity *= -1;
            }
            if (timer >= 60 && timer < 90)
            {
                Projectile.velocity *= 1.1f;
                Projectile.velocity += new Vector2(0, 0.01f);
            }
            if (timer >= 90 && timer < 120)
            {
                Projectile.velocity *= 0.9f;
                Projectile.velocity += new Vector2(0, 0.01f);
            }
            if (timer == 120)
            {
                Projectile.velocity *= -1;
            }
            if (timer >= 120)
            {
                Projectile.velocity *= 1.1f;
                Projectile.velocity += new Vector2(0, -0.01f);
            }
        }
    }
}
