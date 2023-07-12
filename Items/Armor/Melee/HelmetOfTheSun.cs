using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Armor.Melee
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class HelmetOfTheSun : ModItem
    {
        public override void SetStaticDefaults()
        {

            // DisplayName.SetDefault("Helmet of the Sun");
            // Tooltip.SetDefault("Helm of Solaire of Astora, Knight of Sunlight\n+4% Melee Damage");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 7; // The amount of defense the item will give when equipped
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ArmorOfTheSun>() && legs.type == ModContent.ItemType<BootsOfTheSun>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.IronHelmet, 1)
           .AddIngredient(ItemID.HellstoneBar, 15)
           .AddTile(TileID.Anvils)
           .Register();

            CreateRecipe()
           .AddIngredient(ItemID.LeadHelmet, 1)
           .AddIngredient(ItemID.HellstoneBar, 15)
           .AddTile(TileID.Anvils)
           .Register();

        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.04f;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Cannot be set on fire\n+15% Melee Damage"; // This is the setbonus tooltip
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.buffImmune[BuffID.OnFire] = true;
        }
    }
}