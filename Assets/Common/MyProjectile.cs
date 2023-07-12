using Conquest.Buffs;
using Conquest.Items.Weapons.Ranged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Assets.Common
{
    internal class MyProjectile : GlobalProjectile
    {
        public static float killsCount;
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Main.myPlayer];
            var entitySource = Projectile.GetSource_None();

            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (player.HeldItem.type == ModContent.ItemType<Breakneck>())
            {
                if (!target.active)
                {
                    killsCount += 1;
                    Breakneck.fireRateTimer = 0;
                }
            }
            if (modPlayer.Polyute && projectile.friendly && Main.rand.NextBool(10))
            {
                Projectile.NewProjectile(entitySource, target.Center.X, target.Center.Y - 100, Main.rand.Next(20, 21) * .25f, Main.rand.Next(20, 21) * .25f, ProjectileID.ChlorophyteBullet, player.HeldItem.damage, 0f, projectile.owner);

            }
            if (modPlayer.ElectroCrystal && projectile.friendly && Main.rand.NextBool(10))
            {
                target.AddBuff(ModContent.BuffType<Electrified2>(), 120);
            }
        }
    }
}
