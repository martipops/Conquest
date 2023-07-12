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


namespace Conquest.Projectiles.Magic
{
    internal class WabbajackStaff : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("瓦巴杰克");
        }

        public int timer = 0;
        public override void SetDefaults()
        {
            Projectile.width = 76;
            Projectile.height = 76;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 40;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ownerHitCheck = true;
            Projectile.alpha = 0;
            Projectile.light = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.hide = true;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            player.heldProj = Projectile.whoAmI;

            timer++;
            if (timer == 1)
            {
                Projectile.NewProjectile(player.GetSource_FromThis(), Projectile.Center, Projectile.velocity * 4, ModContent.ProjectileType<WabbajackProj>(), Projectile.damage, 1f, player.whoAmI, 0, 0);

            }

            Projectile.spriteDirection = (Vector2.Dot(Projectile.velocity, Vector2.UnitX) >= 0f).ToDirectionInt();

            Projectile.Center = player.Center + Projectile.velocity * 20;

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

        }

        public override bool? CanDamage()
        {
            return false;
        }
    }
}
