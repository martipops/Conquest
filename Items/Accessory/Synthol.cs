
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
    public class Synthol : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Melee Speed\n+10% Melee Crit Chance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
            player.GetCritChance(DamageClass.Melee) += 10f;

        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Steroids>(), 1)
           .AddIngredient(ItemID.PixieDust, 5)
            .AddIngredient(ItemID.UnicornHorn, 5)

           .AddTile(TileID.MythrilAnvil)
           .Register();


        }
    }
}
