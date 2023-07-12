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
using Terraria.Audio;

namespace Conquest.Projectiles.Ranged
{
    public class TortoiseCannonHold : ModProjectile
    {
        public int timer = 0;
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;

        }
        public override void SetDefaults()
        {
            Projectile.width = 54;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 150;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.ownerHitCheck = true;
            Projectile.alpha = 0;
            Projectile.light = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.hide = true;
        }

        private bool channel;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            player.heldProj = Projectile.whoAmI;

            timer++;
            if (timer > 0)
            {
                Projectile.Center = player.Center + new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1));
                SoundEngine.PlaySound(SoundID.Item1);

                if (timer == 80)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<TortoiseCannonProj>(), Projectile.damage, Projectile.knockBack, player.whoAmI);
                    Projectile.Kill();
                }
            }
            Projectile.spriteDirection = (Vector2.Dot(Projectile.velocity, Vector2.UnitX) >= 0f).ToDirectionInt();

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver2 * Projectile.spriteDirection;
        }

        public override bool? CanDamage()
        {
            return false;
        }

    }
}
