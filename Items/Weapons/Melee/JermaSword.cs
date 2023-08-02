using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;
using Conquest.Assets.Common;

namespace Conquest.Items.Weapons.Melee
{
	public class JermaSword : ModItem
	{
		uint hSCool = 0;
		public override void SetStaticDefaults()
		{
			//Item.staff[Type] = true;
		}
		public override void SetDefaults()
		{
			Item.damage = 344;
			Item.DamageType = DamageClass.Melee;
			Item.width = 22;
			Item.height = 22;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = 3;
			Item.knockBack = 3;
			Item.value = 800000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void UpdateInventory (Player player)
		{
			/*
			if (hSCool > 0)
			{
				hSCool--;
				player.GetModPlayer<MyPlayer>().ScreenShake = Math.Max(hSCool/2,player.GetModPlayer<MyPlayer>().ScreenShake);
			}
			*/
		}
		public override void ModifyHitNPC (Player player, NPC target, ref NPC.HitModifiers modifiers)
		{
			/*
			if (hSCool == 0)
			{
				modifiers.SetCrit();
				var n = 150;
				var i = DateTime.Now.Millisecond;
				while (n > 0)
				{
					if (DateTime.Now.Millisecond != i)
					{
						i = DateTime.Now.Millisecond;
						n--;
					}
				}
				hSCool = 5;
			}
			*/
		}
	}
}