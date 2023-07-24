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
			Projectile.aiStyle = 0;
			Projectile.timeLeft = 30;
		}
		public override void AI()
		{
			Projectile.position += Projectile.velocity;
			Projectile.velocity /= 1.4f;
			Projectile.rotation = 0;
			if ((Main.rand.Next(3) > 1) || (Projectile.timeLeft == 300)) Projectile.frame = Main.rand.Next(2);
			base.AI();
		}
	}
}