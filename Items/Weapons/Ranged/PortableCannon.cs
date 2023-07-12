using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Conquest.Projectiles.Ranged;
using Conquest.Items.Weapons.Magic;

namespace Conquest.Items.Weapons.Ranged
{
    internal class PortableCannon : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 77;
            Item.knockBack = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.width = 74;
            Item.height = 22;
            Item.UseSound = SoundID.Item36;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noUseGraphic = false;
            Item.noMelee = true;

            Item.rare = ItemRarityID.Orange;

            Item.value = 100000;

            Item.useAmmo = AmmoID.Dart;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10;

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<SeedCannonball>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                      .AddIngredient(ModContent.ItemType<BombingStaff>())
                      .AddIngredient(ItemID.DartRifle)
                      .AddIngredient(ItemID.HallowedBar, 6)
                      .AddTile(TileID.MythrilAnvil)
                      .Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
    }
}
