using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Conquest.Assets.GUI.ArmoredGUI;

namespace Conquest.Items.Weapons.Ranged
{
    public class Armored : ModItem
    {
        public static readonly int armoredUseTime = 15;
        public static bool heavyShot;
        public override void SetStaticDefaults()
        {

        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 44;
            Item.height = 32;
            Item.scale = 0.8f;
            Item.rare = 7;
            Item.value = Item.buyPrice(gold: 2);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = armoredUseTime;
            Item.useAnimation = armoredUseTime;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            // Weapon Properties
            Item.damage = 60;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shootSpeed = 16f;
            Item.shoot = ProjectileID.Bullet;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, -2);
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (ArmoredEnergyBar.blasterCharge > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2 && ArmoredEnergyBar.blasterCharge >= 15)
            {
                heavyShot = true;
                Projectile.NewProjectileDirect(Entity.GetSource_FromThis(), position, velocity, ProjectileID.MiniNukeRocketI, damage * 3, knockback, player.whoAmI);
                SoundEngine.PlaySound(SoundID.NPCDeath56);
            }
            else if (player.altFunctionUse == 0 && ArmoredEnergyBar.blasterCharge >= 1)
            {
                Projectile.NewProjectileDirect(Entity.GetSource_FromThis(), position, velocity, ProjectileID.ChlorophyteBullet, damage, knockback, player.whoAmI);
                SoundEngine.PlaySound(SoundID.Item33);
            }
            return false;
        }
    }
}