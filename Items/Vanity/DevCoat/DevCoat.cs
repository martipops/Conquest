using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Conquest;
using Mono.Cecil;
using System.Security.Cryptography.X509Certificates;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Physics;
using static Humanizer.In;
using static Terraria.ModLoader.PlayerDrawLayer;
using Terraria.ModLoader.IO;

namespace Conquest.Items.Vanity.DevCoat
{
	public class DevContainer : ModItem
	{
		public override void SetDefaults() {
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.width = 32;
			Item.height = 24;
			Item.rare = ItemRarityID.Pink;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void RightClick(Player player){
			player.QuickSpawnItem(null,ModContent.ItemType<DevCowl>());
			player.QuickSpawnItem(null,ModContent.ItemType<DevCoat>());
			player.QuickSpawnItem(null,ModContent.ItemType<DevKilt>());
		}
	}
	[AutoloadEquip(EquipType.Head)]
	public class DevCowl : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 22;
			Item.vanity = true;
			Item.value = 0;
			Item.rare = ItemRarityID.Pink;
		}
	}
	[AutoloadEquip(EquipType.Body)]
	public class DevCoat : ModItem
	{
		public override void SetDefaults() {
			Item.width = 36;
			Item.height = 24;
			Item.vanity = true;
			Item.value = 0;
			Item.rare = ItemRarityID.Pink;
		}
	}
	[AutoloadEquip(EquipType.Legs)]
	public class DevKilt : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 14;
			Item.vanity = true;
			Item.value = 0;
			Item.rare = ItemRarityID.Pink;
		}
	}
}