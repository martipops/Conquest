using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.DataStructures;
using Terraria.GameContent;
using Conquest.Items.Vanity.DevCoat;

namespace Conquest.Items.Vanity.Spiderman
{
    public class ArachnoidLunchbox : ModItem
    {
        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 24;
            Item.rare = ItemRarityID.Pink;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(null, ModContent.ItemType<ArachnoidSuit>());
            player.QuickSpawnItem(null, ModContent.ItemType<ArachnoidMask>());
            player.QuickSpawnItem(null, ModContent.ItemType<ArachnoidPants>());
        }
    }
    [AutoloadEquip(EquipType.Head)]

	public class ArachnoidMask : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 22;
			Item.vanity = true;
			Item.value = 150000;
			Item.rare = ItemRarityID.Pink;
		}
	}
	[AutoloadEquip(EquipType.Body)]
	public class ArachnoidSuit : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 22;
			Item.vanity = true;
			Item.value = 150000;
			Item.rare = ItemRarityID.Pink;
		}
	}
	[AutoloadEquip(EquipType.Legs)]
	public class ArachnoidPants : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 22;
			Item.vanity = true;
			Item.value = 150000;
			Item.rare = ItemRarityID.Pink;
		}
	}
}