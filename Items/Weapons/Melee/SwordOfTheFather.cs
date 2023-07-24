using Conquest.Projectiles.Melee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Conquest.Buffs;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Conquest.Items.Weapons.Melee
{
    public class SwordOfTheFather : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 74;
            Item.height = 70;
  
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.Item1;
            Item.reuseDelay = 0;

            Item.autoReuse = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 5);
            Item.damage = 76;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            Item.shootSpeed = 5f;
            Item.shoot = ModContent.ProjectileType<SOFT>();
        }

        public override void UpdateInventory(Player player)
        {
            {
                player.AddBuff(ModContent.BuffType<Empowered>(), 60, true, false);

            }  
        }

       
    



        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.
            if (player.HasBuff<MoonlightBlessing>())
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<MoonlightSlash>(), damage, knockback, player.whoAmI);
            }
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}
