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
using Conquest.Projectiles.Ranged;

namespace Conquest.Items.Weapons.Ranged
{
    internal class DesertDandelion : ModItem
    {
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            Item.damage = 32;
            Item.knockBack = 5;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.width = 58;
            Item.height = 38;
            Item.UseSound = SoundID.Item11;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = false;
            Item.noUseGraphic = false;
            Item.noMelee = true;

            Item.rare = ItemRarityID.Orange;

            Item.value = 70000;

            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = Item.useAmmo;
            Item.shootSpeed = 20;

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<DandelionBullet>();
        }
    }
}
