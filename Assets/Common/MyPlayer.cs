
using Microsoft.Xna.Framework;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Physics;
using static Humanizer.In;
using static Terraria.ModLoader.PlayerDrawLayer;
using static tModPorter.ProgressUpdate;
using Terraria.ModLoader.IO;
using Conquest.Assets.Common;
using Conquest.Assets.GUI;
using Conquest.Buffs;
using Conquest.Items.Consumable;
using Conquest.Items.Weapons.Melee;
using Conquest.Items.Weapons.Ranged;
using Conquest.Projectiles.Melee;
using Conquest.Projectiles;
using Conquest.Projectiles.Ranged;

namespace Conquest.Assets.Common
{

    public class MyPlayer : ModPlayer
    {
        public int summonCD = 0;
        public bool immune = false;
        public int immuneTime = 0;
        public int unshootingTime = 0;
        public static int exMeleeSpeed = 0;
        public int unshootingCounter = 0;
        public bool blocking = false;
        public int blockCounter = 0;
        public int lostLife = 0;
        public int lostLifeCounter = 0;
        public int exLifeRegen = 0;
        public int exLifeRegenCounter = 0;
        public int lostLifeRegen = 0;
        public bool war;
        public bool Glass;
        public bool test;
        public bool Pickaxe = false;
        public bool Diplopia;
        public bool CursedTrident;
        public float ScreenShake;
        public bool Bones;
        public bool Bees;
        public bool SilverBullets;
        public bool HeavyBullets;
        public int Glasstime;
        public bool HunnyPot;
        public bool Loaded;
        public bool HeartSynthesizer;
        public bool canDoubleJump;
        public bool DoubleJump;
        public bool waitDoubleJump;
        public bool Polyute;
        public bool Upgrade1;
        public bool Upgrade2;
        public float testspeedmulti;
        public bool resetspeed;
        public bool ElectroCrystal;
        public bool windGrass;
        public static int damageGivenForWeakPoints;
        public int emeraldCD = 0;
        public bool emerald = false;
        public bool CloseCall;
        public bool emeraldBoom = false;
        public static float warpSelfAimDespawn = 60; // don't touch
        public int TimeWarpSwitch = 0;
        public static bool TimeWarpIsPossible;
        public static int WarpEnergy = 300;
        public bool Glory;
        public bool Justice;
        public int JusticeDamage;
        public int TimesHit;
        public bool America;
        public override void ResetEffects()
        {
            Diplopia = false;
            Bones = false;
            CursedTrident = false;
            Bees = false;
            SilverBullets = false;
            HeavyBullets = false;
            HunnyPot = false;
            HeartSynthesizer = false;
            canDoubleJump = false;
            Polyute = false;
            Upgrade1 = false;
            Upgrade2 = false;
            ElectroCrystal = false;
            Glory = false;
            windGrass = false;
            war = false;
            Glass = false;
            Glasstime = 0;
            CloseCall = false;
            America = false;
            Justice = false;
            if (Player.GetModPlayer<MyPlayer>().blocking == true)
            {
                if (++Player.GetModPlayer<MyPlayer>().blockCounter >= 30)
                {
                    Player.GetModPlayer<MyPlayer>().blockCounter = 0;
                    Player.GetModPlayer<MyPlayer>().blocking = false;
                }
            }
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
            if (NPC.downedBoss1 == true && EightTrigrams.tMaxLoad < 6)
            {
                EightTrigrams.tMaxLoad = 6;
            }
            if (Main.hardMode == true && EightTrigrams.tMaxLoad < 10)
            {
                EightTrigrams.tMaxLoad = 10;
            }
            if (NPC.downedPlantBoss == true && EightTrigrams.tMaxLoad < 18)
            {
                EightTrigrams.tMaxLoad = 18;
            }
            if (NPC.downedMoonlord == true && EightTrigrams.tMaxLoad < 24)
            {
                EightTrigrams.tMaxLoad = 24;
            }

        }

