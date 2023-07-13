using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

namespace Conquest.Items.Consumable
{
    public class CharcoalPineResin : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // DisplayName.SetDefault("Charcoal Pine Resin");
            // Tooltip.SetDefault("Black charcoal-like pine resin.\nApplies fire to your melee weapons.");
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 99;
            Item.rare = 1;
            Item.scale = 0.8f;
            Item.UseSound = SoundID.Item20;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.value = 250;
            Item.consumable = true;
            Item.buffType = BuffID.WeaponImbueFire;
            Item.buffTime = 7200;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.Wood, 25)
            .AddIngredient(ItemID.Obsidian, 5)
            .AddCondition(Condition.NearLava)
            .Register();
        }




    }
}
