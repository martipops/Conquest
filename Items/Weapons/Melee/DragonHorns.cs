using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
    public class DragonHorns : ModItem
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
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            // Weapon Properties
            Item.damage = 50;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shootSpeed = 17f;
            Item.shoot = ModContent.ProjectileType<DragonHornsProj>();
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 5;
        }
    }
}