        public override void PostUpdateEquips()
        {
            if (T6.p37On == true)
            {
                Player.GetDamage<SummonDamageClass>() *= 1f + (Player.maxMinions * 0.02f + Player.maxTurrets * 0.04f);
                Player.GetDamage<SummonMeleeSpeedDamageClass>() *= 1f + (Player.maxMinions * 0.02f + Player.maxTurrets * 0.04f);
            }
            if (T6.p33On == true)
            {
                Player.maxMinions += 2;
            }
            if (T6.p35On == true)
            {
                Player.maxMinions += (int)(Player.statManaMax2 / 100);
                Player.maxTurrets += (int)(Player.maxMinions / 4);
            }
            if (T6.p31On)
            {

                Player.GetDamage(DamageClass.Summon) += 0.02f;
                Player.maxMinions += 1;
            }


        }
        public override void SaveData(TagCompound tag)
        {
            tag.Add("TLoad", EightTrigrams.tLoad);


            if (Player.GetModPlayer<MyPlayer>().immune == true)
            {
                tag.Add("immune", Player.GetModPlayer<MyPlayer>().immune);

            }
            if (T1.p1On == true)
            {
                tag.Add("isP1On", T1.p1On);
            }
            if (T1.p2On == true)
            {
                tag.Add("isP2On", T1.p2On);
            }
            if (T1.p3On == true)
            {
                tag.Add("isP3On", T1.p3On);
            }
            if (T1.p4On == true)
            {
                tag.Add("isP4On", T1.p4On);
            }
            if (T1.p5On == true)
            {
                tag.Add("isP5On", T1.p5On);
            }
            if (T1.p6On == true)
            {
                tag.Add("isP6On", T1.p6On);
            }
            if (T1.p7On == true)
            {
                tag.Add("isP7On", T1.p7On);
            }

            if (T8.p11On == true)
            {
                tag.Add("isP11On", T8.p11On);
            }
            if (T8.p12On == true)
            {
                tag.Add("isP12On", T8.p12On);
            }
            if (T8.p13On == true)
            {
                tag.Add("isP13On", T8.p13On);
            }
            if (T8.p14On == true)
            {
                tag.Add("isP14On", T8.p14On);
            }
            if (T8.p15On == true)
            {
                tag.Add("isP15On", T8.p15On);
            }
            if (T8.p16On == true)
            {
                tag.Add("isP16On", T8.p16On);
            }
            if (T8.p17On == true)
            {
                tag.Add("isP17On", T8.p17On);
            }

            if (T3.p21On == true)
            {
                tag.Add("isP21On", T3.p21On);
            }
            if (T3.p22On == true)
            {
                tag.Add("isP22On", T3.p22On);
            }
            if (T3.p23On == true)
            {
                tag.Add("isP23On", T3.p23On);
            }
            if (T3.p24On == true)
            {
                tag.Add("isP24On", T3.p24On);
            }
            if (T3.p25On == true)
            {
                tag.Add("isP25On", T3.p25On);
            }
            if (T3.p26On == true)
            {
                tag.Add("isP26On", T3.p26On);
            }
            if (T3.p27On == true)
            {
                tag.Add("isP27On", T3.p27On);
            }

            if (T6.p31On == true)
            {
                tag.Add("isP31On", T6.p31On);
            }
            if (T6.p32On == true)
            {
                tag.Add("isP32On", T6.p32On);
            }
            if (T6.p33On == true)
            {
                tag.Add("isP33On", T6.p33On);
            }
            if (T6.p34On == true)
            {
                tag.Add("isP34On", T6.p34On);
            }
            if (T6.p35On == true)
            {
                tag.Add("isP35On", T6.p35On);
            }
            if (T6.p36On == true)
            {
                tag.Add("isP36On", T6.p36On);
            }
            if (T6.p37On == true)
            {
                tag.Add("isP37On", T6.p37On);
            }
        }
        public override void LoadData(TagCompound tag)
        {
            EightTrigrams.tLoad = tag.GetInt("TLoad");

            Player.GetModPlayer<MyPlayer>().immune = tag.GetBool("immune");

            T1.p1On = tag.GetBool("isP1On");
            T1.p2On = tag.GetBool("isP2On");
            T1.p3On = tag.GetBool("isP3On");
            T1.p4On = tag.GetBool("isP4On");
            T1.p5On = tag.GetBool("isP5On");
            T1.p6On = tag.GetBool("isP6On");
            T1.p7On = tag.GetBool("isP7On");

            T8.p11On = tag.GetBool("isP11On");
            T8.p12On = tag.GetBool("isP12On");
            T8.p13On = tag.GetBool("isP13On");
            T8.p14On = tag.GetBool("isP14On");
            T8.p15On = tag.GetBool("isP15On");
            T8.p16On = tag.GetBool("isP16On");
            T8.p17On = tag.GetBool("isP17On");

            T3.p21On = tag.GetBool("isP21On");
            T3.p22On = tag.GetBool("isP22On");
            T3.p23On = tag.GetBool("isP23On");
            T3.p24On = tag.GetBool("isP24On");
            T3.p25On = tag.GetBool("isP25On");
            T3.p26On = tag.GetBool("isP26On");
            T3.p27On = tag.GetBool("isP27On");

            T6.p31On = tag.GetBool("isP31On");
            T6.p32On = tag.GetBool("isP32On");
            T6.p33On = tag.GetBool("isP33On");
            T6.p34On = tag.GetBool("isP34On");
            T6.p35On = tag.GetBool("isP35On");
            T6.p36On = tag.GetBool("isP36On");
            T6.p37On = tag.GetBool("isP37On");

            //    Player.GetModPlayer<ETControl>().onShield = false;

        }
        bool rez;
        public override bool FreeDodge(Player.HurtInfo info)
        {
            if (Player.GetModPlayer<MyPlayer>().emerald)
            {
                Player.GetModPlayer<MyPlayer>().immuneTime = 15;
                Player.GetModPlayer<MyPlayer>().emeraldBoom = true;
                return true;
            }
            if (T8.p15On == true && info.Damage >= Player.statLife && info.Damage < Player.statLife + Player.GetModPlayer<MyPlayer>().lostLife)
            {
                Player.GetModPlayer<MyPlayer>().lostLife -= info.Damage;

                Player.statLife = 1;

                return true;
            }
            if (T6.p34On == true && info.Damage >= Player.statLife && Player.GetModPlayer<MyPlayer>().immune == true && !rez)
            {
                rez = true;
                Player.GetModPlayer<MyPlayer>().summonCD = 1000;
                Player.statLife = 1;
                for (int i = 0; i < Player.MaxBuffs; i++)
                {
                    Player.ClearBuff(Player.buffType[i]);
                }
                Player.Heal(Player.maxMinions * 10);
                Player.GetModPlayer<MyPlayer>().immuneTime = 60;
                Player.GetModPlayer<MyPlayer>().immune = false;
                SoundStyle Revive = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/Revive");
                SoundEngine.PlaySound(Revive);
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

            if (Player.GetModPlayer<MyPlayer>().immuneTime > 0)
            {
                return true;
            }
            return false;
        }
        public override void ModifyScreenPosition()
        {
            if (ScreenShake > 0.1f)
            {
                Main.screenPosition += new Vector2(Main.rand.NextFloat(ScreenShake), Main.rand.NextFloat(ScreenShake));

                ScreenShake *= 0.9f;
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

            if (Player.HeldItem.type != ModContent.ItemType<PainTrain>() && Player.HasBuff(ModContent.BuffType<Steamy>()))
            {
                Player.ClearBuff(ModContent.BuffType<Steamy>());

            }
            if (Player.HeldItem.type != ModContent.ItemType<MoonlightGreatsword>() && Player.HasBuff(ModContent.BuffType<MoonlightBlessing>()))
            {
                Player.ClearBuff(ModContent.BuffType<MoonlightBlessing>());
            }
            if (Player.HeldItem.type != ModContent.ItemType<Chikage>() && Player.HasBuff(ModContent.BuffType<ChikageBuff>()))
            {
                Player.ClearBuff(ModContent.BuffType<ChikageBuff>());
            }
            if (T1.p1On == true)
            {
                Player.GetDamage(DamageClass.Magic) += 0.02f;
                //Player.statManaMax2 += 20;
            }
            if (T1.p4On == true)
            {
                Player.GetDamage(DamageClass.Magic) += (float)Player.statMana / 1000;
            }
            if (T3.p21On == true)
            {
                Player.GetDamage(DamageClass.Ranged) += 0.02f;
                Player.GetCritChance(DamageClass.Generic) += 0.02f;
            }
            if (T3.p25On == true)
            {
                Player.GetCritChance(DamageClass.Ranged) += 10f;
            }
            if (T3.p22On == true)
            {
                if (Player.HeldItem.DamageType == DamageClass.Ranged)
                {
                    if (Player.GetModPlayer<MyPlayer>().unshootingTime <= 10 && ++Player.GetModPlayer<MyPlayer>().unshootingCounter >= 15)
                    {
                        Player.GetModPlayer<MyPlayer>().unshootingCounter = 0;
                        Player.GetModPlayer<MyPlayer>().unshootingTime++;
                    }

                    if (Player.GetModPlayer<MyPlayer>().unshootingTime > 0)
                    {
                        Player.GetDamage(DamageClass.Ranged) += 0.01f * Player.GetModPlayer<MyPlayer>().unshootingTime;
                        if (Player.controlUseItem)
                        {
                            Player.GetModPlayer<MyPlayer>().unshootingTime = 0;
                        }
                    }
                }
                if (Player.HeldItem.DamageType != DamageClass.Ranged)
                {
                    Player.GetModPlayer<MyPlayer>().unshootingTime = 0;
                }
            }
            if (T3.p23On == true && Player.HeldItem.DamageType == DamageClass.Ranged)
            {
                if (Player.controlUseItem)
                {
                    Player.HeldItem.GetGlobalItem<MyItem>();
                }
            }
            if (item.useTime >= 35 && item.DamageType.CountsAsClass(DamageClass.Ranged) && T3.p26On)
            {
                Player.GetDamage(DamageClass.Ranged) += 0.25f;
            }

            if (T6.p32On)
            {
                Player.GetDamage(DamageClass.Summon).Flat += 2;
            }
            if (T8.p16On == true)
            {
                if (Player.statLife >= Player.statLifeMax2 / 4)
                {
                    Player.GetAttackSpeed<MeleeDamageClass>() += 1 - (Player.statLife / Player.statLifeMax2);

                }
                else if (Player.statLife < Player.statLifeMax2 / 4)
                {
                    Player.GetAttackSpeed<MeleeDamageClass>() += 0.75f;
                }
            }

            if (T8.p17On == true)
            {
                Player.GetModPlayer<MyPlayer>().exLifeRegen = (int)(Player.statLifeMax2 / 25f);

                if (++Player.GetModPlayer<MyPlayer>().exLifeRegenCounter >= 60 - Player.GetModPlayer<MyPlayer>().exLifeRegen)
                {
                    Player.GetModPlayer<MyPlayer>().exLifeRegenCounter = 0;
                    Player.statLife += 1;
                    if (Player.velocity.X == 0 && Player.velocity.Y == 0)
                    {
                        Player.statLife += 1;
                    }
                    if (Player.statLife > Player.statLifeMax2)
                    {
                        Player.statLife = Player.statLifeMax2;
                    }
                }
            }
            if (T8.p12On == true)
            {
                Player.GetAttackSpeed(DamageClass.Melee) += exMeleeSpeed;
            }
            if (T8.p14On == true)
            {
                if (Player.velocity.Y > 0)
                {
                    Player.GetDamage<MeleeDamageClass>() *= Player.velocity.X * Player.velocity.X / 400 + Player.velocity.Y / 20 + Player.GetAttackSpeed(DamageClass.Melee);
                }
                else if (Player.velocity.Y <= 0)
                {
                    Player.GetDamage<MeleeDamageClass>() *= Player.velocity.X * Player.velocity.X / 400 + Player.GetAttackSpeed(DamageClass.Melee);
                }
            }

            if (T8.p11On == true)
            {
                Player.GetDamage(DamageClass.Melee) += 0.02f;
                Player.statLifeMax2 += 20;
            }
            if (T6.p34On == true && Player.HeldItem.DamageType == DamageClass.Summon && Player.GetModPlayer<MyPlayer>().summonCD <= 0)
            {
                if (Player.controlUseItem)
                {
                    Player.GetModPlayer<MyPlayer>().immune = true;
                }
            }
            if (Player.GetModPlayer<MyPlayer>().immuneTime > 0)
            {
                Player.GetModPlayer<MyPlayer>().immuneTime--;
            }


            if (Player.GetModPlayer<MyPlayer>().summonCD > 0)
            {
                Player.GetModPlayer<MyPlayer>().summonCD--;
                Terraria.Dust.NewDust(Player.position, 30, 30, DustID.GiantCursedSkullBolt, 0, 0, 0, default, 1);
                if (Player.HeldItem.DamageType == DamageClass.Summon)
                {
                    Player.controlUseItem = false;
                }

            }

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
        public override void OnHurt(Player.HurtInfo info)
        {
            if (T8.p15On == true && info.Damage < Player.statLife)
            {
                {
                    Player.GetModPlayer<MyPlayer>().lostLife += (int)info.Damage;
                }
            }
            if (Justice)
            {
                JusticeDamage += info.Damage;
            }
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (Player.GetModPlayer<MyPlayer>().summonCD > 0)
            {
                Player.GetModPlayer<MyPlayer>().summonCD = 0;
            }
            rez = false;
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
            if (target.HasBuff<WeakPointDeBuff>())
            {
                damageGivenForWeakPoints = damageDone;
                WeakPointDeBuff.letsExplode = true;
                WeakPoint.pointTimeLeft = 0;
                double n = 1000;
                for (int k = 0; k < 50; k++)
                {
                    Vector2 gigaVelocity = new Vector2(
                        3f * (float)Math.Pow(Math.Abs(Math.Cos(k)), 2 / n) * Math.Sign(Math.Cos(k)),
                        3f * (float)Math.Pow(Math.Abs(Math.Sin(k)), 2 / n) * Math.Sign(Math.Sin(k))
                        );
                    Dust killDust = Dust.NewDustPerfect(target.Center, DustID.VampireHeal, gigaVelocity, 255, Color.Red, 1f);
                    killDust.noGravity = true;
                }
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
            Main.LocalPlayer.adjWater = false;
        }
        public override void PostUpdateRunSpeeds()
        {
            if (Player.HeldItem.type == ModContent.ItemType<AeroScimitar>())
            {
                Player.runAcceleration += 0.25f;
                Player.maxRunSpeed += 0.25f;
            }
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
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            return new[] {
                new Item(ModContent.ItemType<EightTrigramsMirror>()),
                new Item(ModContent.ItemType<DesertMirror>()),

            };
        }
        int timer;
        bool stop;
        public override void PreUpdate()
        {
            //needed for propely timeWarp work

            if (stop)
            {
                timer++;
            }
            if (timer >= 60)
            {
                timer = 0;
                stop = false;
            }
            if (T1.p7On == true && !Player.HasBuff<StarSpirit>())
            {
                Player.AddBuff(ModContent.BuffType<StarSpirit>(), 999);
            }
            if (T3.p24On)
            {
                Player.AddBuff(ModContent.BuffType<WeakPointBuff>(), 900);
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
          

            // here is time Warp trigger






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
                if (Player.HeldItem.type == ModContent.ItemType<Chikage>() && !Player.HasBuff(ModContent.BuffType<ArmamentCooldown>()))
                {
                    Player.AddBuff(ModContent.BuffType<ChikageBuff>(), 800);
                    Player.AddBuff(ModContent.BuffType<ArmamentCooldown>(), 3600);
                    Player.Hurt(PlayerDeathReason.ByCustomReason((Player.name + "Got to cocky")), AmountHurt, 1, false, false, 1, false, 100);
                }
            }

        }

        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (T8.p12On == true)
            {
                if (item.DamageType == DamageClass.Melee && target.GetGlobalNPC<MyNpc>().speedMelee <= 5)
                {
                    if (target.GetGlobalNPC<MyNpc>().speedMelee < 5)
                    {
                        target.GetGlobalNPC<MyNpc>().speedMelee += 1;

                    }

                    target.GetGlobalNPC<MyNpc>().speedMeleeClear = 0;
                }

                if (item.DamageType == DamageClass.Melee && target.GetGlobalNPC<MyNpc>().speedMelee > 0)
                {
                    exMeleeSpeed = target.GetGlobalNPC<MyNpc>().speedMelee * target.GetGlobalNPC<MyNpc>().speedMelee / 100;
                }
            }
            if (T8.p13On == true)
            {
                Player.GetModPlayer<MyPlayer>().blocking = true;
            }
            if (T8.p15On == true && Player.GetModPlayer<MyPlayer>().lostLife > 0)
            {
                Player.GetModPlayer<MyPlayer>().lostLifeRegen = hit.Damage / 50;
                if (Player.GetModPlayer<MyPlayer>().lostLifeRegen > 10)
                {
                    Player.GetModPlayer<MyPlayer>().lostLifeRegen = 10;
                }
                Player.GetModPlayer<MyPlayer>().lostLife -= Player.GetModPlayer<MyPlayer>().lostLifeRegen;
                if (Player.GetModPlayer<MyPlayer>().lostLife < 0)
                {
                    Player.GetModPlayer<MyPlayer>().lostLife = 0;
                }
                Player.statLife += Player.GetModPlayer<MyPlayer>().lostLifeRegen;
                if (Player.statLife > Player.statLifeMax2)
                {
                    Player.statLife = Player.statLifeMax2;
                }
            }

        }
        int fired;
        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (T1.p2On == true && proj.DamageType == DamageClass.Magic)
            {
                target.AddBuff(BuffID.OnFire, 60, false);
            }
            if (T8.p12On == true)
            {
                if (proj.DamageType == DamageClass.Melee && target.GetGlobalNPC<MyNpc>().speedMelee <= 5)
                {
                    if (target.GetGlobalNPC<MyNpc>().speedMelee < 5)
                    {
                        target.GetGlobalNPC<MyNpc>().speedMelee += 1;

                    }

                    target.GetGlobalNPC<MyNpc>().speedMeleeClear = 0;
                }

                if (proj.DamageType == DamageClass.Melee && target.GetGlobalNPC<MyNpc>().speedMelee > 0)
                {
                    exMeleeSpeed = target.GetGlobalNPC<MyNpc>().speedMelee * target.GetGlobalNPC<MyNpc>().speedMelee / 200;
                }
            }
            if (Glory)
            {
                target.AddBuff(BuffID.Midas, 60 * 5);
            }
            if (T8.p15On == true && Player.GetModPlayer<MyPlayer>().lostLife > 0)
            {
                Player.GetModPlayer<MyPlayer>().lostLifeRegen = proj.damage / 50;
                if (Player.GetModPlayer<MyPlayer>().lostLifeRegen > 10)
                {
                    Player.GetModPlayer<MyPlayer>().lostLifeRegen = 10;
                }
                Player.GetModPlayer<MyPlayer>().lostLife -= Player.GetModPlayer<MyPlayer>().lostLifeRegen;
                if (Player.GetModPlayer<MyPlayer>().lostLife < 0)
                {
                    Player.GetModPlayer<MyPlayer>().lostLife = 0;
                }
                Player.statLife += Player.GetModPlayer<MyPlayer>().lostLifeRegen;
                if (Player.statLife > Player.statLifeMax2)
                {
                    Player.statLife = Player.statLifeMax2;
                }
            }

            if (HeartSynthesizer)
            {
                if (Main.rand.NextBool(150)) // Player.HeldItem.shootSpeed
                {
                    Item.NewItem(proj.GetSource_FromThis(), target.getRect(), ItemID.Heart);

                }
            }
            Vector2 perturbedSpeed = new Vector2(0, -6).RotatedByRandom(MathHelper.ToRadians(360));
            if (Player.HeldItem.type == ModContent.ItemType<OperationOutbreak>() && target.life <= 0 && proj.type != ModContent.ProjectileType<LightningGunProj3>())
            {
                Projectile.NewProjectile(proj.GetSource_FromAI(), new Vector2(proj.Center.X, proj.Center.Y), new Vector2(perturbedSpeed.X, perturbedSpeed.Y), ModContent.ProjectileType<LightningGunProj3>(), proj.damage * 4, 0, proj.owner);
            }
            if (Player.HeldItem.type == ModContent.ItemType<OperationOutbreak>() && proj.type != ModContent.ProjectileType<LightningGunProj3>())
            {
                fired++;
                if (fired == 3)
                {
                    Projectile.NewProjectile(proj.GetSource_FromAI(), new Vector2(proj.Center.X, proj.Center.Y), new Vector2(perturbedSpeed.X, perturbedSpeed.Y), ModContent.ProjectileType<LightningGunProj3>(), proj.damage * 4, 0, proj.owner);
                    fired = 0;

                }
            }
        }
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (Glass)
            {
                Player.immuneTime = Glasstime;
            }
            else base.ModifyHurt(ref modifiers);
        }
        public override void ModifyHitByProjectile(Projectile proj, ref Player.HurtModifiers modifiers)
        {
            if (T1.p5On == true)
            {
                Player.statMana += (int)(proj.damage * 0.25);
            }
            if (T8.p13On == true && Player.GetModPlayer<MyPlayer>().blocking == true)
            {
                if (Player.HeldItem.DamageType == DamageClass.Melee && Player.HeldItem.damage / 4 >= proj.damage / 2)
                {
                    proj.damage /= 2;
                }
                if (Player.HeldItem.DamageType == DamageClass.Melee && Player.HeldItem.damage / 4 < proj.damage / 2)
                {
                    proj.damage -= Player.HeldItem.damage / 4;
                }
            }
        }
        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            if (T8.p13On == true && Player.GetModPlayer<MyPlayer>().blocking == true)
            {
                if (Player.HeldItem.DamageType == DamageClass.Melee && Player.HeldItem.damage / 2 >= npc.damage * 0.75)
                {
                    npc.damage /= 4;
                }
                if (Player.HeldItem.DamageType == DamageClass.Melee && Player.HeldItem.damage / 2 < npc.damage * 0.75)
                {
                    npc.damage -= Player.HeldItem.damage / 2;
                }
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
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (T6.p32On == true && proj.DamageType == DamageClass.Summon)
            {
                if (Main.rand.NextFloat() >= 0.9)
                    proj.damage += (int)(proj.damage * 0.5f);
            }

            if (T6.p36On == true && proj.DamageType == DamageClass.Summon)
            {
                target.GetGlobalNPC<MyNpc>().minionMark += 1;
                if (target.GetGlobalNPC<MyNpc>().minionMark >= 4)
                {
                    proj.damage += (int)(proj.damage * 0.5f);
                    target.GetGlobalNPC<MyNpc>().minionMark = 0;
                }
            }
            if(America && proj.DamageType == DamageClass.Ranged)
            {
                modifiers.CritDamage *= 1.25f;
            }
        }
        /*public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
         {
             if (SilverBullets && proj.CountsAsClass(DamageClass.Ranged))
             {
                 if (target.boss)
                 {
                     modifiers.FinalDamage *= 0.5; 
                 }
                 else
                 {
                     damage /= 2;
                 }
             }
         }
         */
    }
}
