
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;

namespace Conquest.Items.Accessory
{
    public class Amalgam : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Reduces damage taken by 17%\nHas a chance to create illusions and dodge an attack\nTemporarily increase critical chance after dodge\nMay confuse nearby enemies after being struck");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Expert;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.master = true;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 12));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.brainOfConfusionItem = Item;
            player.endurance += 0.17f;

        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.WormScarf, 1)
           .AddIngredient(ItemID.BrainOfConfusion, 1)
           .AddTile(TileID.DemonAltar)
           .Register();


        }
    }
}
