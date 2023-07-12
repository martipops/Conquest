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
    [AutoloadEquip(EquipType.Head)]
    public class OnionKnightHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = 5;
            Item.defense = 12;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<OnionKnightArmor>() && legs.type == ModContent.ItemType<OnionKnightLeggings>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.SoulofMight, 4)
           .AddIngredient(ItemID.HallowedBar, 6)
           .AddTile(TileID.MythrilAnvil)
           .Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.6f;
            player.GetCritChance(DamageClass.Melee) += 6f;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Enemies are more likely to target you\n+20% Melee Crit Chance"; // This is the setbonus tooltip
            player.GetCritChance(DamageClass.Melee) += 20;
            player.aggro += 400;
            player.buffImmune[BuffID.OnFire] = true;
        }
    }
}
