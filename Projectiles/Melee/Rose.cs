using Conquest.Assets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Conquest.Projectiles.Melee
{
    public class Rose : ModProjectile
    {
        uint hSCool = 0;
        public override void OnSpawn(IEntitySource source)
        {
            Player player = Main.player[Projectile.owner];
            Projectile.spriteDirection = player.direction;
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 60;
            Projectile.alpha = 0;
            Projectile.light = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            //Projectile.usesLocalNPCImmunity = true;
            //Projectile.localNPCHitCooldown = 30;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.Center = player.Center + (new Vector2(5 * (-Projectile.spriteDirection), 10)).RotatedBy(Projectile.rotation - 0.785398163f * Projectile.spriteDirection);
            Projectile.rotation += (Projectile.spriteDirection * 0.3f);
            player.itemRotation = Projectile.rotation + 0.785398163f;
            if (hSCool > 0)
            {
                hSCool--;
                player.GetModPlayer<MyPlayer>().ScreenShake = Math.Max(hSCool / 2, player.GetModPlayer<MyPlayer>().ScreenShake);
            }

        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (hSCool == 0)
            {
                Projectile.spriteDirection *= -1;
                Projectile.timeLeft = 31;
                var n = 150;
                var i = DateTime.Now.Millisecond;

                hSCool = 5;
            }
        }
    }
}
