using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Conquest.Projectiles.Magic;

namespace Conquest.Items.Weapons.Magic
{
    public class SpaceBlaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("No mana cost if wearing full Adamantite set");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.sellPrice(gold: 3);
            Item.noMelee = true;
            Item.rare = 4;
            // Use Properties
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item157;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 40;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 13;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<SpaceRay>();
            Item.shootSpeed = 1f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 1f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                      .AddIngredient(ItemID.SpaceGun, 1)
                      .AddIngredient(ItemID.AdamantiteBar, 12)
                      .AddTile(TileID.MythrilAnvil)
                      .Register();
        }
    }

    public class SpaceSet : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ModContent.ItemType<SpaceBlaster>();
        }
        static string SetBonus = "Space Blaster Upgrade";
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.AdamantiteHeadgear && body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings)
                return SetBonus;
            return "";
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "Space Blaster Upgrade")
            {
                player.GetModPlayer<SpacePlayer>().SpaceBlaster = true;
            }
        }
    }
    public class SpacePlayer : ModPlayer
    {
        public bool SpaceBlaster;
        public override void ResetEffects()
        {
            SpaceBlaster = false;
        }
        public override void ModifyManaCost(Item item, ref float reduce, ref float mult)
        {
            if (Player.HeldItem.type == ModContent.ItemType<SpaceBlaster>() && SpaceBlaster)
            {
                mult = 0f;
            }
        }
    }

}
