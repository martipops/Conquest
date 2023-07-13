using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using ReLogic.Content;
using Conquest.Buffs;

namespace Conquest.Projectiles {
    public class WeakPoint : ModProjectile {

		// IF YOU WANT TO CHANGE DAMAGE OF THE MARKER EXLPODE, CHECK WeakpointDeBuff.cs!!!
		
        public static int pointDamage;
        public static int pointTimeLeft;
		private float lerpValue;
		private double sinCurve;
		public override void SetStaticDefaults() {
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
		}

		public sealed override void SetDefaults() {
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.tileCollide = false;
			Projectile.CritChance = 66;
            Projectile.knockBack = 0;
			Projectile.friendly = true;
            Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.minionSlots = 0f;
			Projectile.penetrate = -1;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return true;
		}
        public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}
		public override void AI() {
			
            Projectile.timeLeft = pointTimeLeft;

            Projectile.damage = pointDamage;

			Player owner = Main.player[Projectile.owner];

			SearchForTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            Movement(foundTarget, distanceFromTarget, targetCenter);

            if (WeakPointDeBuff.letsExplode) {
                Projectile.timeLeft = 0;
            }

			Projectile.ai[0] += 5;
			sinCurve = Math.Sin(MathHelper.ToRadians(Projectile.ai[0]));

			if(lerpValue < 1f) {
				lerpValue = (float)sinCurve;
			}
		}
        private void SearchForTargets(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter) {
			distanceFromTarget = 700f;
			targetCenter = Projectile.position;
			foundTarget = false;
			if (owner.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[owner.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 2000f) {
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
                            if (Projectile.getRect().Intersects(npc.getRect()) && !npc.HasBuff<WeakPointDeBuff>()) {
                                npc.AddBuff(ModContent.BuffType<WeakPointDeBuff>(), 1);
                            }
						}
					}
				}
			}
        }
        private void Movement(bool foundTarget, float distanceFromTarget, Vector2 targetCenter) {
            if (foundTarget) {
				Projectile.velocity = targetCenter - Projectile.Center;
			}
            else {
                Projectile.timeLeft = 0;
            }
		}
        public override void OnSpawn(IEntitySource source) {
            WeakPointDeBuff.letsExplode = false;
            pointTimeLeft = 2;
			lerpValue = 0;
        }
        public override bool PreDraw(ref Color lightColor) {
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Rectangle rect = new Rectangle(0, 0, texture.Width, texture.Height);
			Vector2 drawPosition = Projectile.position + new Vector2(Projectile.width, Projectile.height) / 2f + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition;
			Vector2 drawOrigin = new Vector2(texture.Width, texture.Height) / 2f;
			Main.EntitySpriteDraw(texture, drawPosition, rect, Color.White, Projectile.rotation, drawOrigin, new Vector2(1f,lerpValue), SpriteEffects.None, 0);

			return false;
		}
    }
}