using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Conquest.Items.Weapons.Ranged
{
    public class LivingWoodBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // DisplayName.SetDefault("Living Wood Bow");
            // Tooltip.SetDefault("Critical hits heal you");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 1;
            Item.value = Item.buyPrice(silver: 1);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 7;
            Item.knockBack = 1f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                      .AddIngredient(ItemID.Wood, 12)
                      .AddTile(TileID.LivingLoom)
                      .Register();
        }
    }
}
