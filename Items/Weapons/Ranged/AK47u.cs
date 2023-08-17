using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Terraria.Audio;
using Conquest.Assets.Common;

namespace Conquest.Items.Weapons.Ranged
{
    public class AK47u : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("AK-47u");
            Item.ResearchUnlockCount = 1;
        }

        SoundStyle Reload = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/AKReload")
        {
            Volume = 0.9f,
            PitchVariance = 0.1f,
            MaxInstances = 3,
        };

        int bullets = 30, bulletsMax = 30;
        int reloadCooldown = 0;
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 1;
            Item.value = Item.buyPrice(gold: 65);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;

            // Weapon Properties
            Item.damage = 9;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
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
            return reloadCooldown <= 0;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            bullets--;
            if (bullets < 1)
            {
                reloadCooldown = 90;
            }
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-5f, 10f)));
        }

        public override void UpdateInventory(Player player)
        {
            Item.SetNameOverride("AK47u - " + bullets + "/" + bulletsMax);

            if (player.HeldItem == Item)
            {
                if (Keybinds.Reload.JustPressed && bullets < bulletsMax) reloadCooldown = 90;

                if (reloadCooldown == 90)
                {
                    SoundEngine.PlaySound(Reload, player.position);
                }
                reloadCooldown--;
                if (reloadCooldown == 0)
                {
                    bullets = bulletsMax;
                    reloadCooldown = -1;
                }
            }
            else if (reloadCooldown > 0) reloadCooldown = 90;
        }
    }
}
