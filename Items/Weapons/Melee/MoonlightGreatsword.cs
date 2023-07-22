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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            //   Item.channel = true;
            Item.value = Item.sellPrice(platinum: 1);
            // Weapon Properties
            Item.damage = 2100;
            Item.knockBack = 2f;
            Item.shootsEveryUse = true;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<ML>();
            Item.shootSpeed = 5f;

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.
            if (player.HasBuff<MoonlightBlessing>())
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<MoonlightSlash>(), damage, knockback, player.whoAmI);
            }
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
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
