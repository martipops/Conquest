
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
    public class ChristmasClaymore : ModItem
    {
        public override void SetStaticDefaults()
        {

            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = 2;

            Item.width = 68;
            Item.height = 68;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 60;
            Item.useTime = 60;
            Item.noUseGraphic = true;
            //Item.UseSound = SoundID.Item1;
            Item.noMelee = true;
            Item.autoReuse = false;

            //   Item.channel = true;
            Item.value = Item.sellPrice(silver: 12);
            Item.noMelee = true;
            // Weapon Properties
            Item.damage = 60;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<CC>();
            Item.shootSpeed = 10f;

        }


        public int attackType = 0;
        public int comboExpireTimer = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, attackType);
            Vector2 newVelocity1 = velocity.RotatedByRandom(MathHelper.ToRadians(30));
            if (Main.rand.NextBool(10))
            {
                Projectile.NewProjectileDirect(source, position, newVelocity1, ModContent.ProjectileType<Present>(), damage, knockback, player.whoAmI);
            }
            if (Main.rand.NextBool(15))
            {
                Projectile.NewProjectileDirect(source, position, newVelocity1, ModContent.ProjectileType<Present2>(), damage, knockback, player.whoAmI);
            }
            if (Main.rand.NextBool(5))
            {
                Projectile.NewProjectileDirect(source, position, newVelocity1, ModContent.ProjectileType<Present3>(), damage, knockback, player.whoAmI);
            }
            attackType = 0;

            comboExpireTimer = 0; 
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.AdamantiteBar, 12)
           .AddIngredient(ItemID.PineTreeBlock, 12)
           .AddTile(TileID.MythrilAnvil)
           .Register();


        }
    }
}
    

