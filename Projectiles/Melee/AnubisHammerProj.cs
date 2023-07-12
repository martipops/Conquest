using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Conquest.Assets.Common.Helpers;
using Conquest.Assets.Common;

namespace Conquest.Projectiles.Melee
{
    public class AnubisHammerProj : Boomerang
    {
        public override void SetDefaults()
        {
            Projectile.ignoreWater = true;
            Projectile.width = 46;
            Projectile.height = 46;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = -1;

            ReturnSpeed = 60f;
            HomingOnOwnerStrength = 1.2f;
            TravelOutFrames = 30;
            DoTurn = true;
        }
        public override void AI()
        {
            if (Projectile.ai[0] == 0f)
            {
                var target = Helpers.GetClosestEnemy(Projectile.Center, 20f * 16f, true, true);

                // If there's an npc near the boomerang, we want to move towards it
                if (target != null)
                {
                    DoTurn = false;
                    // Add to our velocity 
                    float maxVelocity = ReturnSpeed * Owner.GetAttackSpeed(DamageClass.Melee);
                    float homingStrength = 0.9f;
                    Vector2 toEnemy = target.Center - Projectile.Center;
                    toEnemy.Normalize();
                    toEnemy *= homingStrength;
                    Projectile.velocity += toEnemy;
                    if (Projectile.velocity.LengthSquared() > maxVelocity * maxVelocity)
                    {
                        Projectile.velocity.Normalize();
                        Projectile.velocity *= maxVelocity;
                    }
                }

                DoTurn = true;

            }
            base.AI();

        }
    }
}
