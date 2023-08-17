using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Weapons.Ranged
{
    public class Kohm : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Fire rate increases up to 80% while using this weapon, bonus is lost when you stop firing\n66% Chance to not consume ammo");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 10;
            Item.value = Item.sellPrice(gold: 3);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;

            // Weapon Properties
            Item.damage = 25;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
        }
        int timer;
        public override bool? UseItem(Player player)
        {
            // Increase our Fire rate until the limit of 6
            if (Item.useTime != 6)
            {
                timer++;
            }
            return true;
        }
        public override void HoldItem(Player player)
        {
            // If firing increase fire rate (reduce use time) based on the timer
            if (Main.mouseLeft && Item.useTime != 0 && Item.useAnimation != 0)
            {
                Item.useAnimation = Item.useTime = (int)(30 - timer / 30f * 8);
            }
            // If player stops shooting reset timer to 0
            if (Main.mouseLeftRelease)
            {
                timer = 0;
            }
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
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
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-14, 0);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FragmentVortex, 20)
            .AddIngredient(ItemID.OnyxBlaster, 1)
            .AddIngredient(ItemID.TacticalShotgun, 1)
            .AddIngredient(ItemID.QuadBarrelShotgun, 1)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.66f;
        }

    }
}
