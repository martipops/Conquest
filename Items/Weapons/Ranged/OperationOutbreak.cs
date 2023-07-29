using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Conquest.Projectiles.HeldProjectiles;
using Terraria.GameContent.Creative;
using Conquest.Buffs;
using Conquest.Projectiles.Ranged;
using Terraria.ID;
using Terraria;

namespace Conquest.Items.Weapons.Ranged
{
    public class OperationOutbreak : ModItem
    {
        // test

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 10;
            Item.value = Item.sellPrice(gold: 3);
            Item.noMelee = true;
            Item.crit = 10;
            // Use Properties
            Item.useAnimation = 24;
            Item.useTime = 8;
            Item.reuseDelay = 28;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.damage = 51;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 142;
            Item.height = 56;
            Item.useTime = 48;
            Item.useAnimation = 48;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item31;
            Item.knockBack = 3;
            Item.rare = ItemRarityID.Green;
            Item.autoReuse = true;
            Item.shootSpeed = 20f;
            Item.shoot = ModContent.ProjectileType<OperationOutbreakHeld>();
            Item.crit = 10;
            Item.noMelee = true;
            Item.value = Item.buyPrice(gold: 2, silver: 3);
            Item.noUseGraphic = true;
            Item.channel = true;

            // Weapon Properties
            Item.damage = 51;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 14f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-22, -6);
        }

        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(ModContent.BuffType<Overheat>()))
            {
                return false;
            }
            else
            {
                return true;
            }


        }
    }
}