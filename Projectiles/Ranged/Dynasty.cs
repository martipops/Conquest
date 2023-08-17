using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Conquest.Projectiles.Ranged;

namespace Conquest.Items.Weapons.Ranged
{
    public class Dynasty : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Fires helix rounds");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 7;
            Item.value = Item.buyPrice(gold: 65);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;

            // Weapon Properties
            Item.damage = 28;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<DynastyProj>();
            Item.shootSpeed = 12f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Color[] colors = new Color[] { Color.DarkGoldenrod, Color.DarkGray };
            int projectileCount = 2;

            for (int i = 0; i < projectileCount; i++)
            {
                // Be wary of dividing by zero when projectileCount is 1
                float waveOffset = i / (float)(projectileCount - 1);

                Projectile projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);

                DynastyProj modProjectile = projectile.ModProjectile as DynastyProj;
                modProjectile.waveOffset = waveOffset * (1f - 1f / projectileCount);
                modProjectile.drawColor = colors[i];

            }

            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }

    }
}
