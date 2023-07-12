using Conquest.Projectiles.Melee;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Items.Weapons.Melee
{
    public class CorruptedJoustingLance : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {

            Item.DefaultToSpear(ModContent.ProjectileType<CorruptedJoustingLanceProjectile>(), 1f, 24);

            Item.DamageType = DamageClass.MeleeNoSpeed; 

            Item.SetWeaponValues(25, 12f, 0); // A special method that sets the damage, knockback, and bonus critical strike chance.

            Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(silver: 60)); 

            Item.channel = true;

            Item.StopAnimationOnHurt = true;
            Item.rare = ItemRarityID.Green;
        }


        public override bool MeleePrefix()
        {
            return true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

    }
}
