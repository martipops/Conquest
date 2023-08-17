using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Conquest.Projectiles.Ranged;

namespace Conquest.Items.Weapons.Ranged
{
    public class TortoiseCannon : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 288;
            Item.knockBack = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 80;
            Item.useAnimation = 80;
            Item.width = 54;
            Item.height = 30;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Yellow;

            Item.value = 500000;

            Item.shoot = ModContent.ProjectileType<TortoiseCannonHold>();
            Item.shootSpeed = 25;

        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
               .AddIngredient(ItemID.RocketLauncher, 1)
               .AddIngredient(ItemID.PiranhaGun, 1)
               .AddIngredient(ItemID.TurtleShell, 5)
               .AddTile(TileID.MythrilAnvil)
               .Register();
        }
    }
}
