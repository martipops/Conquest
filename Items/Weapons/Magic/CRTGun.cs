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

namespace Conquest.Items.Weapons.Magic
{
	public class CRTGun	: ModItem
	{
		SoundStyle RetroBlast = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/Retro_Blast")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 3,
        };
		public override void SetDefaults()
        {
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 3));
			Item.width = 26; 
            Item.height = 22;
            Item.value = 1000;
            Item.noMelee = true;
            Item.rare = 6;
            Item.mana = 15;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.damage = 20;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
			Item.shoot = ModContent.ProjectileType<CRTBlast>();
			Item.shootSpeed = 16;
			Item.autoReuse = true;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			int NumProjectiles = 8 + Main.rand.Next(8); // 3, 4, or 5 shots

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(45));

                newVelocity *= 2f - Main.rand.NextFloat(1f);

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, 0, player.whoAmI);
            }
			SoundEngine.PlaySound(RetroBlast, player.position);
            return false;

        }
	}
}