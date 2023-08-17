using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Terraria.Audio;
using Conquest.Assets.Common;

namespace Conquest.Items.Weapons.Ranged
{
    public class Model94 : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("AK-47u");
            Item.ResearchUnlockCount = 1;
        }

        SoundStyle Reload = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/M94Reload")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 8,
        };

        int bullets = 8, bulletsMax = 8;
        int reloadCooldown = 0;
        bool reloading = true;
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 43;
            Item.height = 10;
            Item.rare = 1;
            Item.value = Item.buyPrice(gold: 40);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = false;

            // Weapon Properties
            Item.damage = 44;
            Item.knockBack = 6f;
            Item.DamageType = DamageClass.Ranged;
            Item.crit = 15 - 4;
            // Projectile Properties
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override bool CanUseItem(Player player)
        {
            return bullets > 0;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            reloading = false;
            reloadCooldown = -1;
            bullets--;
            if (bullets < 1)
            {
                reloadCooldown = 40;
                reloading = true;
            }
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity *= 2f;
        }

        public override void UpdateInventory(Player player)
        {
            Item.SetNameOverride("Winchester M94 - " + bullets + "/" + bulletsMax);

            if (player.HeldItem == Item)
            {
                if (Keybinds.Reload.JustPressed && bullets < bulletsMax)
                {
                    reloadCooldown = 40;
                    reloading = true;
                }

                if (reloadCooldown == 40)
                {
                    SoundEngine.PlaySound(Reload, player.position);
                }
                reloadCooldown--;
                if (reloadCooldown == 0)
                {
                    bullets++;
                    reloadCooldown = -1;
                    if (reloading && bullets < bulletsMax) reloadCooldown = 40;
                }
            }
            else if (reloadCooldown > 0) reloadCooldown = 40;
        }
    }
}
