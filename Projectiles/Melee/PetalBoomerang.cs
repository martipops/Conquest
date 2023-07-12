using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using static Conquest.Assets.Common.Helpers;
using Conquest.Assets.Common;

namespace Conquest.Projectiles.Melee
{
    public class PetalBoomerang : Boomerang
    {
        public override void SetDefaults()
        {
            Projectile.ignoreWater = true;
            Projectile.width = 14;
            Projectile.height = 30;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = -1;
            ReturnSpeed = 35f;
            HomingOnOwnerStrength = 1.2f;
            TravelOutFrames = 30;
            DoTurn = true;
        }

    }
    public class PetalBoomerang2 : Boomerang
    {
        public override void SetDefaults()
        {
            Projectile.ignoreWater = true;
            Projectile.width = 14;
            Projectile.height = 46;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = -1;
            ReturnSpeed = 40f;
            HomingOnOwnerStrength = 1.3f;
            TravelOutFrames = 35;
            DoTurn = true;
        }

    }
    public class PetalBoomerang3 : Boomerang
    {
        public override void SetDefaults()
        {
            Projectile.ignoreWater = true;
            Projectile.width = 42;
            Projectile.height = 40;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = -1;
            ReturnSpeed = 45f;
            HomingOnOwnerStrength = 1.3f;
            TravelOutFrames = 40;
            DoTurn = true;
        }

    }
    public class PetalBoomerang4 : Boomerang
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
            ReturnSpeed = 55f;
            HomingOnOwnerStrength = 1.3f;
            TravelOutFrames = 40;
            DoTurn = true;
        }

    }
    public class PetalBoomerang5 : Boomerang
    {
        public override void SetDefaults()
        {
            Projectile.ignoreWater = true;
            Projectile.width = 42;
            Projectile.height = 42;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = -1;
            ReturnSpeed = 60f;
            HomingOnOwnerStrength = 1.3f;
            TravelOutFrames = 50;
            DoTurn = true;
        }

    }
    public class PetalBoomerang6 : Boomerang
    {
        public override void SetDefaults()
        {
            Projectile.ignoreWater = true;
            Projectile.width = 42;
            Projectile.height = 42;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = -1;
            ReturnSpeed = 70f;
            HomingOnOwnerStrength = 1.3f;
            TravelOutFrames = 50;
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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Poisoned, 60);

        }
    }
}
