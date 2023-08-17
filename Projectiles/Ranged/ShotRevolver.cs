using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Conquest.Projectiles.Ranged;

namespace Conquest.Items.Weapons.Ranged
{
    public class ShotRevolver : ModItem
    {
        int timer;
        bool bang;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cowboy Slinger");
            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 1;
            Item.value = Item.buyPrice(gold: 15);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            // Weapon Properties
            Item.damage = 19;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<CowboyGun2>();
            Item.shootSpeed = 10f;
        }





    }
}
