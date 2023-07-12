using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Conquest.Items.Materials;

namespace Conquest.Items.Weapons.Melee
{
    public class SoulBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 64;
            Item.height = 64;
            Item.rare = 1;
            Item.value = Item.sellPrice(silver: 1);
            Item.noMelee = false;
            // Use Properties
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 38;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties

        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ModContent.ItemType<SoulPiece>(), 7)
           .AddIngredient(ItemID.TissueSample, 7)
           .AddTile(TileID.Anvils)
           .Register();

            CreateRecipe()
           .AddIngredient(ModContent.ItemType<SoulPiece>(), 7)
           .AddIngredient(ItemID.ShadowScale, 7)
           .AddTile(TileID.Anvils)
           .Register();
        }
    }
}
