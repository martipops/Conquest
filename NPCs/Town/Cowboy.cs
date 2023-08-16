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
using Conquest.Items.Consumable.Alcohol;
using Conquest.Items.Weapons.Ranged;
using Conquest.Items.Accessory;

namespace Conquest.NPCs.Town
{
    [AutoloadHead]

    public class Cowboy : ModNPC
    {
        private static Profiles.StackedNPCProfile NPCProfile;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cowboy");
            Main.npcFrameCount[Type] = 21;
            NPCID.Sets.ExtraFramesCount[Type] = 9;

            NPCID.Sets.HatOffsetY[Type] = 4;

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = 1

            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party")
            );

        }
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
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,

                new FlavorTextBestiaryInfoElement("Yeehaw"),


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
            return NPC.downedBoss1;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Billy",
                "Cassidy",
                "James",
                "Rodriguez"
            };
        }
        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.NextBool(4))
            {
                chat.Add(Language.GetTextValue("Not my kind of party."));
            }
            chat.Add(Language.GetTextValue("Howdy!"));




            return chat;
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            Main.LocalPlayer.currentShoppingSettings.HappinessReport = "";

        }
        public const string ShopName = "Shop";
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName;
            }
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add<Fireball>()
                .Add<WildWestCocktail>()
                .Add<PigsEar>()
                .Add<RyeWhiskey>()
                .Add<Moonshine>()
                .Add<CalobogusAle>()
                .Add<ShotRevolver>()
                .Add<TommyGun>()
                .Add<AK47u>()
                .Add<Murica>(Condition.Hardmode);

            npcShop.Register();
        }
        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }
    }
}

