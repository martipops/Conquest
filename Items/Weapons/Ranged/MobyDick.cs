
using Conquest.Assets.Common;
using Conquest.Items.Materials;
using Conquest.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Weapons.Ranged
{
    public class MobyDick : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Fires 3 Cannoballs which explode on impact\n99% Chance to not consume ammo");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 10;
            Item.value = Item.sellPrice(gold: 33);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item38;
            Item.autoReuse = true;

            // Weapon Properties
            Item.damage = 225;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 9f;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<MyPlayer>().ScreenShake = 8;

            return true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ModContent.ItemType<ThankYou>(), 3)

           .AddTile(TileID.LunarCraftingStation)
           .Register();


        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 3;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(3));

                newVelocity *= 2f - Main.rand.NextFloat(0.3f);

                Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<Cannonball>(), damage * 5, knockback, player.whoAmI);
            }
            float numberProjectiles = 6;
            float rotation = MathHelper.ToRadians(5);
            position += Vector2.Normalize(velocity) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .8f;
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }


            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-14, 0);
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.99f;
        }

    }
}
