using Conquest.Assets.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Utilities;

namespace Conquest.NPCs.Bosses.Danduke
{
    public class Dande : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("悠闲的蒲公英");
            NPC.Happiness
            .SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            TownNPCStayingHomeless = true;
            NPC.lifeMax = 3300;
            NPC.friendly = true;
            NPC.width = 30;
            NPC.height = 38;
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            if (DownedBossSystem.DownedDuke)
            {
                chat.Add("Hello friend...");
            }
            else
            {
                chat.Add("Hello stranger...");
            }

            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Challenge?";
            if (DownedBossSystem.DownedDuke)
            {
                button = "Rematch?";
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                    Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                    Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                    Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                    Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                    Terraria.Dust.NewDust(NPC.position, 30, 38, DustID.AncientLight, 0, 0, 0, Color.White);
                    NPC.SpawnBoss((int)(NPC.Center.X), (int)(NPC.Center.Y), ModContent.NPCType<DandukeBoss>(), Main.LocalPlayer.whoAmI);
                    NPC.life = 0;
                    return;
                
            }
        }

        public override void AI()
        {
            NPC.immuneTime = 60;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            return false;
        }
    }
}
