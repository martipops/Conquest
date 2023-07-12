using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
    public class EternalFlames : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("Inflicts on fire on hit, projectiles home towards enemies");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.buyPrice(gold: 1);
            Item.noMelee = true;
            // Use Properties
            Item.rare = 4;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            // Weapon Properties
            Item.damage = 60;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shootSpeed = 10f;
            Item.shoot = ModContent.ProjectileType<EternalFlamesProj>();
        }


        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 2;
        }
    }
}
