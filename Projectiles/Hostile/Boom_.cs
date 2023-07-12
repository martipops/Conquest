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
using Terraria.Audio;

namespace Conquest.Projectiles.Hostile
{
    internal class Boom_ : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("爆炸");

            Main.projFrames[Projectile.type] = 9;
        }
        public override void SetDefaults()
        {
            Projectile.width = 138;
            Projectile.height = 146;
            Projectile.friendly = false;
            Projectile.hostile = true;
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
