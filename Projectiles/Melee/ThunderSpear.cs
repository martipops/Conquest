using Conquest.Assets.Common;
using Conquest.Dusts;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
namespace Conquest.Projectiles.Melee
{
    public class ThunderSpear : ModProjectile
    {
        protected virtual float HoldoutRangeMin => 48f;
        protected virtual float HoldoutRangeMax => 96f;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Spear");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Spear); // Clone the default values for a vanilla spear. Spear specific values set for width, height, aiStyle, friendly, penetrate, tileCollide, scale, hide, ownerHitCheck, and melee.
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner]; // Since we access the owner player instance so much, it's useful to create a helper local variable for this
            int duration = player.itemAnimationMax; // Define the duration the projectile will exist in frames

            player.heldProj = Projectile.whoAmI; // Update the player's held projectile id

            // Reset projectile time left if necessary
            if (Projectile.timeLeft > duration)
            {
                Projectile.timeLeft = duration;
            }

            Projectile.velocity = Vector2.Normalize(Projectile.velocity); // Velocity isn't used in this spear implementation, but we use the field to store the spear's attack direction.

            float halfDuration = duration * 0.5f;
            float progress;

            // Here 'progress' is set to a value that goes from 0.0 to 1.0 and back during the item use animation.
            if (Projectile.timeLeft < halfDuration)
            {
                progress = Projectile.timeLeft / halfDuration;
            }
            else
            {
                progress = (duration - Projectile.timeLeft) / halfDuration;
            }

            // Move the projectile from the HoldoutRangeMin to the HoldoutRangeMax and back, using SmoothStep for easing the movement
            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);

            // Apply proper rotation to the sprite.
            if (Projectile.spriteDirection == -1)
            {
                // If sprite is facing left, rotate 45 degrees
                Projectile.rotation += MathHelper.ToRadians(45f);
            }
            else
            {
                // If sprite is facing right, rotate 135 degrees
                Projectile.rotation += MathHelper.ToRadians(135f);
            }

            // Avoid spawning dusts on dedicated servers
            if (!Main.dedServ)
            {
                // These dusts are added later, for the 'ExampleMod' effect

            }

            return false; // Don't execute vanilla AI.
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.ai[0] == 0f)
            {
                LightningStrike(target.whoAmI, target.Center, damageDone);
            }

        }

        private void LightningStrike(int whoAmIToIgnore, Vector2 startPos, int damage)
        {
            List<NPC> closeNPCs = new();
            if (whoAmIToIgnore == -1)
            {
                closeNPCs = Helpers.GetNearbyEnemies(startPos, 16f * 16f, true, false);
            }
            else
            {
                closeNPCs = Helpers.GetNearbyEnemies(startPos, 16f * 16f, true, false, new List<int>() { whoAmIToIgnore });
            }

            int numLightning = (int)MathHelper.Clamp(closeNPCs.Count, 0f, 3f);
            for (int i = 0; i < numLightning; i++)
            {
                Main.LocalPlayer.ApplyDamageToNPC(closeNPCs[i], damage / 3, 0f, 0, false);
                LightningHelper.MakeDust(startPos, closeNPCs[i].Center);
            }
        }
        public class LightningHelper
        {
            public static void MakeDust(Vector2 source, Vector2 dest)
            {
                var dustPoints = CreateBolt(source, dest);
                foreach (var point in dustPoints)
                {
                    Dust d = Dust.NewDustPerfect(point, ModContent.DustType<LightningDust>(), Scale: 0.8f);
                    d.noGravity = true;
                    d.velocity = Vector2.Zero;
                }
            }

            public static List<Vector2> CreateBolt(Vector2 source, Vector2 dest)
            {
                var results = new List<Vector2>();
                Vector2 tangent = dest - source;
                Vector2 normal = Vector2.Normalize(new Vector2(tangent.Y, -tangent.X));
                float length = tangent.Length();

                List<float> positions = new List<float>();
                positions.Add(0);

                for (int i = 0; i < length; i++)
                    positions.Add(Main.rand.NextFloat(0f, 1f));

                positions.Sort();

                const float Sway = 1000;
                const float Jaggedness = 1 / Sway;

                Vector2 prevPoint = source;
                float prevDisplacement = 0f;
                for (int i = 1; i < positions.Count; i++)
                {
                    float pos = positions[i];

                    // used to prevent sharp angles by ensuring very close positions also have small perpendicular variation.
                    float scale = (length * Jaggedness) * (pos - positions[i - 1]);

                    // defines an envelope. Points near the middle of the bolt can be further from the central line.
                    float envelope = pos > 0.95f ? 20 * (1 - pos) : 1;

                    float displacement = Main.rand.NextFloat(-Sway, Sway);
                    displacement -= (displacement - prevDisplacement) * (1 - scale);
                    displacement *= envelope;

                    Vector2 point = source + pos * tangent + displacement * normal;
                    results.Add(point);
                    prevPoint = point;
                    prevDisplacement = displacement;
                }

                results.Add(prevPoint);

                return results;
            }
        }
    }
}

