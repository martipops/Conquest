using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Conquest.Projectiles.Magic;

namespace Conquest.Items.Weapons.Magic
{
    public class AnubisStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("Projectiles fire at your cursor, Critical hits heal you");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.sellPrice(silver: 1);
            Item.noMelee = true;
            Item.rare = 6;
            // Use Properties
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 30;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 9;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<AnubisStaffProj1>();
            Item.shootSpeed = 12f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            position = player.Center + new Vector2(0, Main.screenHeight * 0.6f);
            for (int i = 0; i < 5; i++)
            {
                Vector2 perturbedPos = position + new Vector2(player.direction * i * 40, 0) + Main.rand.NextVector2Circular(50, 50);
                Vector2 perturbedVel = perturbedPos.DirectionTo(Main.MouseWorld + Main.rand.NextVector2Circular(100, 100))
                    * velocity.Length() * Main.rand.NextFloat(0.85f, 1.5f);
                Projectile.NewProjectileDirect(source, perturbedPos, perturbedVel, type, damage, knockback, player.whoAmI);
            }

            return false;
        }
    }
}
