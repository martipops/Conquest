using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Terraria.DataStructures;
using Conquest.Buffs;
using Conquest.Projectiles.Summoner;

namespace Conquest.Items.Weapons.Summon
{
    internal class RatInterphone : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("对讲机");
            // Tooltip.SetDefault("召唤舒克来为你战斗");
        }

        public override void SetDefaults()
        {
            Item.damage = 320;
            Item.knockBack = 1;
            Item.mana = 10;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.width = 20;
            Item.height = 38;
            Item.UseSound = SoundID.ResearchComplete;
            Item.DamageType = DamageClass.Summon;
            Item.autoReuse = false;
            Item.noUseGraphic = false;
            Item.noMelee = true;

            Item.rare = ItemRarityID.Green;

            Item.value = 75000;

            Item.shoot = ModContent.ProjectileType<Shook>();
            Item.shootSpeed = 1;
            Item.buffType = ModContent.BuffType<ShookBuff>();

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);

            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            projectile.originalDamage = Item.damage;

            return false;
        }
    }
}
