using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Conquest.Assets.GUI.HollowKnight;
using Conquest.Buffs;
using Conquest.Projectiles.Melee;

namespace Conquest.Items.Weapons.Melee
{
    public class OldNail : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("While holding activates the soul gauge\nSpecial actions can be performed when the soul gauge is filled up\nWhen the Soul Gauge is filled, you can peform a dash towards your cursor with right click\nOn hit adds 3 charge\nOn kill adds 10 charge\n");
        }
        public override void SetDefaults()
        {
            
            // Common Properties
            Item.rare = ItemRarityID.Pink;
            Item.width = 60;
            Item.height = 60;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.noMelee = true;
            Item.autoReuse = true;
            // Use Properties
            Item.useStyle = 1;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.Item1;
            Item.value = Item.buyPrice(gold: 40);
            // Weapon Properties
            Item.damage = 90;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ProjectileID.None;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<NailProj>();

            Item.shootSpeed = 4f;
        }
        public override bool AltFunctionUse(Player player)
        {
            var HollowGauge = player.GetModPlayer<HollowGauge>();
            if (HollowGauge.HollowGaugeResourceCurrent != 100)
            {
                return false;
            }
            else
            return true;
        }
        public override void UseAnimation(Player player)
        {
            var HollowGauge = player.GetModPlayer<HollowGauge>();
            int T = ModContent.BuffType<Immune>();
            if (player.altFunctionUse == 2 && HollowGauge.HollowGaugeResourceCurrent == 100)
            {
                Item.damage = 180;
                Item.useAnimation = 50;
                Item.useTime = 50;
                Item.shoot = ModContent.ProjectileType<NailProj2>();
                HollowGauge.HollowGaugeResourceCurrent = 0;
                player.velocity = player.DirectionTo(Main.MouseWorld) * 14;
                player.SetImmuneTimeForAllTypes(30);
            }
            else
            {
                Item.damage = 90;
                Item.useAnimation = 50;
                Item.useTime = 50;
                Item.shoot = ModContent.ProjectileType<NailProj>();
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            var HollowGauge = player.GetModPlayer<HollowGauge>();
            float launchSpeed = 36f;
            Vector2 mousePosition = Main.MouseWorld;
            Vector2 direction = Vector2.Normalize(mousePosition - player.Center);
            Vector2 arrowVelocity = direction * launchSpeed;
           
            
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem), player.MountedCenter.X, player.MountedCenter.Y, arrowVelocity.X, arrowVelocity.Y, ModContent.ProjectileType<NailProj2>(), player.GetWeaponDamage(Item), 3, player.whoAmI, 0f);
                player.velocity = player.DirectionTo(Main.MouseWorld) * 14;
                for (int i = 0; i < 50; i++)
                {
                    Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                    Dust d = Dust.NewDustPerfect(player.Center, DustID.WhiteTorch, speed * 10, Scale: 1.5f);
                    d.noGravity = true;
                }

                HollowGauge.HollowGaugeResourceCurrent = 0;
                
            }
            else
            {
                Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem), player.MountedCenter.X, player.MountedCenter.Y, arrowVelocity.X, arrowVelocity.Y, ModContent.ProjectileType<NailProj>(), player.GetWeaponDamage(Item), 3, player.whoAmI, 0f);

            }

            return false;

        }

    }
}









