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
using Conquest.Items.Materials;
using Conquest.Projectiles.Magic;

namespace Conquest.Items.Weapons.Magic
{
    internal class Wabbajack : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("瓦巴杰克");
            // Tooltip.SetDefault("造成随机效果\n有概率把目标变成甜卷\n\"瓦巴杰克？瓦巴杰克！瓦巴杰克瓦巴杰克瓦巴杰克...\"");
        }

        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.knockBack = 0;
            Item.mana = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.width = 76;
            Item.height = 76;
            Item.UseSound = SoundID.DD2_BetsyFireballShot;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;

            Item.rare = ItemRarityID.LightRed;

            Item.value = 100000;

            Item.shoot = ModContent.ProjectileType<WabbajackStaff>();
            Item.shootSpeed = 2;

        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ModContent.ItemType<ThankYou>(), 3)

           .AddTile(TileID.LunarCraftingStation)
           .Register();


        }
    }
}
