using Terraria;
using Terraria.Localization;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Conquest;
using System.Collections.Generic;
using Conquest;
using Mono.Cecil;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Physics;
using static Humanizer.In;
using static Terraria.ModLoader.PlayerDrawLayer;
using Terraria.ModLoader.IO;
using Terraria.UI.Chat;
using Conquest.Assets.Common;

namespace Conquest.Items.Accessory.DevilsDare
{
	[AutoloadEquip(EquipType.Face)]
	public class DevilsDare : ModItem
	{
        Effect GoldenFX;
        static void SetEffectParameters(Effect effect)
        {
            effect.Parameters["uTime"].SetValue((float)(Main.timeForVisualEffects * 0.032f));
        }
        static bool ShaderTooltip(DrawableTooltipLine line, Effect shader)
        {
            Vector2 textPos = new Vector2(line.X, line.Y);
            for (float i = 0; i < 1; i += 0.25f)
            {
                Vector2 borderOffset = (i * MathF.Tau).ToRotationVector2() * 2;
                ChatManager.DrawColorCodedString(Main.spriteBatch, line.Font, line.Text, textPos + borderOffset, Color.Black, line.Rotation, line.Origin, line.BaseScale);
            }
            SetEffectParameters(shader);
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, shader, Main.UIScaleMatrix);
            ChatManager.DrawColorCodedString(Main.spriteBatch, line.Font, line.Text, textPos, Color.Red, line.Rotation, line.Origin, line.BaseScale);
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.UIScaleMatrix);
            return false;
        }
        public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
        {
            if (GoldenFX == null)
                GoldenFX = ModContent.Request<Effect>("Conquest/Assets/Shaders/Gradient", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.UIScaleMatrix);
            if (line.Index == 0)
            {
                return ShaderTooltip(line, GoldenFX);
            }
            return true;
        }
        internal Color eyeColor = new Color(180, 12, 75);
		SoundStyle Equip = new SoundStyle($"{nameof(Conquest)}/Items/Accessory/DevilsDare/Devils_Dare")
        {
            Volume = 1.2f,
            PitchVariance = 0.2f,
            MaxInstances = 3,
        };
        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            return incomingItem.rare != ModContent.RarityType<ArtifactRarity>() || equippedItem.ModItem is not DevilsDare;

        }
        public override void PostUpdate() {
			Lighting.AddLight(Item.Center+(new Vector2(0,8)), (new Vector3(259,73,73)) * 0.005f * Main.essScale);
		}
		public override void SetDefaults() {
			Item.width = 25;
			Item.height = 23;
			Item.accessory = true;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			int devilsLife = player.statLifeMax/100;
			if (player.statLife > devilsLife)
			{
				if (!hideVisual)
					SoundEngine.PlaySound(Equip, player.position);
				player.statLife = devilsLife;
			}
			if ((player.ownedProjectileCounts[ModContent.ProjectileType<DevilsFlame>()] <= 0) && (!hideVisual))
			{
				var type = ModContent.ProjectileType<DevilsFlame>();
				var source = player.GetSource_FromThis();
				Projectile.NewProjectile(source, player.position, (new Vector2(0,0)), type, 0, 0, player.whoAmI);
			}
			player.GetDamage(DamageClass.Generic) *= 10;
			player.statLifeMax2 = devilsLife;
			player.aggro = 250;
			player.GetModPlayer<DevilsDareEffects>().DevilsBuff = true;
			if (!hideVisual) player.GetModPlayer<DevilsDareEffects>().DevilsVisuals = true;
			player.eyeColor = eyeColor*Main.essScale;
		}
	}
}