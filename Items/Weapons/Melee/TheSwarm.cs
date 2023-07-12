using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
    public class TheSwarm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("On hit, has a chance to release bees");
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 24;
            Item.height = 24;
            Item.rare = 10;
            Item.value = Item.sellPrice(gold: 2);
            // Use Properties
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            // Weapon Properties
            Item.damage = 99;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<SwarmYoyo>();

        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.FragmentSolar, 11)
            .AddIngredient(ItemID.BeeWax, 15)
            .AddIngredient(ItemID.WoodYoyo, 1)
           .AddTile(TileID.LunarCraftingStation)
           .Register();
        }
    }
}
