using Conquest.Assets.Common;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Projectiles
{
    public class Air : ModProjectile
    {
        float timer;
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;
            Projectile.alpha = 255;
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;

        }

        public override void OnSpawn(IEntitySource source)
        {
            timer = 0.9f;
        }



        public override void AI()
        {

            Projectile.velocity *= 1.001f;
            Projectile.aiStyle = 0;
            if (timer > 0f)
            {
                timer -= 0.3f;
            }

            if (timer == 0f)
            {
                
                Projectile.alpha -= 255;
                timer = -1;
                Projectile.Kill();
            }
        }

    }
}
