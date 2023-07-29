using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Conquest.Projectiles.Melee;
using System.Threading;

namespace Conquest.Items.Weapons.Melee
{
    internal class GracefulDahlia : ModItem
    {
        public int attackType = 0; // keeps track of which attack it is
        public int comboExpireTimer = 0; // we want the attack pattern to reset if the weapon is not used for certain period of time

        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 48;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Green;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4;  
            Item.autoReuse = true;
            Item.damage = 62;
            Item.DamageType = DamageClass.Melee; 
            Item.noMelee = true;  
            Item.noUseGraphic = true; 
            Item.shoot = ModContent.ProjectileType<GracefulDahliaProj>(); 
        }

        int timer;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            timer++;
            if(timer <= 2)
            {
                attackType = 0;
            }
            if(timer >= 3)
            {
                attackType = 1;
                timer = 0;
            }
            comboExpireTimer = 0;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, attackType);

            return false; 
        }

        

        public override bool MeleePrefix()
        {
            return true; 
        }

    }
}
