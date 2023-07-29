using Conquest.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Projectiles.DarkDawnProjectiles {
    public class DarkDawnProjEclipseFire : ModProjectile {
        private Color fireColor;
        public override void SetStaticDefaults() {
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
            Projectile.width = 4000;
            Projectile.height = 4000;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.minionSlots = 0f;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 1;
        }
        public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return true;
		}
        public override void AI() {

            fireColor = new Color(255, 106, 0);

            for (int i = 0; i < Main.maxNPCs; i++) {
                NPC npc = Main.npc[i];
                if (npc.CanBeChasedBy()) {
                    if (Projectile.getRect().Intersects(npc.getRect())) {
                        npc.AddBuff(ModContent.BuffType<EclipseFire>(), 2);
                        if(npc.active) {
                            for (int k = 0; k < 50; k++) {
                                Vector2 eclipsePos = Main.rand.NextVector2CircularEdge(npc.width, npc.width);
                                Dust eclipseDust = Dust.NewDustPerfect(npc.Center + eclipsePos, DustID.RainbowMk2, null, 255, fireColor, 0.7f);
                                eclipseDust.noGravity = true;
                                eclipseDust.fadeIn = 0f;
                                Vector2 eclipseBPos = Main.rand.NextVector2CircularEdge(npc.width - 10f, npc.width - 10f);
                                Dust eclipseBDust = Dust.NewDustPerfect(npc.Center + eclipseBPos, DustID.RainbowMk2, null, 255, Color.Black, 1f);
                                eclipseBDust.noGravity = true;
                                eclipseBDust.fadeIn = 0f;
                            }
                        }
                    }
                }
            }
        }
    }
}

