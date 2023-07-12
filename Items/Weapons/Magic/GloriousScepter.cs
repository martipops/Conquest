using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Conquest.Projectiles.Magic;

namespace Conquest.Items.Weapons.Magic
{
    public class GloriousScepter : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.sellPrice(gold: 3);
            Item.noMelee = true;
            Item.rare = 4;
            // Use Properties
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 20;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 20;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<ScepterProjectile>();
            Item.shootSpeed = 0f;
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectileDirect(source, Main.MouseWorld, velocity, type, damage, knockback, player.whoAmI);
            return false;

        }
    }
}
