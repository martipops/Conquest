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
    internal class WabbajackProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("瓦巴杰克魔光");

            Main.projFrames[Projectile.type] = 5;
        }

        public int timer = 0;
        public override void SetDefaults()
        {
            Projectile.width = 56;
            Projectile.height = 52;
            Projectile.scale = 0.5f;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ownerHitCheck = true;
            Projectile.alpha = 0;
            Projectile.light = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (++Projectile.frameCounter >= 5)
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;

                }
            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {

            target.life = 1;
            target.takenDamageMultiplier = 1;
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center, Projectile.velocity * 0, ModContent.ProjectileType<Donut>(), 0, 0, Projectile.owner, 0, 0);
        }
    }
}
