﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Conquest.Projectiles.Magic
{
    public class GhostBoom : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("爆炸");

            Main.projFrames[Projectile.type] = 13;
        }
        public override void SetDefaults()
        {
            Projectile.width = 138;
            Projectile.height = 146;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Default;
            Projectile.penetrate = 100;
            Projectile.timeLeft = 300;
            Projectile.alpha = 0;
            Projectile.light = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode);
        }

        public override void AI()
        {
            if (++Projectile.frameCounter >= 5)
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(),
                        new Vector2(Projectile.Center.X, Projectile.Center.Y),
                        Main.rand.NextVector2CircularEdge(6, 6),
                        ModContent.ProjectileType<Ghosty2>(),
                        Projectile.damage, 0, Projectile.owner);
                    }
                    Projectile.Kill();
                }
            }


        }
        public override bool? CanDamage()
        {
            if (Projectile.frame >= 1)
            {
                return false;
            }
            return base.CanDamage();
        }
    }
}

