
using Conquest.Items.Materials;
using Conquest.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Weapons.Magic
{
    public class SoulStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("Projectiles fire at your cursor");
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
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 10;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 4;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<SoulTentacle>();
            Item.shootSpeed = 12f;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * Item.width * 2;
            position += muzzleOffset;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ModContent.ItemType<SoulPiece>(), 7)
           .AddIngredient(ItemID.TissueSample, 7)
           .AddTile(TileID.Anvils)
           .Register();

            CreateRecipe()
           .AddIngredient(ModContent.ItemType<SoulPiece>(), 7)
           .AddIngredient(ItemID.ShadowScale, 7)
           .AddTile(TileID.Anvils)
           .Register();
        }

    }
}
