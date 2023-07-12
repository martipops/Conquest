
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
    public class MountainBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {

            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = 5;
            Item.width = 68;
            Item.height = 68;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 60;
            Item.useTime = 60;
            Item.noUseGraphic = true;
            //Item.UseSound = SoundID.Item1;
            Item.noMelee = true;
            Item.autoReuse = false;
            //   Item.channel = true;
            Item.value = Item.sellPrice(silver: 16);
            Item.noMelee = true;
            // Weapon Properties
            Item.damage = 77;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<MB>();
            Item.shootSpeed = 10f;

        }


        public int attackType = 0;
        public int comboExpireTimer = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, attackType);
            Vector2 newVelocity1 = velocity.RotatedByRandom(MathHelper.ToRadians(30));
            attackType = 0;
            comboExpireTimer = 0;
            if (Main.rand.NextBool(2))
            {
                Projectile.NewProjectileDirect(source, position, newVelocity1, ModContent.ProjectileType<MountainBreakerProj>(), damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}
