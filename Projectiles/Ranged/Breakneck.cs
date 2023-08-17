using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Conquest.Assets.Common;

namespace Conquest.Items.Weapons.Ranged
{
    public class Breakneck : ModItem
    {
        public static float fireRateTimer; // timer to control fire rate of the gun
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 7;
            Item.value = Item.buyPrice(gold: 1);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            // Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Bullet;

            // Weapon Properties
            Item.damage = 35;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = Item.useAmmo;
            Item.shootSpeed = 12f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override void HoldItem(Player player)
        {
            fireRateTimer++;

            // if player is not killing by 2 seconds, fire rate goes slow
            if (fireRateTimer % 120 == 0 && MyProjectile.killsCount > 0)
            {
                MyProjectile.killsCount -= 1;
            }
            // it can't get more, than 6 stacks, so
            if (MyProjectile.killsCount > 6)
            {
                MyProjectile.killsCount = 6;
            }
        }
        public override void UpdateInventory(Player player)
        {
            if (player.HeldItem.ModItem is not Breakneck)
            {
                fireRateTimer = 0;
            }
            base.UpdateInventory(player);
        }
        public override float UseTimeMultiplier(Player player) //this stuff is increases shooting speed
        {
            float multiplier; // default value

            if (MyProjectile.killsCount > 0)
            {
                multiplier = 1 / (float)Math.Sqrt(MyProjectile.killsCount); // here is how shooting speed actually increases
                // imortant note: if Use Time getting lower, gun shoots faster, so here we are decreasing value of multiplier
            }
            else
            {
                multiplier = 1f; // 1/0 = inf, so if it's equals true, it makes multiplier = 1f
            }

            return multiplier;
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
            SoundEngine.PlaySound(SoundID.Item11 with { MaxInstances = 5 });
            return true;

        }
    }
}
