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
using Conquest.Dusts;

namespace Conquest.Projectiles.Ranged
{
    internal class WindArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("细箭");
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;
            Projectile.alpha = 127;
            Projectile.light = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Dust.NewDust(Projectile.Center, 1, 1, ModContent.DustType<Wind>(), Projectile.velocity.X / 100, Projectile.velocity.Y / 100, 0, default, 1);
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
    }
}
