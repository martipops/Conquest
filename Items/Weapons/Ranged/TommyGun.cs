using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Conquest.Items.Weapons.Ranged
{
    public class TommyGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tommy Gun");
            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 1;
            Item.value = Item.buyPrice(gold: 75);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 10;
            Item.crit = 3;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-14, 0);
        }

    }
}