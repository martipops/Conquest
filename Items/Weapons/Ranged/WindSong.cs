using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Terraria.DataStructures;
using Conquest.Projectiles.Ranged;

namespace Conquest.Items.Weapons.Ranged
{
    internal class WindSong : ModItem
    {
        public override void SetStaticDefaults()
        {

        }
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.knockBack = 3;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.width = 34;
            Item.height = 82;
            Item.UseSound = SoundID.Item5;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noUseGraphic = false;
            Item.noMelee = true;

            Item.rare = ItemRarityID.Orange;

            Item.value = 75000;

            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = Item.useAmmo;
            Item.shootSpeed = 15;

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 newVelocity1 = velocity.RotatedByRandom(MathHelper.ToRadians(30));
            Vector2 newVelocity2 = velocity.RotatedByRandom(MathHelper.ToRadians(30));

            if (Main.rand.NextBool())
            {
                Projectile.NewProjectileDirect(source, position, newVelocity1, ModContent.ProjectileType<WindArrow>(), damage / 2, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, newVelocity2, ModContent.ProjectileType<WindArrow>(), damage / 2, knockback, player.whoAmI);
            }

            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}
