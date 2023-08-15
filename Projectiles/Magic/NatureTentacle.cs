using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Projectiles.Magic
{
    public class NatureTentacle : ModProjectile
    {
        float dustScale = 1f;
        float targetSpeed = 8f;

        Vector2 effectiveVelocity, oldPosition, originalPosition;

        public override void SetDefaults()
        {

            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 40 * (6 + 1);

            Projectile.extraUpdates = 6;
        }
        public override void AI()
        {
            dustScale = MathHelper.Lerp(dustScale, 0f, 0.02f);
            Dust d = Dust.NewDustDirect(Projectile.Center + Main.rand.NextVector2Circular(2, 2), 1, 1, DustID.Grass, Scale: dustScale);
            d.noGravity = true;
            d.velocity = Vector2.Zero;
            Vector2 toTarget = Projectile.DirectionTo(Main.MouseWorld) * targetSpeed * dustScale;
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, toTarget, 0.001f);

            if (dustScale < 0.01f) Projectile.Kill();

            foreach (NPC npc in Main.npc)
            {
                if (npc.Hitbox.Intersects(Projectile.Hitbox) && npc.active && ModContent.GetInstance<NatureTentacleHitManager>().hitCooldown > 0)
                {
                    Projectile.Kill();
                }
            }
            if (dustScale < 0.1f) Projectile.Kill();

            effectiveVelocity = Projectile.position - oldPosition;
            oldPosition = Projectile.position;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];
            ModContent.GetInstance<NatureTentacleHitManager>().hitCooldown = 10;

            if (hit.Crit)
            {
                player.Heal(5);
            }
        }

        public override bool? CanHitNPC(NPC target)
        {
            return ModContent.GetInstance<NatureTentacleHitManager>().hitCooldown <= 0;
        }
    }
}

public class NatureTentacleHitManager : ModSystem
{
    public int hitCooldown = 0;

    public override void PostUpdateProjectiles()
    {
        hitCooldown--;
        if (hitCooldown < 0) hitCooldown = 0;
    }
}
