
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
    public class Petal : ModItem
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
            Item.maxStack = 6;
            // Weapon Properties
            Item.damage = 45;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shootSpeed = 15f;
            Item.shoot = ModContent.ProjectileType<PetalBoomerang>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if(Item.stack == 1)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<PetalBoomerang>(), damage, knockback, Main.myPlayer);
            }
            if (Item.stack == 2)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<PetalBoomerang2>(), damage, knockback, Main.myPlayer);
            }
            if (Item.stack == 3)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<PetalBoomerang3>(), damage, knockback, Main.myPlayer);
            }
            if (Item.stack == 4)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<PetalBoomerang4>(), damage, knockback, Main.myPlayer);

            }
            if (Item.stack == 5)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<PetalBoomerang5>(), damage, knockback, Main.myPlayer);

            }
            if (Item.stack == 6)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<PetalBoomerang6>(), damage, knockback, Main.myPlayer);

            }
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

    }
}
