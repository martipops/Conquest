using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using System.Linq;
using Conquest.Items.Vanity.DevCoat;
using Conquest.Items.Vanity.Kobold;

namespace Conquest.NPCs.Town
{
    [AutoloadHead]
    public class KoboldMerchant : ModNPC
    {

        private static Profiles.StackedNPCProfile NPCProfile;
        public override void SetStaticDefaults()
        {
			Main.npcFrameCount[Type] = 25;
            NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs. This is the remaining frames after the walking frames.
			NPCID.Sets.AttackFrameCount[Type] = 4; // The amount of frames in the attacking animation.
			NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the NPC that it tries to attack enemies.
			NPCID.Sets.AttackType[Type] = 0; // The type of attack the Town NPC performs. 0 = throwing, 1 = shooting, 2 = magic, 3 = melee
			NPCID.Sets.AttackTime[Type] = 15; // The amount of time it takes for the NPC's attack animation to be over once it starts.
			NPCID.Sets.AttackAverageChance[Type] = 1; // The denominator for the chance for a Town NPC to attack. Lower numbers make the Town NPC appear more aggressive.
			NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.
			NPCID.Sets.ShimmerTownTransform[NPC.type] = false;
            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = 1 
                          
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
			
			NPC.Happiness
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Love) // Example Person prefers the forest.
				.SetNPCAffection(NPCID.Cyborg, AffectionLevel.Love);

            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party")
            );

        }
		int atkCool = 60;
        public override void SetDefaults()
        {
            NPC.townNPC = true; 
            NPC.friendly = true; 
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 30;
            NPC.lifeMax = 400;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.8f;

            AnimationType = NPCID.Guide;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard,
				new FlavorTextBestiaryInfoElement("Lomi sells the best vanity items around!"),
            });
        }
      
        public override void HitEffect(NPC.HitInfo hit)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SteampunkSteam);
            }
        }
     
        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            return true;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Lomi",
				"Lomi"
            };
        }
        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add(Language.GetTextValue("Hi there!"));
			chat.Add(Language.GetTextValue("Queen's blessings!"));
			chat.Add(Language.GetTextValue("Hey, my eyes are down here!"));
			chat.Add(Language.GetTextValue("Wanna take a look at my wares?"));
			chat.Add(Language.GetTextValue("Mmm? Oh yes, my shop."));
			chat.Add(Language.GetTextValue("...And that's when I stabbed her, hah!"));
			chat.Add(Language.GetTextValue("...Hello! Here to spend, I hope."));
			//chat.Add(Language.GetTextValue("...Sometimes it feels like others can read my mind."));
			
            //int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            return chat;
        }
		public override bool CanGoToStatue(bool toKingStatue) => !toKingStatue;
		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 0;
			if (atkCool == 0)
			{
				atkCool = 30;
				NPC nearest = null;
				float oldDist = 1001;
				float newDist = 1000;
				for (int i = 0; i < Terraria.Main.npc.Length - 1; i++) //Do once for each NPC in the world
				{
					if (Terraria.Main.npc[i].friendly == true)//Don't target town NPCs
						continue;
					if (Terraria.Main.npc[i].active == false)//Don't target dead NPCs
						continue;
					if (Terraria.Main.npc[i].damage == 0)//Don't target non-aggressive NPCs
						continue;
					if (nearest == null) //if no NPCs have made it past the previous few checks
					nearest = Terraria.Main.npc[i]; //become the nearest NPC
					else
					{
						oldDist = Vector2.Distance(NPC.Center, nearest.Center);//Check the distance to the nearest NPC that's earlier in the loop
						newDist = Vector2.Distance(NPC.Center, Terraria.Main.npc[i].Center);//Check the distance to the current NPC in the loop
						if (newDist < oldDist)//If closer than the previous NPC in the loop
						nearest = Terraria.Main.npc[i];//Become the nearest NPC
					}
				}
				int player = 0;
				for (player = 0; player < Main.player.Length; player++)
				{
					if (Main.player[player] == Main.LocalPlayer)
						break;
				}
				
				Projectile proj = Projectile.NewProjectileDirect(new EntitySource_Parent(NPC), 
				NPC.Center, (new Vector2(NPC.Center.X-nearest.Center.X,NPC.Center.Y-nearest.Center.Y))/-40f, 964, 120, 0, NPC.whoAmI);
				proj.friendly = true;
				proj.hostile = false;
				proj.rotation = Main.rand.NextFloat(6.28318f);
				proj.direction = NPC.direction;
				proj.timeLeft = 600;
				proj.owner = player;
				proj.timeLeft = 300;
			}
			else
			{
				atkCool--;
			}
			attackDelay = 30;
		}
		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 10;
			knockback = 4f;
		}
		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 0;
			randExtraCooldown = 0;
		}
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            Main.LocalPlayer.currentShoppingSettings.HappinessReport = "";

        }
        public const string ShopName = "Lomi's Wares";
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName;
            }
			else
			{
			
			}
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add<DevContainer>()
                .Add<KoboldGem>();
                
            npcShop.Register();
        }
        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }


    }

}