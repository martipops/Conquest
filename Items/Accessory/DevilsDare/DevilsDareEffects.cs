using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using System.IO;

namespace Conquest.Items.Accessory.DevilsDare
{
	public class DevilsDareEffectsNPC : GlobalNPC
	{
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetModPlayer<DevilsDareEffects>().DevilsBuff)
            {
                spawnRate = (int)(spawnRate * 0.0);
                //maxSpawns = (int)(maxSpawns * 1000000);
            }
        }
	}
	internal class DevilsDareEffects : ModPlayer
	{
		SoundStyle DevilHurt = new SoundStyle($"{nameof(Conquest)}/Items/Accessory/DevilsDare/Devils_Dare_Pain")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 3,
        };
		SoundStyle DevilDeath = new SoundStyle($"{nameof(Conquest)}/Items/Accessory/DevilsDare/Devils_Death")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 3,
        };
		internal bool DevilsBuff;
		internal bool DevilsVisuals;
		public override void ResetEffects() {
			DevilsBuff = false;
			DevilsVisuals = false;
		}
		
		public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
			if (DevilsBuff)
			{
			
				Player player = Main.LocalPlayer;
				if (DevilsVisuals)
					SoundEngine.PlaySound(DevilDeath, player.position);
			}
		}
		public override void PostHurt(Player.HurtInfo info)
		{
			Player player = Main.LocalPlayer;
			if (DevilsVisuals)
			{
				SoundEngine.PlaySound(DevilHurt, player.position);
			}
		}
		public override void OnHurt(Player.HurtInfo info)
		{
            if (DevilsBuff)
			{
                Player.KillMe(PlayerDeathReason.ByCustomReason("bruh"), 666, 0);
            }

        }
		public override void ModifyHurt(ref Player.HurtModifiers modifiers) {
			if (DevilsBuff)
			{
				//modifiers.DisableSound();
				modifiers.SetMaxDamage(1);
				if (DevilsVisuals)
					modifiers.DisableSound();
				Player player = Main.LocalPlayer;
				
			}
		}
	}
}