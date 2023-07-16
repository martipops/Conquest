
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
    public class LightningBlade : ModItem
    {
      
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Fires a lightning bolt on impact with an enemy or a tile, spreads electricty to all surrounding enemies");
        }

        public override void SetDefaults()
        {

            // Common Properties
            Item.width = 60;
            Item.height = 60;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(silver: 12);
            // Weapon Properties
            Item.damage = 41;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<TestLightning>();
            Item.shootSpeed = 12f;
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
           .AddIngredient(ItemID.GoldBroadsword, 1)
          .AddIngredient(ModContent.ItemType<JellyfishTentacle>(), 3)
           .AddTile(TileID.MythrilAnvil)
           .Register();


        }
    }

}
