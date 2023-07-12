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

namespace Conquest.Projectiles.Ranged
{
    internal class DandelionBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            Projectile.damage += 5;
            Projectile.width = 12;
            Projectile.height = 8;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.alpha = 0;
            Projectile.light = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        private int dande = 0;

        private NPC npc;

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            dande += 1;
            npc = target;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();

            if (dande > 0)
            {
                dande++;
                Projectile.velocity = npc.Center - Projectile.Center;

                if (dande >= 60 || !npc.active)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), ModContent.ProjectileType<BoomDandelion>(), Projectile.damage / 2, 0, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), ModContent.ProjectileType<BoomDandelion>(), Projectile.damage / 2, 0, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), ModContent.ProjectileType<BoomDandelion>(), Projectile.damage / 2, 0, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), ModContent.ProjectileType<BoomDandelion>(), Projectile.damage / 2, 0, Projectile.owner, 0, 0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), ModContent.ProjectileType<BoomDandelion>(), Projectile.damage / 2, 0, Projectile.owner, 0, 0);
                    Projectile.Kill();
                }
            }
        }
        public override bool? CanHitNPC(NPC target)
        {
            if (dande > 0)
            {
                return false;
            }
            return base.CanHitNPC(target);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), ModContent.ProjectileType<BoomDandelion>(), Projectile.damage / 5, 0, Projectile.owner, 0, 0);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), ModContent.ProjectileType<BoomDandelion>(), Projectile.damage / 5, 0, Projectile.owner, 0, 0);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), ModContent.ProjectileType<BoomDandelion>(), Projectile.damage / 5, 0, Projectile.owner, 0, 0);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), ModContent.ProjectileType<BoomDandelion>(), Projectile.damage / 5, 0, Projectile.owner, 0, 0);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-25, 25), Main.rand.Next(-25, 25)), ModContent.ProjectileType<BoomDandelion>(), Projectile.damage / 5, 0, Projectile.owner, 0, 0);
            return base.OnTileCollide(oldVelocity);
        }
    }
}
