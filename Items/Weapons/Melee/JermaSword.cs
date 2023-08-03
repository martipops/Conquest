using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;
using Conquest.Assets.Common;
using Terraria.DataStructures;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Conquest.Items.Weapons.Melee
{
	public class JermaSlash : ModProjectile
	{
		uint hSCool = 0;
		public override void OnSpawn(IEntitySource source)
        {
			Player player = Main.player[Projectile.owner];
            Projectile.spriteDirection = player.direction;
        }
		public override void SetDefaults()
        {
			Projectile.width = 30;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 60;
            Projectile.alpha = 0;
            Projectile.light = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
			//Projectile.usesLocalNPCImmunity = true;
            //Projectile.localNPCHitCooldown = 30;
		}
		public override void AI()
        {
			Player player = Main.player[Projectile.owner];
			Projectile.Center = player.Center+(new Vector2(5*(-Projectile.spriteDirection),10)).RotatedBy(Projectile.rotation-0.785398163f*Projectile.spriteDirection);
			Projectile.rotation += (Projectile.spriteDirection*0.3f);
			player.itemRotation = Projectile.rotation+0.785398163f;
			if (hSCool > 0)
			{
				hSCool--;
				player.GetModPlayer<MyPlayer>().ScreenShake = Math.Max(hSCool/2,player.GetModPlayer<MyPlayer>().ScreenShake);
			}
			
        }
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (hSCool == 0)
			{
				Projectile.spriteDirection *= -1;
				Projectile.timeLeft = 31;
				var n = 150;
				var i = DateTime.Now.Millisecond;
			
				hSCool = 5;
			}
		}
	}
	public class JermaSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Item.staff[Type] = true;
		}
		public override void SetDefaults()
		{
			Item.damage = 344;
			Item.DamageType = DamageClass.Melee;
			Item.width = 22;
			Item.height = 22;
			Item.useTime = 6;
			Item.shootSpeed = 6.1f;
			Item.useAnimation = 0;
			Item.knockBack = 3;
			Item.value = 800000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = true;
			
			Item.shoot = ModContent.ProjectileType<JermaSlash>();
			Item.channel = true;
		}
		public override bool CanUseItem(Player player)
		{
			return (player.ownedProjectileCounts[ModContent.ProjectileType<JermaSlash>()] <= 0);
		}
	}
}