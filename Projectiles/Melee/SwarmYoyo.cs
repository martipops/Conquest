using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Projectiles.Melee
{
    public class SwarmYoyo : ModProjectile
    {
        public override void SetStaticDefaults()
        {
         //   ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 2.5f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 600f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 15f;

        }
        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 18;
            Projectile.height = 20;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];

            Vector2 perturbedSpeed = new Vector2(0, -6).RotatedByRandom(MathHelper.ToRadians(360));
            if (Main.rand.NextBool(3))
            {
                if (player.strongBees)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(perturbedSpeed.X, perturbedSpeed.Y), ProjectileID.GiantBee, Projectile.damage, 0, Projectile.owner);
                }
                else
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(perturbedSpeed.X, perturbedSpeed.Y), ProjectileID.Bee, Projectile.damage, 0, Projectile.owner);

            }
        }
    }
}
