using Conquest.Items.Materials;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Conquest.Items.Potions
{   //        public override bool InstancePerEntity => true;

    public class PermPotions : ModPlayer
    {
        public static bool PermSpelunker;
        public static bool PermInvis;
        public static bool PermObsidian;
        public static bool PermRegen;
        public static bool PermSwift;
        public static bool PermGills;
        public static bool PermIronskin;
        public static bool PermManaRegen;
        public static bool PermMagicPower;
        public static bool PermFeather;
        public static bool PermShine;
        public static bool PermNightOwl;
        public static bool PermBattle;
        public static bool PermThorns;
        public static bool PermWater;
        public static bool PermArchery;
        public static bool PermHunter;
        public static bool PermGrav;
        public static bool PermAle;
        public static bool PermMining;
        public static bool PermHeart;
        public static bool PermCalm;
        public static bool PermBuilder;
        public static bool PermTitan;
        public static bool PermFlipper;
        public static bool PermSummoning;
        public static bool PermDanger;
        public static bool PermAmmo;
        public static bool PermLifeforce;
        public static bool PermEndurance;
        public static bool PermRage;
        public static bool PermInferno;
        public static bool PermWrath;
        public static bool PermFish;
        public static bool PermSonar;
        public static bool PermCrate;
        public static bool PermWarmth;
        public override void SaveData(TagCompound tag)
        {
            if (PermSpelunker)
            {
                tag.Add("Spelunker", PermPotions.PermSpelunker);
            }
            if (PermInvis)
            {
                tag.Add("PermInvis", PermPotions.PermInvis);

            }
            if (PermObsidian)
            {
                tag.Add("PermObsidian", PermPotions.PermObsidian);

            }
            if (PermRegen)
            {
                tag.Add("Regen", PermPotions.PermRegen);
            }
            if (PermSwift)
            {
                tag.Add("Swift", PermPotions.PermSwift);
            }
            if (PermGills)
            {
                tag.Add("Gills", PermPotions.PermGills);
            }
            if (PermIronskin)
            {
                tag.Add("Iron", PermPotions.PermIronskin);
            }
            if (PermManaRegen)
            {
                tag.Add("ManaRegen", PermPotions.PermManaRegen);
            }
            if (PermMagicPower)
            {
                tag.Add("MagicPower", PermPotions.PermMagicPower);
            }
            if (PermFeather)
            {
                tag.Add("Feather", PermPotions.PermFeather);
            }
            if (PermShine)
            {
                tag.Add("Shine", PermPotions.PermShine);
            }
            if (PermNightOwl)
            {
                tag.Add("Owl", PermPotions.PermNightOwl);
            }
            if (PermBattle)
            {
                tag.Add("Battle", PermPotions.PermBattle);
            }
            if (PermThorns)
            {
                tag.Add("Thorns", PermPotions.PermThorns);
            }
            if (PermWater)
            {
                tag.Add("Water", PermPotions.PermWater);
            }
            if (PermArchery)
            {
                tag.Add("Archery", PermPotions.PermArchery);
            }
            if (PermHunter)
            {
                tag.Add("Hunter", PermPotions.PermHunter);
            }
            if (PermGrav)
            {
                tag.Add("Gravity", PermPotions.PermGrav);
            }
            if (PermAle)
            {
                tag.Add("Ale", PermPotions.PermAle);
            }
            if (PermMining)
            {
                tag.Add("Mining", PermPotions.PermMining);
            }
            if (PermHeart)
            {
                tag.Add("Heartreach", PermPotions.PermHeart);
            }
            if (PermCalm)
            {
                tag.Add("Calming", PermPotions.PermCalm);
            }
            if (PermBuilder)
            {
                tag.Add("Builder", PermPotions.PermBuilder);
            }
            if (PermTitan)
            {
                tag.Add("Titan", PermPotions.PermTitan);
            }
            if (PermFlipper)
            {
                tag.Add("Flipper", PermPotions.PermFlipper);
            }
            if (PermSummoning)
            {
                tag.Add("Summoning", PermPotions.PermSummoning);
            }
            if (PermDanger)
            {
                tag.Add("Danger", PermPotions.PermDanger);
            }
            if (PermAmmo)
            {
                tag.Add("Ammo", PermPotions.PermAmmo);
            }
            if (PermLifeforce)
            {
                tag.Add("Lifeforce", PermPotions.PermLifeforce);
            }
            if (PermEndurance)
            {
                tag.Add("Endurance", PermPotions.PermEndurance);
            }
            if (PermRage)
            {
                tag.Add("Rage", PermPotions.PermRage);
            }
            if (PermInferno)
            {
                tag.Add("Inferno", PermPotions.PermInferno);
            }
            if (PermWrath)
            {
                tag.Add("Wrath", PermPotions.PermWrath);
            }
            if (PermFish)
            {
                tag.Add("Fishin", PermPotions.PermFish);
            }
            if (PermSonar)
            {
                tag.Add("Sonar", PermPotions.PermSonar);
            }
            if (PermCrate)
            {
                tag.Add("Crate", PermPotions.PermCrate);
            }
            if (PermWarmth)
            {
                tag.Add("warm", PermPotions.PermWarmth);
            }
        }
        public override void LoadData(TagCompound tag)
        {
            PermSpelunker = tag.GetBool("Spelunker");
            PermInvis = tag.GetBool("PermInvis");
            PermObsidian = tag.GetBool("PermObsidian");
            PermRegen = tag.GetBool("Regen");
            PermSwift = tag.GetBool("Swift");
            PermGills = tag.GetBool("Gills");
            PermIronskin = tag.GetBool("Iron");
            PermManaRegen = tag.GetBool("ManaRegen");
            PermMagicPower = tag.GetBool("MagicPower");
            PermFeather = tag.GetBool("Feather");
            PermShine = tag.GetBool("Shine");
            PermNightOwl = tag.GetBool("Owl");
            PermBattle = tag.GetBool("Battle");
            PermWater = tag.GetBool("Water");
            PermArchery = tag.GetBool("Archery");
            PermThorns = tag.GetBool("Thorns");
            PermHunter = tag.GetBool("Hunter");
            PermGrav = tag.GetBool("Gravity");
            PermAle = tag.GetBool("Ale");
            PermMining = tag.GetBool("Mining");
            PermHeart = tag.GetBool("Heartreach");
            PermCalm = tag.GetBool("Calming");
            PermTitan = tag.GetBool("Titan");
            PermFlipper = tag.GetBool("Flipper");
            PermSummoning = tag.GetBool("Summoning");
            PermDanger = tag.GetBool("Danger");
            PermAmmo = tag.GetBool("Ammo");
            PermLifeforce = tag.GetBool("Lifeforce");
            PermEndurance = tag.GetBool("Endurance");
            PermRage = tag.GetBool("Rage");
            PermInferno = tag.GetBool("Inferno");
            PermWrath = tag.GetBool("Wrath");
            PermFish = tag.GetBool("Fishin");
            PermSonar = tag.GetBool("Sonar");
            PermCrate = tag.GetBool("Crate");
            PermWarmth = tag.GetBool("warm");

        }
        public override void ResetEffects()
        {
            if (PermSpelunker)
            {
                Player.findTreasure = true;
            }
            if (PermInvis)
            {
                Player.invis = true;
            }
            if (PermGills)
            {
                Player.gills = true;
            }
            if (PermObsidian)
            {
                Player.lavaImmune = true;
                Player.fireWalk = true;
                Player.buffImmune[BuffID.OnFire] = true;
            }
            if (PermFeather)
            {
                Player.slowFall = true;

            }
            if (PermShine)
            {
                Lighting.AddLight((int)(Player.Center.X / 16), (int)(Player.Center.Y / 16), 0.8f, 0.95f, 1f);

            }
            if (PermManaRegen)
            {
                Player.manaRegenBuff = true;
            }
            if (PermNightOwl)
            {
                Player.nightVision = true;
            }
            if (PermBattle)
            {
                Player.enemySpawns = true;
            }
            if (PermWater)
            {
                Player.waterWalk = true;
            }
            if (PermThorns)
            {
                if (Player.thorns < 1f)
                {
                    Player.thorns = 1f;
                }
            }
            if (PermHunter)
            {
                Player.detectCreature = true;
            }
            if (PermGrav)
            {
                Player.gravControl = true;
            }
            if (PermMining)
            {
                Player.pickSpeed -= 0.25f;
            }
            if (PermHeart)
            {
                Player.lifeMagnet = true;
            }
            if (PermCalm)
            {
                Player.calmed = true;
            }
            if (PermBuilder)
            {
                Player.tileSpeed += 0.25f;
                Player.wallSpeed += 0.25f;
                Player.blockRange++;
            }
            if (PermTitan)
            {
                Player.kbBuff = true;
            }
            if (PermFlipper)
            {
                Player.accFlipper = true;
                Player.ignoreWater = true;
            }
            if (PermDanger)
            {
                Player.dangerSense = true;
            }
            if (PermAmmo)
            {
                Player.ammoPotion = true;
            }
            if (PermLifeforce)
            {
                Player.lifeForce = true;
                Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 20;
            }
            if (PermEndurance)
            {
                Player.endurance += 0.1f;
            }
            if (PermInferno)
            {
                Player.inferno = true;
                Lighting.AddLight((int)(Player.Center.X / 16f), (int)(Player.Center.Y / 16f), 0.65f, 0.4f, 0.1f);
                int num = 24;
                float num12 = 200f;
                bool flag = Player.infernoCounter % 60 == 0;
                int damage = 10;
                if (Player.whoAmI == Main.myPlayer)
                {
                    for (int l = 0; l < 200; l++)
                    {
                        NPC nPC = Main.npc[l];
                        if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && !nPC.buffImmune[num] && Vector2.Distance(Player.Center, nPC.Center) <= num12)
                        {
                            if (nPC.FindBuffIndex(num) == -1)
                            {
                                nPC.AddBuff(num, 120);
                            }
                            if (flag)
                            {
                                Player.ApplyDamageToNPC(nPC, damage, 0f, 0, crit: false);
                            }
                        }
                    }
                }
            }
            if (PermFish)
            {
                Player.fishingSkill += 15;
            }
            if (PermSonar)
            {
                Player.sonarPotion = true; 
            }
            if (PermCrate)
            {
                Player.cratePotion = true;
            }
            if (PermWarmth)
            {
                Player.resistCold = true;
            }
        }
        
        public override void PostUpdate()
        {
            if (PermIronskin)
            {
                Player.statDefense += 8;
            }
            if (PermAle)
            {
                Player.statDefense -= 4;
            }
        }
        public override void PostUpdateEquips()
        {
            if (PermSummoning)
            {
                Player.maxMinions += 1;
            }
        }
        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (PermMagicPower)
            {
                Player.GetDamage(DamageClass.Magic) += 0.2f;
            }
            if (PermArchery)
            {
                Player.archery = true;
                Player.arrowDamage *= 1.1f;
            }
            if (PermAle)
            {
                Player.GetDamage(DamageClass.Melee) += 0.1f;
                Player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
                Player.GetDamage(DamageClass.SummonMeleeSpeed) += 0.1f;
            }
            if (PermWrath)
            {
                Player.GetDamage(DamageClass.Generic) += 0.1f;
            }
        }
        public override void ModifyWeaponCrit(Item item, ref float crit)
        {
            if (PermAle)
            {
                Player.GetCritChance(DamageClass.Melee) += 2;
            }
            if (PermRage)
            {
                Player.GetCritChance(DamageClass.Generic) += 10;
            }
        }
        public override void UpdateLifeRegen()
        {
            if (PermRegen)
            {
                Player.lifeRegen += 4;
            }
        }
        public override void PostUpdateRunSpeeds()
        {
            if (PermSwift)
            {
                Player.moveSpeed += 0.25f;
            }
        }
    }
    public class PermanentObsidianSkinPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_288";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermObsidian)
            {
                PermPotions.PermObsidian = false;
            }
            else
            {
                PermPotions.PermObsidian = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.ObsidianSkinPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }

    }
    public class PermanentRegenerationPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_289";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermRegen)
            {
                PermPotions.PermRegen = false;
            }
            else
            {
                PermPotions.PermRegen = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.RegenerationPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }

    }
    public class PermanentSwiftnessPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_290";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermSwift)
            {
                PermPotions.PermSwift = false;
            }
            else
            {
                PermPotions.PermSwift = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.SwiftnessPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }

    }
    public class PermanentGillsPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_291";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermGills)
            {
                PermPotions.PermGills = false;
            }
            else
            {
                PermPotions.PermGills = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.GillsPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentIronskinPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_292";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermIronskin)
            {
                PermPotions.PermIronskin = false;
            }
            else
            {
                PermPotions.PermIronskin = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.IronskinPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }

    }
    public class PermanentManaRegenerationPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_293";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermManaRegen)
            {
                PermPotions.PermManaRegen = false;
            }
            else
            {
                PermPotions.PermManaRegen = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.ManaRegenerationPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }

    }
    public class PermanentMagicPowerPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_294";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermMagicPower)
            {
                PermPotions.PermMagicPower = false;
            }
            else
            {
                PermPotions.PermMagicPower = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.MagicPowerPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }

    }
    public class PermanentFeatherfallPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_295";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermFeather)
            {
                PermPotions.PermFeather = false;
            }
            else
            {
                PermPotions.PermFeather = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.FeatherfallPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }

    }
    public class PermanentSpelunkerPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_296";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;
            
        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermSpelunker)
            {
                PermPotions.PermSpelunker = false;
            }
            else
            {
                PermPotions.PermSpelunker = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
           CreateRecipe()
          .AddIngredient(ItemID.SpelunkerPotion, 30)
          .AddTile(TileID.TinkerersWorkbench)
          .Register();

        }
      
    }
    public class PermanentInvisibilityPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_297";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermInvis)
            {
                PermPotions.PermInvis = false;
            }
            else
            {
                PermPotions.PermInvis = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.InvisibilityPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }

    }
    public class PermanentShinePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_298";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermShine)
            {
                PermPotions.PermShine = false;
            }
            else
            {
                PermPotions.PermShine = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.ShinePotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }

    }
    public class PermanentNightOwlPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_299";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermNightOwl)
            {
                PermPotions.PermNightOwl = false;
            }
            else
            {
                PermPotions.PermNightOwl = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.NightOwlPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentBattlePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_300";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermBattle)
            {
                PermPotions.PermBattle = false;
            }
            else
            {
                PermPotions.PermBattle = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.BattlePotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentThornsPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_301";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermThorns)
            {
                PermPotions.PermThorns = false;
            }
            else
            {
                PermPotions.PermThorns = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.ThornsPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentWaterWalkingPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_302";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermWater)
            {
                PermPotions.PermWater = false;
            }
            else
            {
                PermPotions.PermWater = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.WaterWalkingPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentArcheryPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_303";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermArchery)
            {
                PermPotions.PermArchery = false;
            }
            else
            {
                PermPotions.PermArchery = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.ArcheryPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentHunterPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_304";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermHunter)
            {
                PermPotions.PermHunter = false;
            }
            else
            {
                PermPotions.PermHunter = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.HunterPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentGravitationPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_305";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermGrav)
            {
                PermPotions.PermGrav = false;
            }
            else
            {
                PermPotions.PermGrav = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.GravitationPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentMiningPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2322";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermMining)
            {
                PermPotions.PermMining = false;
            }
            else
            {
                PermPotions.PermMining = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.MiningPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentHeartreachPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2323";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermHeart)
            {
                PermPotions.PermHeart = false;
            }
            else
            {
                PermPotions.PermHeart = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.HeartreachPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentCalmingPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2324";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermCalm)
            {
                PermPotions.PermCalm = false;
            }
            else
            {
                PermPotions.PermCalm = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.CalmingPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentBuilderPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2325";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermBuilder)
            {
                PermPotions.PermBuilder = false;
            }
            else
            {
                PermPotions.PermBuilder = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.BuilderPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentTitanPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2326";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermTitan)
            {
                PermPotions.PermTitan = false;
            }
            else
            {
                PermPotions.PermTitan = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.TitanPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentFlipperPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2327";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermFlipper)
            {
                PermPotions.PermFlipper = false;
            }
            else
            {
                PermPotions.PermFlipper = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.FlipperPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentSummoningPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2328";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermSummoning)
            {
                PermPotions.PermSummoning = false;
            }
            else
            {
                PermPotions.PermSummoning = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.SummoningPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentDangersensePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2329";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermDanger)
            {
                PermPotions.PermDanger = false;
            }
            else
            {
                PermPotions.PermDanger = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.TrapsightPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentAmmoReservationPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2344";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermAmmo)
            {
                PermPotions.PermAmmo = false;
            }
            else
            {
                PermPotions.PermAmmo = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.AmmoReservationPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentLifeforcePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2345";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermLifeforce)
            {
                PermPotions.PermLifeforce = false;
            }
            else
            {
                PermPotions.PermLifeforce = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.LifeforcePotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentEndurancePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2346";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermEndurance)
            {
                PermPotions.PermEndurance = false;
            }
            else
            {
                PermPotions.PermEndurance = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.EndurancePotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();
        }
    }
    public class PermanentRagePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2347";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermRage)
            {
                PermPotions.PermRage = false;
            }
            else
            {
                PermPotions.PermRage = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.RagePotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();
        }
    }
    public class PermanentInfernoPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2348";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermInferno)
            {
                PermPotions.PermInferno = false;
            }
            else
            {
                PermPotions.PermInferno = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.InfernoPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();
        }
    }
    public class PermanentAle : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermAle)
            {
                PermPotions.PermAle = false;
            }
            else
            {
                PermPotions.PermAle = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.Ale, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentWrathPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2349";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermWrath)
            {
                PermPotions.PermWrath = false;
            }
            else
            {
                PermPotions.PermWrath = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.WrathPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentFishingPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2354";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermFish)
            {
                PermPotions.PermFish = false;
            }
            else
            {
                PermPotions.PermFish = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.FishingPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentSonarPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2355";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermSonar)
            {
                PermPotions.PermSonar = false;
            }
            else
            {
                PermPotions.PermSonar = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.SonarPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentCratePotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2356";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermCrate)
            {
                PermPotions.PermCrate = false;
            }
            else
            {
                PermPotions.PermCrate = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.CratePotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
    public class PermanentWarmthPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_2359";
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 26;

        }
        public override bool? UseItem(Player player)
        {
            if (PermPotions.PermWarmth)
            {
                PermPotions.PermWarmth = false;
            }
            else
            {
                PermPotions.PermWarmth = true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.WarmthPotion, 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

        }
    }
}
