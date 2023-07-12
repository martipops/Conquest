
using Conquest.Assets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Accessory
{
    public class Bumbullets : ModItem
    {

        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Bumblecore\nShooting occasionally spawns additional bees.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().Bees = true;

        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.BeeWax, 12)
            .AddIngredient(ItemID.MusketBall, 100)
            .AddTile(TileID.Anvils)
            .Register();
        }

    }
}