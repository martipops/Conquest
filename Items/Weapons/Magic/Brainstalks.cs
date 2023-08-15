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
            Item.damage = 13;
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
            float angle = Main.rand.NextFloat(MathF.PI * 2);
            for (int i = 0; i < 5; i++)
            {
                NPC target = null;
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && !npc.dontTakeDamage && npc.Distance(Main.MouseWorld) < 60)
                    {
                        target = npc;
                        break;
                    }
                }
                Vector2 spawnPosition = Main.MouseWorld + new Vector2(400, 0).RotatedBy(angle);
                for (int j = 0; j < 16; j++)
                {
                    Dust.NewDustDirect(Vector2.Lerp(position, spawnPosition, Main.rand.NextFloat()), 1, 1,
                                                    DustID.LifeDrain).noGravity = true;
                }
                Vector2 spawnVelocity = spawnPosition.DirectionTo(Main.MouseWorld) * velocity.Length();
                if (target != null) spawnVelocity += target.velocity;
                Projectile.NewProjectileDirect(source, spawnPosition, spawnVelocity, type, damage, knockback, player.whoAmI);
                angle += MathHelper.ToRadians(72);
            }
            return false;
        }
    }
}
