using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
	public class ChainChomp : ModItem
	{
		public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }
		SoundStyle SwingBark = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/Swing_Bark")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 3,
        };
		public override void SetDefaults()
        {
			Item.width = 30;
            Item.height = 30;
            Item.value = 10000;
            Item.noMelee = true;
            Item.rare = 6;
            Item.useTime = 15;
            Item.useAnimation = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.damage = 120;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            Item.shootSpeed = 15.1f;
            Item.shoot = ModContent.ProjectileType<ChainChompFace>();
			Item.channel = true;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            SoundEngine.PlaySound(SwingBark, player.position);
            return true;
        }
	}
}