			using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Conquest.Projectiles.Magic;
using Conquest.Buffs;

namespace Conquest.Projectiles.Magic
{
	public class CRTBlast : ModProjectile
	{
		public override void SetStaticDefaults()
    {	
			Main.projFrames[Projectile.type] = 2;
		}
		public override void SetDefaults() {
			Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 10;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.penetrate = 3;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 1;
			Projectile.timeLeft = 60;
			Projectile.extraUpdates = 1;

			Projectile.penetrate = 3;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
		}
		public override void AI()
		{
			Projectile.velocity /= 1.05f;
			Projectile.rotation = 0;
			if ((Main.rand.Next(3) > 1) || (Projectile.timeLeft == 300)) Projectile.frame = Main.rand.Next(2);
			if (Projectile.timeLeft < 5) Projectile.alpha += 64;
			base.AI();
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.type != NPCID.TargetDummy) target.AddBuff(ModContent.BuffType<Lag>(), Main.rand.Next(60, 181));
        }
    }
}