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
using Terraria.Audio;
using Conquest.Dusts;
using Conquest.Assets.Common;

namespace Conquest.Projectiles.Melee
{
    internal class LightningKnifeProjectile : ModProjectile
    {
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
            Projectile.tileCollide = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;

        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.rotation = (float)(Math.Pow(60 - Projectile.timeLeft, 3) / 36000f) + 1.570795f -
            (float)Math.Atan2(Projectile.velocity.X, Projectile.velocity.Y);
            Projectile.velocity /= 1.01f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.ai[0] == 0f)
            {
                LightningStrike(-1, Projectile.Center, Projectile.damage);
            }

            return base.OnTileCollide(oldVelocity);
        }












        // Credit to StormyTuna
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
                Main.LocalPlayer.ApplyDamageToNPC(closeNPCs[i], damage, 0f, 0, false);
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