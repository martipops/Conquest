using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Conquest.Projectiles.Ranged;

namespace Conquest.Items.Weapons.Ranged
{
    public class OccularRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // DisplayName.SetDefault("Occular Repeater");
            // Tooltip.SetDefault("Converts wooden arrows to eye balls which stop moving after a short time and bounce off of enemies");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 1;
            Item.value = Item.buyPrice(silver: 1);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 14;
            Item.knockBack = 1f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
        }


        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<EyeProj>();
            }
        }
    }
}
