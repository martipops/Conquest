using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Projectiles.Melee
{
    public class MountainBreakerProj : ModProjectile
    {
      
            public override void SetDefaults()
            {
                Projectile.width = 32;
                Projectile.height = 32;
                Projectile.friendly = true;
                Projectile.hostile = false;
                Projectile.DamageType = DamageClass.Melee;
                Projectile.penetrate = 1;
                Projectile.aiStyle = ProjAIStyleID.GroundProjectile;
                Projectile.timeLeft = 300;
                Projectile.alpha = 0;
                Projectile.light = 0;
                Projectile.ignoreWater = true;
                Projectile.tileCollide = true;
            }
        }
    }

