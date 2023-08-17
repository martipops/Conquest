using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Conquest.Projectiles.Ranged;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace Conquest.Items.Weapons.Ranged
{
    public class GloriousLauncher : ModItem
    {
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 4;
            Item.value = Item.buyPrice(silver: 12);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item36;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 24;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<AntlionRocket>();
            Item.shootSpeed = 18f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, -4);
        }
      
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
    }
}
