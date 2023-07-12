using Conquest.Assets.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using static Conquest.Assets.Common.Helpers;

namespace Conquest.Projectiles.Melee
{
    public class EternalFlamesProj : Boomerang
    {
        int timer;
       
        public override void SetDefaults()
        {
            Projectile.ignoreWater = true;
            Projectile.width = 70;
            Projectile.height = 70;
            Projectile.scale = 0.7f;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = -1;

            ReturnSpeed = 35f;
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
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 60);
            /*var settings = new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center,
                MovementVector = Projectile.velocity
            };
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.RainbowRodHit, settings);*/
        }
        
    }
        
}
