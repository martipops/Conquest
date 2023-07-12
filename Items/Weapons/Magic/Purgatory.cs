
using Conquest.Items.Materials;
using Conquest.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace Conquest.Items.Weapons.Magic
{
    public class Purgatory : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("Fires homing ghosts, if there is no valid target purgatory will not fire anything");
            Item.staff[Item.type] = true;

        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.sellPrice(gold: 10);
            Item.noMelee = true;
            Item.rare = 10;
            // Use Properties
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 115;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 30;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Ghosty>();
            Item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.SpectreStaff, 1)
           .AddIngredient(ItemID.FragmentNebula, 12)
            .AddIngredient(ModContent.ItemType<SoulPiece>(), 5)
           .AddTile(TileID.MythrilAnvil)
           .Register();

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 4;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false;
        }

    }
}
