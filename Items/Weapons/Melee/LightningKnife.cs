using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
	public class LightningKnife : ModItem
	{
		public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }
		public override void SetDefaults()
        {
            
			Item.width = 30;
            Item.height = 22;
            Item.value = 100000;
            Item.noMelee = true;
            Item.rare = 6;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.noUseGraphic = false;
            Item.damage = 25;
            Item.knockBack = 3f;
            Item.DamageType = ModContent.GetInstance<FoudreDamageClass>(); 
            Item.shootSpeed = 8f;
            Item.shoot = ModContent.ProjectileType<LightningKnifeProjectile>();
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -10);
		}
        public override void AddRecipes()
        {
            CreateRecipe()
                      .AddIngredient(ItemID.HallowedBar, 12)
                      .AddIngredient(ItemID.ThrowingKnife, 12)
                      .AddTile(TileID.MythrilAnvil)
                      .Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			int NumProjectiles = 3;
            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedBy(MathHelper.ToRadians((i*10)-15));
                newVelocity *= 2f;
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, 0, player.whoAmI);
            }
			SoundEngine.PlaySound(SoundID.Item5, player.position);
            return false;
		}
	}
    public class FoudreDamageClass : DamageClass
    {
     
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Generic)
                return StatInheritanceData.Full;

            if (damageClass == DamageClass.Ranged)
                return StatInheritanceData.Full;
            if (damageClass == DamageClass.Melee)
                return StatInheritanceData.Full;

            return StatInheritanceData.None;

        }
        public override bool UseStandardCritCalcs => true;

    }



}