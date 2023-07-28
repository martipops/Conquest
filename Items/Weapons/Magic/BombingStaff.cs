using Conquest.Projectiles.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Weapons.Magic
{
    public class BombingStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 190;
            Item.knockBack = 5;
            Item.mana = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 100;
            Item.useAnimation = 100;
            Item.width = 32;
            Item.height = 34;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = false;
            Item.noUseGraphic = false;
            Item.noMelee = true;
            Item.crit = 20;
            Item.rare = ItemRarityID.Orange;

            Item.value = 100000;

            Item.shoot = ModContent.ProjectileType<BombStaffProj>();
            Item.shootSpeed = 0;

        }
    }
}
