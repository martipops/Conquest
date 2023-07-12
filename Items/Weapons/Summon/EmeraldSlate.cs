using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

using Terraria.DataStructures;
using Conquest.Projectiles.Summoner;
using Conquest.Assets.Common;

namespace Conquest.Items.Weapons.Summon
{
    internal class EmeraldSlate : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.knockBack = 3;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.width = 40;
            Item.height = 38;
            Item.mana = 10;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Summon;
            Item.autoReuse = false;
            Item.noUseGraphic = false;
            Item.noMelee = true;

            Item.rare = ItemRarityID.Green;

            Item.value = 50000;

            Item.shoot = ModContent.ProjectileType<EmeraldWall>();
            Item.shootSpeed = 0;

        }

        public override bool CanUseItem(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<EmeraldWall>()] > 0 || player.GetModPlayer<MyPlayer>().emeraldCD > 0)
            {
                return false;
            }
            return true;
        }
    }
}
