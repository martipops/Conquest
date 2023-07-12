using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Conquest.Assets.Common;

namespace Conquest.Items.Accessory
{
    public class HeartSynthesizer : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Heart Synthesizer");
            // Tooltip.SetDefault("Projectiles have a chance to spawn a heart");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 5, 0, 0);
            Item.rare = 1;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().HeartSynthesizer = true;
        }

    }
}
