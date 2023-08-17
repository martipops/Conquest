using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Conquest.Projectiles.Ranged;

namespace Conquest.Items.Weapons.Ranged
{
    public class AnubisCannon : ModItem
    {
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 6;
            Item.value = Item.buyPrice(silver: 1);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item61;
            Item.autoReuse = true;

            // Weapon Properties
            Item.damage = 620;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<AnubisCannonProj>();
            Item.shootSpeed = 6f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
    }
}
