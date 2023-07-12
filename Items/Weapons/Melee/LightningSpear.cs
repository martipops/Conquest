
using Conquest.Items.Materials;
using Conquest.Projectiles.Melee;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Weapons.Melee
{
    public class LightningSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
            ItemID.Sets.Spears[Item.type] = true; // This allows the game to recognize our new item as a spear.
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // Tooltip.SetDefault("On hitting an enemy, fire lightning to nearby enemies");
        }
        public override void SetDefaults()
        {

            // Common Properties
            Item.width = 60;
            Item.height = 60;
            Item.noUseGraphic = true; // When true, the item's sprite will not be visible while the item is in use. This is true because the spear projectile is what's shown so we do not want to show the spear sprite as well.
            Item.noMelee = true;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 50; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useTime = 50;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(silver: 12);
            // Weapon Properties
            Item.damage = 30;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<ThunderSpear>();
            Item.shootSpeed = 3.7f;
            // Projectile Properties
        }
        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        public override bool? UseItem(Player player)
        {
            // Because we're skipping sound playback on use animation start, we have to play it ourselves whenever the item is actually used.
            if (!Main.dedServ && Item.UseSound.HasValue)
            {
                SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
            }

            return null;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.Trident, 1)
          .AddIngredient(ModContent.ItemType<JellyfishTentacle>(), 3)
           .AddTile(TileID.MythrilAnvil)
           .Register();


        }
    }
}
