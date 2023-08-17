using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Conquest.Items.Weapons.Ranged
{
    public class Infinity : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("Doesn't Consume Ammo");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.buyPrice(gold: 10);
            Item.noMelee = true;
            Item.rare = ItemRarityID.Pink;
            // Use Properties
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;

            // Weapon Properties
            Item.damage = 21;
            Item.knockBack = 1f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 1f;
        }
        //public override void HoldItem(Player player) => player.phantasmTime = 12;
        public override bool? UseItem(Player player)
        {
            Item.useTime *= (int)(Item.useTime * 0.15);
            Item.useAnimation *= (int)(Item.useAnimation * 0.15);

            return base.UseItem(player);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

    }
}
