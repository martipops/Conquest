using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
    public class EyeOfTheStorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 24;
            Item.height = 24;
            Item.rare = 1;
            Item.value = Item.sellPrice(silver: 1);
            // Use Properties
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            // Weapon Properties
            Item.damage = 12;
            Item.knockBack = 6f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<StormYoyo>();

        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.Cloud, 13)

            .AddIngredient(ItemID.RainCloud, 13)
           .AddTile(TileID.Anvils)
           .Register();
        }
    }

}
