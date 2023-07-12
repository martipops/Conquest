using Conquest.Buffs;
using Conquest.Items.Weapons.Melee;
using Conquest.Items.Weapons.Ranged;
using Conquest.Projectiles;
using Conquest.Projectiles.Melee;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Assets.Common
{
    public class MyPlayer : ModPlayer
    {
        public float ScreenShake;
        public int emeraldCD = 0;
        public bool emerald = false;
        public bool CloseCall;
        public bool emeraldBoom = false;
        public bool immune = false;
        public int immuneTime = 0;
        public bool HunnyPot;
        public bool CursedTrident;
        public bool resetspeed;
        public bool Bones;
        public bool Bees;
        public bool Diplopia;
        public bool windGrass;
        public bool SilverBullets;
        public bool Glass;
        public int Glasstime;
         public bool Justice;
        public int JusticeDamage;
        public bool war;
        public bool Glory;
        public bool ElectroCrystal;
        public bool HeartSynthesizer;
        public bool canDoubleJump;
        public bool DoubleJump;
        public bool Polyute;

        public bool waitDoubleJump;

        public override void ResetEffects()
        {
            HunnyPot = false;
            CursedTrident = false;
            Bones = false;
            Bees = false;
            SilverBullets = false;
            Polyute = false;
            windGrass = false;
            Glory =  false;
            war = false;
            Justice = false;
            ElectroCrystal = false;
            HeartSynthesizer = false;
            canDoubleJump = false;
            Diplopia = false;
            CloseCall = false;
            Glass = false;
            Glasstime = 0;
            if (Player.GetModPlayer<MyPlayer>().emeraldCD > 0)
            {
                emeraldCD--;
                Player.GetModPlayer<MyPlayer>().emerald = false;
                if (Player.GetModPlayer<MyPlayer>().emeraldCD == 1)
                {
                    Player.GetModPlayer<MyPlayer>().emeraldBoom = false;
                    Terraria.Dust.NewDust(Player.position, 32, 48, DustID.GreenFairy);
                    Terraria.Dust.NewDust(Player.position, 32, 48, DustID.GreenFairy);
                    Terraria.Dust.NewDust(Player.position, 32, 48, DustID.GreenFairy);
                    Terraria.Dust.NewDust(Player.position, 32, 48, DustID.GreenFairy);
                    Terraria.Dust.NewDust(Player.position, 32, 48, DustID.GreenFairy);
                    Terraria.Dust.NewDust(Player.position, 32, 48, DustID.GreenFairy);
                    Terraria.Dust.NewDust(Player.position, 32, 48, DustID.GreenFairy);
                    Terraria.Dust.NewDust(Player.position, 32, 48, DustID.GreenFairy);
                }
            }
        }
        public override void OnHurt(Player.HurtInfo info)
        {
            if(Justice)
            {
                JusticeDamage += info.Damage;
            }
        }
        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (Bones)
            {
                if (Player.statLife <= 100 && !Player.HasBuff<BrokenBones2>())
                {
                    Player.AddBuff(ModContent.BuffType<BrokenBones2>(), 999);
                }
                if (Player.statLife >= 101 && Player.HasBuff<BrokenBones2>())
                {
                    Player.ClearBuff(ModContent.BuffType<BrokenBones2>());
                }
            }
            if (Justice)
            {
                if (JusticeDamage >= 100)
                {
                    Player.GetDamage(DamageClass.Generic).Flat += 1f;

                }
                if (JusticeDamage >= 200)
                {
                    Player.GetDamage(DamageClass.Generic).Flat += 1f;

                }
                if (JusticeDamage >= 300)
                {
                    Player.GetDamage(DamageClass.Generic).Flat += 1f;

                }
                if (JusticeDamage >= 400)
                {
                    Player.GetDamage(DamageClass.Generic).Flat += 1f;

                }
                if (JusticeDamage >= 500)
                {
                    Player.GetDamage(DamageClass.Generic).Flat += 1f;


                }
            }

        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (HeartSynthesizer)
            {
                if (Main.rand.NextBool(150)) // Player.HeldItem.shootSpeed
                {
                    Item.NewItem(proj.GetSource_FromThis(), target.getRect(), ItemID.Heart);

                }
            }
            if (Glory)
            {
                target.AddBuff(BuffID.Midas, 60 * 5);
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (ElectroCrystal && Main.rand.NextBool(8))
            {
                target.AddBuff(ModContent.BuffType<Electrified2>(), 120);
            }
            if (Glory)
            {
                target.AddBuff(BuffID.Midas, 60 * 5);
            }
        }
        public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (Bees)
            {
                const int NumProjectiles = 1;
                if (Main.rand.NextBool(20))
                {
                    for (int i = 0; i < NumProjectiles; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);
                        Projectile.NewProjectile(source, position, velocity, ProjectileID.Bee, damage, knockback, Player.whoAmI);

                    }
                }

            }

            return true;
        }
        public override void PreUpdateMovement()
        {
            if (canDoubleJump)
            {
                // Credit to BlueMoonJune
                if (Player.velocity.Y >= 0f && Collision.SolidCollision(Player.BottomLeft, 32, 8, true))
                {
                    {
                        DoubleJump = true;
                        waitDoubleJump = true;
                    }
                }
                else
                {
                    if (DoubleJump && Player.controlJump && !waitDoubleJump)
                    {
                        if (Player.jump > 0)
                        {
                            waitDoubleJump = true;
                            return;
                        }
                        Player.velocity.Y = (0f - Player.jumpSpeed) * Player.gravDir;
                        Player.jump = (int)(Player.jumpHeight);
                        DoubleJump = false;

                        //SoundEngine.PlaySound(new SoundStyle("Techarria/Content/Sounds/Boing"), Player.position);
                        for (int i = 0; i < 10; i++)
                            Dust.NewDust(Player.TopLeft, Player.width, Player.height, Terraria.ID.DustID.Clentaminator_Red);

                    }
                    waitDoubleJump = Player.controlJump;
                }
            }
        }
        public override void PostUpdateRunSpeeds()
        {
            if (windGrass == true)
            {
                Player.noFallDmg = true;
                Player.accRunSpeed += Main.windSpeedCurrent * 10;
            }
            else
            {
                Player.noFallDmg = false;
            }
        }
        public override bool FreeDodge(Player.HurtInfo info)
        {
            if (Player.GetModPlayer<MyPlayer>().emerald)
            {
                Player.GetModPlayer<MyPlayer>().immuneTime = 15;
                Player.GetModPlayer<MyPlayer>().emeraldBoom = true;
                return true;
            }
            if (CloseCall)
            {
                if (Player.statLife <= 100)
                {
                    if (Main.rand.NextBool(5))
                    {
                        immune = true;
                        immuneTime = 30;
                    }
                }
            }

            return false;
        }
        int timer;
        bool stop;
        public override void PreUpdate()
        {
            if (stop)
            {
                timer++;
            }
            if (timer >= 60)
            {
                timer = 0;
                stop = false;
            }
        }
        public override void PostUpdate()
        {
            if (Player.HasBuff(ModContent.BuffType<Steamy>()))
            {
                Player.statDefense /= 2;
            }

            if (Player.HasBuff(ModContent.BuffType<BrokenBones2>()))
            {
                Player.statDefense *= 0;
            }
            if (Glass)
            {
                Player.immuneTime = Glasstime;
            }
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {

            bool CursedTridentHotkey = Keybinds.CursedTrident.JustPressed;
            bool HunnyPotHotkey = Keybinds.HunnyPot.JustPressed;
            bool LegendaryHoteky = Keybinds.Legendary.JustPressed;
            var entitySource = Player.GetSource_FromThis();
            Vector2 velocity = Vector2.One;
            var type = ModContent.ProjectileType<CursedTrident>();
            int AmountHurt = Player.statLifeMax2 / 4;
            if (CursedTridentHotkey && CursedTrident && !Player.dead && !stop)
            {
                stop = true;
                Player.Hurt(PlayerDeathReason.ByCustomReason((Player.name + "Was claimed by the underworld")), AmountHurt, 1, false, false, 1, false, 100);
                Projectile.NewProjectile(entitySource, Main.MouseWorld, velocity, type, 300, 1, Player.whoAmI);
            }
            if (HunnyPotHotkey && HunnyPot && !Player.dead && !Player.HasBuff(ModContent.BuffType<HunnySickness>()))
            {
                Player.AddBuff(ModContent.BuffType<HunnySickness>(), 3600);

                Player.Heal(120);
            }
            if (PlayerInput.Triggers.JustPressed.MouseLeft)
            {
                resetspeed = false;
            }
            if (PlayerInput.Triggers.JustReleased.MouseLeft)
            {
                resetspeed = true;
            }
            if (LegendaryHoteky)
            {
                if (Player.HeldItem.type == ModContent.ItemType<AeroScimitar>() && !Player.HasBuff(ModContent.BuffType<ArmamentCooldown>()))
                {
                    int damage = Player.HeldItem.damage;
                    Player.AddBuff(ModContent.BuffType<ArmamentCooldown>(), 3600);
                    Projectile.NewProjectile(entitySource, Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<GiantTornado>(), damage, 1, Player.whoAmI);
                    SoundEngine.PlaySound(SoundID.DD2_BetsyWindAttack);
                }

                if (Player.HeldItem.type == ModContent.ItemType<PainTrain>() && !Player.HasBuff(ModContent.BuffType<ArmamentCooldown>()))
                {
                    Player.AddBuff(ModContent.BuffType<ArmamentCooldown>(), 3600);

                    SoundStyle TrainBro = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/Train");
                    SoundEngine.PlaySound(TrainBro);
                    Player.AddBuff(ModContent.BuffType<Steamy>(), 360);

                }
                if (Player.HeldItem.type == ModContent.ItemType<MoonlightGreatsword>() && !Player.HasBuff(ModContent.BuffType<ArmamentCooldown>()))
                {
                    Player.AddBuff(ModContent.BuffType<ArmamentCooldown>(), 3600);

                    SoundEngine.PlaySound(SoundID.Item29);
                    Player.AddBuff(ModContent.BuffType<MoonlightBlessing>(), 720);

                }

            }

        }
        public override void ModifyScreenPosition()
        {
            if (ScreenShake > 0.1f)
            {
                Main.screenPosition += new Vector2(Main.rand.NextFloat(ScreenShake), Main.rand.NextFloat(ScreenShake));

                ScreenShake *= 0.9f;
            }
        }
    }
}
