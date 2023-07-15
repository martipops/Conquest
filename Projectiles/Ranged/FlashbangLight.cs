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

namespace Conquest.Projectiles.Ranged
{
    internal class FlashbangLight : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("闪光");
        }
        public override void SetDefaults()
        {
            Projectile.width = 188;
            Projectile.height = 188;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Default;
            Projectile.penetrate = 100;
            Projectile.timeLeft = 300;
            Projectile.alpha = 127;
            Projectile.light = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void OnSpawn(IEntitySource source)
        {
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.ChaosState, 120, true);
        }
        public override void AI()
        {
            Projectile.alpha += 16;
            if (Projectile.alpha >= 255)
            {
                Projectile.Kill();
            }
        }
    }
}
