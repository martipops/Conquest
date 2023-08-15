
using Conquest.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Weapons.Magic
{
    // changed by Goose
    // completely overhauled
    // now fires a controllable leaf projection

    public class LivingWoodStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("Projectiles fire at your cursor, Critical hits heal you");
            Item.staff[Item.type] = true;

        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.sellPrice(silver: 1);
            Item.noMelee = true;
            Item.rare = 1;
            // Use Properties
            Item.useTime = 1;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 6;
            Item.knockBack = 1f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 4;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<NatureTentacle>();
            Item.shootSpeed = 8f;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * Item.width * 2;
            position += muzzleOffset;
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
