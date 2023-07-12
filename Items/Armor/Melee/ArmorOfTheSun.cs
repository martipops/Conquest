using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Armor.Melee
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Body)]
    public class ArmorOfTheSun : ModItem
    {
        public override void SetStaticDefaults()
        {

            // DisplayName.SetDefault("Armor of the Sun");
            // Tooltip.SetDefault("Armor of Solaire of Astora, Knight of Sunlight\n+10% Melee Crit Chance");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 8; // The amount of defense the item will give when equipped
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.IronChainmail, 1)
           .AddIngredient(ItemID.HellstoneBar, 20)
           .AddTile(TileID.Anvils)
           .Register();

            CreateRecipe()
           .AddIngredient(ItemID.LeadChainmail, 1)
           .AddIngredient(ItemID.HellstoneBar, 20)
           .AddTile(TileID.Anvils)
           .Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 10;
        }
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

    }
}