using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Items.Armor.Melee
{
    [AutoloadEquip(EquipType.Body)]
    public class OnionKnightArmor : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = 5; // The rarity of the item
            Item.defense = 24;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.SoulofMight, 10)
           .AddIngredient(ItemID.HallowedBar, 12)
           .AddTile(TileID.MythrilAnvil)
           .Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.10f;
        }
    }
}
