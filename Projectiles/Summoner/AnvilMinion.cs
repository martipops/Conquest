using Conquest.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Humanizer.In;

namespace Conquest.Projectiles.Summoner
{
    public class AnvilMinion : ModProjectile
    {
        int idle = 0;
        int timer = 0;
        int dropping = 0;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Anvil Minion");
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 14; // how long you want the trail to be
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // recording mode
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 32;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.minionSlots = 1;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) //custom ontilecollide
        {
            if (dropping == 1) //if it is dropping
            {
                Projectile.velocity = Vector2.Zero;
                //screenshake could also be here
                dropping = 0;
                timer = 0;
            }
            else //idk what to put here
            {
            }
            return false;
        }

        public override bool PreDraw(ref Color lightColor) //custom predraw for when its dropping
        {
            if (dropping == 1)
            {
                Main.instance.LoadProjectile(Projectile.type);
                Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

                // Redraw the projectile with the color not influenced by light
                Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
                for (int k = 0; k < Projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                    Color color = Projectile.GetAlpha(default) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
                }
            }
            return true;
        }
        SoundStyle HitNormal = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/Anvil_Hit_I")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 3,

        };
        SoundStyle HitCrit = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/Anvil_Hit_II")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 3,
        };
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {

            Projectile.velocity = Vector2.Zero;
            //screenshake could also be here
            dropping = 0;
            timer = 0;
            if (hit.Crit)
            {
                SoundEngine.PlaySound(HitCrit);
            }
            else SoundEngine.PlaySound(HitNormal);
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (!CheckActive(player))
            {
                return;
            }

            if (dropping == 0) //if not dropping
            {
                for (int num526 = 0; num526 < 1000; num526++)
                {
                    if (num526 != Projectile.whoAmI && Main.projectile[num526].active && Main.projectile[num526].owner == Projectile.owner && Main.projectile[num526].type == Projectile.type && Math.Abs(Projectile.position.X - Main.projectile[num526].position.X) + Math.Abs(Projectile.position.Y - Main.projectile[num526].position.Y) < Projectile.width)
                    {
                        if (Projectile.position.X < Main.projectile[num526].position.X)
                            Projectile.velocity.X = Projectile.velocity.X - 0.05f;
                        else
                            Projectile.velocity.X = Projectile.velocity.X + 0.05f;

                        if (Projectile.position.Y < Main.projectile[num526].position.Y)
                            Projectile.velocity.Y = Projectile.velocity.Y - 0.05f;
                        else
                            Projectile.velocity.Y = Projectile.velocity.Y + 0.05f;
                    }
                }

                float num527 = Projectile.position.X;
                float num528 = Projectile.position.Y;
                float num529 = 750f;
                bool targetfounds = false;

                if (Projectile.ai[0] == 0f)
                {
                    for (int num531 = 0; num531 < 100; num531++)
                    {
                        if (Main.npc[num531].CanBeChasedBy(Projectile, false))
                        {
                            float num532 = Main.npc[num531].position.X + Main.npc[num531].width / 2;
                            float num533 = Main.npc[num531].position.Y - 110 + Main.npc[num531].height / 2;
                            float num534 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num532) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num533);
                            if (num534 < num529 && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[num531].position, Main.npc[num531].width, Main.npc[num531].height))
                            {
                                num529 = num534;
                                num527 = num532;
                                num528 = num533;
                                targetfounds = true;
                            }
                        }
                    }
                }
                else
                    Projectile.tileCollide = false;
                if (!targetfounds) //when target is not found
                {
                    Projectile.friendly = true;
                    float num535 = 8f;
                    if (Projectile.ai[0] == 1f)
                        num535 = 12f;

                    Vector2 vector38 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                    float num536 = Main.player[Projectile.owner].Center.X - vector38.X;
                    float num537 = Main.player[Projectile.owner].Center.Y - vector38.Y - 40f;
                    float num538 = (float)Math.Sqrt((double)(num536 * num536 + num537 * num537));

                    if (num538 < 100f && Projectile.ai[0] == 1f && !Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
                        Projectile.ai[0] = 0f;

                    if (num538 > 2000f)
                    {
                        Projectile.position.X = Main.player[Projectile.owner].Center.X - Projectile.width * .5f;
                        Projectile.position.Y = Main.player[Projectile.owner].Center.Y - Projectile.width * .5f;
                    }

                    if (num538 > 70f)
                    {
                        num538 = num535 / num538;
                        num536 *= num538;
                        num537 *= num538;
                        Projectile.velocity.X = (Projectile.velocity.X * 20f + num536) * (1f / 21f);
                        Projectile.velocity.Y = (Projectile.velocity.Y * 20f + num537) * (1f / 21f);
                    }
                    else
                    {
                        if (Projectile.velocity.X == 0f && Projectile.velocity.Y == 0f)
                        {
                            Projectile.velocity.X = -0.15f;
                            Projectile.velocity.Y = -0.05f;
                        }
                        Projectile.velocity *= 1.00f;
                    }
                    Projectile.friendly = false;
                }
                else
                {
                    Projectile.tileCollide = false;
                    idle = 0;
                    timer++;

                    if (timer == 70)
                    {
                        dropping = 1;
                        timer = 0;
                    }

                    if (Projectile.ai[1] == -1f)
                        Projectile.ai[1] = 17f;

                    if (Projectile.ai[1] > 0f)
                        Projectile.ai[1] -= 1f;

                    if (Projectile.ai[1] == 0f)
                    {
                        Projectile.friendly = true;
                        float num539 = 12f;
                        float num540 = num527 - Projectile.Center.X;
                        float num541 = num528 - Projectile.Center.Y;
                        float num542 = (float)Math.Sqrt((double)(num540 * num540 + num541 * num541));
                        if (num542 < 100f)
                            num539 = 20f;

                        num542 = num539 / num542;
                        num540 *= num542;
                        num541 *= num542;
                        Projectile.velocity.X = (Projectile.velocity.X * 14f + num540) / 15f;
                        Projectile.velocity.Y = (Projectile.velocity.Y * 14f + num541) / 15f;
                    }
                    else
                    {
                        Projectile.friendly = false;
                        if (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) < 10f)
                            Projectile.velocity *= 1.05f;
                    }
                }
            }
            else //if dropping
            {
                Projectile.tileCollide = true;
                timer = 0; //makes sure timer doesnt overlap
                Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width * 2, Projectile.height * 2);
                Projectile.velocity.Y = 24;
                Projectile.velocity.X = 0;
                Projectile.rotation = 0;
            }
        }

        private bool CheckActive(Player owner) //checkactive for buff deactivation
        {
            if (owner.dead || !owner.active)
            {
                owner.ClearBuff(ModContent.BuffType<AnvilBuff>());

                return false;
            }

            if (owner.HasBuff(ModContent.BuffType<AnvilBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            return true;
        }
        public override bool MinionContactDamage() //makes sure it can do contact damage while dropping only
        {
            if (dropping == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

