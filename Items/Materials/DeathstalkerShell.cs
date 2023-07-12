using Terraria.Net;
using Terraria.GameContent.NetModules;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Conquest.Items.Materials
{
    public class DeathstalkerShell : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("A piece of the deathstalker");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;

            Item.maxStack = 999;
            Item.value = Item.buyPrice(silver: 1); // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
        }
    }
}
