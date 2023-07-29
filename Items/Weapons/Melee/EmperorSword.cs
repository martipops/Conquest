using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.DataStructures;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
    public class EmperorSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.knockBack = 4f;
            Item.useStyle = ItemUseStyleID.Rapier; 
            Item.useAnimation = 21;
            Item.useTime = 7;
           // Item.reuseDelay = 14;
            Item.width = 32;
            Item.height = 32;
         //   Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = false;
            Item.noUseGraphic = true; 
            Item.noMelee = true; 

            Item.rare = 3;
            Item.value = Item.sellPrice(0, 0, 35, 0);

            Item.shoot = ModContent.ProjectileType<EmperorProj>(); // The projectile is what makes a shortsword work
            Item.shootSpeed = 2.1f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            SoundEngine.PlaySound(SoundID.Item1, player.position);
            return true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
        }
    }
}
