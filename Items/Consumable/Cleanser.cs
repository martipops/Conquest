
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Conquest.Buffs;
using Conquest.Assets.Common;

namespace Conquest.Items.Consumable
{
    public class Cleanser : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cheat Accessory");
            // Tooltip.SetDefault("remove cooldowns");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 40, 0, 0);
            Item.rare = 4;

        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[ModContent.BuffType<ArmamentCooldown>()] = true;
            player.buffImmune[ModContent.BuffType<HunnySickness>()] = true;
            player.buffImmune[BuffID.PotionSickness] = true;
            player.GetModPlayer<MyPlayer>().DoubleJump = true;



        }
    }
}
