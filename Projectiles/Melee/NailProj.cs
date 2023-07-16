using Conquest.Assets.GUI.HollowKnight;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Projectiles.Melee
{
    public class NailProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;

        }
        public override void SetDefaults()
        {
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 21;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            Projectile.alpha = 0;
            Projectile.width = 50;
            Projectile.height = 40;
            Projectile.hide = true;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 2;
            DrawOriginOffsetY = 150;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player projOwner = Main.player[Projectile.owner];
            target.immune[Projectile.owner] = 11;
            var HollowGauge = projOwner.GetModPlayer<HollowGauge>();
            if (HollowGauge.HollowGaugeResourceCurrent != 100)
            {
                HollowGauge.HollowGaugeResourceCurrent += 3;

            }
            if (target.life <= 0)
            {
                if (HollowGauge.HollowGaugeResourceCurrent != 100)
                {
                    HollowGauge.HollowGaugeResourceCurrent += 10;

                }
            }

        }

        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }
        public override void AI()
        {
            Player projOwner = Main.player[Projectile.owner];
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            Projectile.direction = projOwner.direction;
            projOwner.heldProj = Projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            Projectile.position.X = ownerMountedCenter.X - Projectile.width / 2;
            Projectile.position.Y = ownerMountedCenter.Y - Projectile.height / 2;
            if (!projOwner.frozen)
            {
                if (movementFactor == 0f) 
                {
                    movementFactor = 14f; 
                    Projectile.netUpdate = true; 
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) 
                {
                    movementFactor -= 0f;
                }
                else 
                {
                    movementFactor += 0.7f;
                }
            }
            if (Projectile.frame >= 5)
            {
                Projectile.alpha += 25;
            }
            if (Projectile.alpha > 250)
            {
                Projectile.Kill();
            }
            if (++Projectile.frameCounter >= 3)
            {
                Projectile.frameCounter = 0;
                if (Projectile.frame < 5)
                {
                    Projectile.frame++;
                }
                else
                {

                }

            }
            if (projOwner.itemAnimation == 0)
            {

            }
            Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
            Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;
            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;
            origin.X = Projectile.spriteDirection == 1 ? sourceRectangle.Width - 40 : 40;

            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.spriteBatch.Draw(texture,
            Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
            sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0f);
            return false;
        }
    }
}
