using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Conquest.Projectiles.Magic;
using Conquest.Buffs;
using Mono.Cecil;

namespace Conquest.Items.Weapons.Magic
{
    // changed by Goose
    // now fires a stream of 0's and 1's that lags targets
    // using with Mana Sickness may lag the player
	public class CRTGun	: ModItem
	{
		SoundStyle RetroBlast = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/Retro_Blast")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 3,
        };
		public override void SetDefaults()
        {
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 3));
			Item.width = 26; 
            Item.height = 22;
            Item.value = 1000;
            Item.noMelee = true;
            Item.rare = 6;
            Item.mana = 15;
            Item.useTime = 5;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.damage = 3;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
			Item.shoot = ModContent.ProjectileType<CRTBlast>();
			Item.shootSpeed = 16;
			Item.autoReuse = true;

            Item.UseSound = RetroBlast;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            for (int i = 0; i < 3; i++)
            {
                Projectile.NewProjectileDirect(player.GetSource_ItemUse(player.HeldItem),
                    position + Main.rand.NextVector2Circular(8, 8), velocity.RotatedByRandom(MathHelper.ToRadians(5)),
                    type, damage, 0, player.whoAmI);
            }
            if (player.HasBuff(BuffID.ManaSickness) && Main.rand.NextBool(10))
            {
                player.AddBuff(ModContent.BuffType<Lag>(), 60);
            }
        }
    }
}