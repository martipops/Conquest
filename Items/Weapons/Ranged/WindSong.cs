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
            Item.useTime = 3;
            Item.useAnimation = 3;
            Item.reuseDelay = 17;
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
            Item.shoot = ModContent.ProjectileType<WindArrow>();
            Item.shootSpeed = 48;

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<WindArrow>();
            float screenDiagonal = MathF.Sqrt((Main.screenWidth * Main.screenWidth) + (Main.screenHeight * Main.screenHeight));
            position += player.Center.DirectionFrom(Main.MouseWorld) * screenDiagonal * 0.6f;
            position += Main.rand.NextVector2Circular(100, 100);
            velocity = position.DirectionTo(Main.MouseWorld) * Item.shootSpeed * Main.rand.NextFloat(0.85f, 1.15f);

            for (int i = 0; i < 4; i++)
            {
                Vector2 perturbedPos = position + Main.rand.NextVector2Circular(100, 100);
                Vector2 perturbedVel = perturbedPos.DirectionTo(Main.MouseWorld) * Item.shootSpeed * Main.rand.NextFloat(0.85f, 1.15f);
                Projectile.NewProjectileDirect(player.GetSource_ItemUse(Item), perturbedPos, perturbedVel, type, damage / 2, 0, player.whoAmI);
            }
        }
    }
}
