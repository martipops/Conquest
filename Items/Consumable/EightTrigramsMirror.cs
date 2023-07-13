using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Conquest.Assets.GUI;

namespace Conquest.Items.Consumable
{
    internal class EightTrigramsMirror : ModItem
    {
       
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.useAnimation = 30;
            Item.value = 0;
            Item.rare = -11;
            Item.maxStack = 1;

        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2 && player.whoAmI == Main.myPlayer)
            {
                EightTrigrams.tLoad = 0;
                T1.p1On = false;
                T1.p2On = false;
                T1.p3On = false;
                T1.p4On = false;
                T1.p5On = false;
                T1.p6On = false;
                T1.p7On = false;


                T8.p11On = false;
                T8.p12On = false;
                T8.p13On = false;
                T8.p14On = false;
                T8.p15On = false;
                T8.p16On = false;
                T8.p17On = false;

                T3.p21On = false;
                T3.p22On = false;
                T3.p23On = false;
                T3.p24On = false;
                T3.p25On = false;
                T3.p26On = false;
                T3.p27On = false;

                T6.p31On = false;
                T6.p32On = false;
                T6.p33On = false;
                T6.p34On = false;
                T6.p35On = false;
                T6.p36On = false;
                T6.p37On = false;

            }
            else if (player.altFunctionUse == 0 && player.whoAmI == Main.myPlayer)
            {
                EightTrigrams.vsb = true;
            }
            return base.CanUseItem(player);
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.MagicMirror, 1)
                .AddIngredient(ItemID.CopperBar, 8)
                .AddTile(TileID.DemonAltar)
                .Register();

            CreateRecipe(1)
                .AddIngredient(ItemID.MagicMirror, 1)
                .AddIngredient(ItemID.TinBar, 8)
                .AddTile(TileID.DemonAltar)
                .Register();


        }
    }
}
