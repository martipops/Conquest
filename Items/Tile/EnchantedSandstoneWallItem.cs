using Conquest.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;



namespace Conquest.Items.Tile
{
    public class EnchantedSandstoneWallItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<EnchantedSandstoneWall>(); // The ID of the wall that this item should place when used. ModContent.WallType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets).

        }
    }
}
