using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Conquest.Items.Weapons.Melee
{
    public class Pencil : ModItem
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
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 15;
            Item.knockBack = 6f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
           
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                      .AddIngredient(ItemID.Wood, 20)
                      .AddIngredient(RecipeGroupID.IronBar, 10)
                      .AddTile(TileID.WorkBenches)
                      .Register();
        }   
       
    }
}
