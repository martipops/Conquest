using Conquest.Assets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Accessory
{
    public class SilverBullets : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Silver Rounds");
            // Tooltip.SetDefault("+50% damage against bosses, -50% against everything else... unless your a vampire");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 3;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().SilverBullets = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.SilverBar, 12)
            .AddIngredient(ItemID.Bone, 10)
            .AddIngredient(ItemID.MusketBall, 100)
            .AddTile(TileID.Anvils)
            .Register();

            CreateRecipe()
          .AddIngredient(ItemID.TungstenBar, 12)
          .AddIngredient(ItemID.Bone, 10)
          .AddIngredient(ItemID.MusketBall, 100)
          .AddTile(TileID.Anvils)
          .Register();
        }
    }
}
