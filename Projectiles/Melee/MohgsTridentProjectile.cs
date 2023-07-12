using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Projectiles.Melee
{
    public class MohgsTridentProjectile : SpearProjectile
    {
        public MohgsTridentProjectile() : base(40, 44, 200) { }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];
            var entitySource = Projectile.GetSource_FromThis();
            Projectile.NewProjectile(entitySource, target.Center.X, target.Center.Y, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ModContent.ProjectileType<BloodSplash>(), 30, 0f, Projectile.owner);
            Vector2 newVelocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(15));
        }

    }
}
