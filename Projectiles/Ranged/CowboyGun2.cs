using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;


namespace Conquest.Projectiles.Ranged
{
    public class CowboyGun2 : ModProjectile
    {
        int timer;
        int fired;
        public override void SetDefaults()
        {
            Projectile.width = 46; // The width of projectile hitbox
            Projectile.height = 20; // The height of projectile hitbox

            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Ranged; // What type of damage does this projectile affect?
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.ignoreWater = false; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.timeLeft = 60; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
        }


        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            SearchForTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            if (foundTarget)
            {
                Projectile.rotation = (targetCenter - Projectile.position).ToRotation();
                Projectile.velocity = Vector2.Zero;
                Vector2 position = Projectile.Center;
                float speed = 20f;
                Vector2 direction = Vector2.Normalize(targetCenter - Projectile.Center);
                Vector2 velocity = direction * speed;
                if (fired != 1)
                {
                    timer++;
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, velocity, ProjectileID.Bullet, Projectile.damage, 0f, owner.whoAmI, fired = 1);
                    SoundEngine.PlaySound(SoundID.Item11, Projectile.Center);
                }

                if (timer >= 30)
                {
                    Projectile.Kill();
                }
                Projectile.ai[0]++;


            }
            else
            {

            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SteampunkSteam);
            }
        }
        private void SearchForTargets(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter)
        {
            // Starting search distance
            distanceFromTarget = 700f;
            targetCenter = Projectile.position;
            foundTarget = false;

            // This code is required if your minion weapon has the targeting feature
            if (owner.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[owner.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, Projectile.Center);

                // Reasonable distance away so it doesn't target across multiple screens
                if (between < 2000f)
                {
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    foundTarget = true;
                }
            }

            if (!foundTarget)
            {
                // This code is required either way, used for finding a target
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];

                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, Projectile.Center);
                        bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                        // Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
                        // The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
                        bool closeThroughWall = between < 100f;

                        if ((closest && inRange || !foundTarget) && (lineOfSight || closeThroughWall))
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }



        }
    }
}


