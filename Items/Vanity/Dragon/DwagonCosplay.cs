using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.DataStructures;
using Terraria.GameContent;

namespace Conquest.Items.Vanity.Dragon
{
	[AutoloadEquip(EquipType.Head)]
	public class DwagonCosplayMask : ModItem
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
	public class DwagonCosplaySuit : ModItem
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
	public class DwagonCosplayPants : ModItem
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