using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Materials
{
    internal class JellyfishTentacle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            // Tooltip.SetDefault("Shocking touch");


        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 22;
            Item.maxStack = 999;
            Item.rare = 4;
            Item.value = Item.sellPrice(silver: 3); // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
        }
    }
}
