using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Conquest.Projectiles.Magic;

namespace Conquest.Items.Weapons.Magic
{
    public class Brainstalks : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.sellPrice(gold: 1);
            Item.noMelee = true;
            Item.rare = ItemRarityID.Green;

            // Use Properties
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.NPCHit13;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 32;
            Item.crit = 4;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Brain>();
            Item.shootSpeed = 15f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 playerPos = player.RotatedRelativePoint(player.MountedCenter, true);
            float speed = Item.shootSpeed;
            float xPos = Main.mouseX + Main.screenPosition.X - playerPos.X;
            float yPos = Main.mouseY + Main.screenPosition.Y - playerPos.Y;
            float f = Main.rand.NextFloat() * ((float)Math.PI * 2f);
            float sourceVariationLow = 20f;
            float sourceVariationHigh = 60f;
            Vector2 source1 = playerPos + f.ToRotationVector2() * MathHelper.Lerp(sourceVariationLow, sourceVariationHigh, Main.rand.NextFloat());
            for (int i = 0; i < 50; i++)
            {
                source1 = playerPos + f.ToRotationVector2() * MathHelper.Lerp(sourceVariationLow, sourceVariationHigh, Main.rand.NextFloat());
                if (Collision.CanHit(playerPos, 0, 0, source1 + (source1 - playerPos).SafeNormalize(Vector2.UnitX) * 8f, 0, 0))
                {
                    break;
                }
                f = Main.rand.NextFloat() * ((float)Math.PI * 2f);
            }
            Vector2 newvelocity = Main.MouseWorld - source1;
            Vector2 velocityVariation = new Vector2(xPos, yPos).SafeNormalize(Vector2.UnitY) * speed;
            newvelocity = newvelocity.SafeNormalize(velocityVariation) * speed;
            newvelocity = Vector2.Lerp(newvelocity, velocityVariation, 0.25f);
            int Proj = Projectile.NewProjectile(source, source1, newvelocity, type, damage, knockback, player.whoAmI, 0f, Main.rand.Next(3));
            Projectile obj = Main.projectile[Proj];
            for (int i = 0; i < 100; i++)
            {
                Vector2 outerdustring = Main.rand.NextVector2CircularEdge(0.2f, 0.2f);
                Dust Dusty = Dust.NewDustPerfect(obj.position, DustID.Firework_Red, outerdustring * 5, Scale: 0.5f);
                Dusty.noGravity = true;
            }

            return false;
        }
    }
}
