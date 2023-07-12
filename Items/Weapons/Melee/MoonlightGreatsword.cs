using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Conquest.Projectiles.Melee;
using Conquest.Buffs;
using Conquest.Items.Materials;

namespace Conquest.Items.Weapons.Melee
{
    public class MoonlightGreatsword : ModItem
    {

        public override void SetStaticDefaults()
        {

            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = 10;

            Item.width = 68;
            Item.height = 68;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 35;
            Item.useTime = 35;
            Item.noUseGraphic = true;
            //Item.UseSound = SoundID.Item1;
            Item.noMelee = true;
            Item.autoReuse = true;

            //   Item.channel = true;
            Item.value = Item.sellPrice(platinum: 1);
            Item.noMelee = true;
            // Weapon Properties
            Item.damage = 2100;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<ML>();
            Item.shootSpeed = 5f;

        }
        
        public int attackType = 0; 
        public int comboExpireTimer = 0; 
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Using the shoot function, we override the swing projectile to set ai[0] (which attack it is)
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, attackType);
            if (player.HasBuff<MoonlightBlessing>())
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<MoonlightSlash>(), damage, knockback, Main.myPlayer, attackType);
            }
            else if (!player.HasBuff<MoonlightBlessing>())
            {
            }
            attackType = 0;


            comboExpireTimer = 0; // Every time the weapon is used, we reset this so the combo does not expire
            return false; // return false to prevent original projectile from being shot
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
