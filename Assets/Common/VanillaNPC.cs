using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Assets.Common
{
    public class VanillaNPC : GlobalNPC
    {
        
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.DyeTrader)
            {
                shop.Add(ItemID.DyeTradersScimitar);
            }
            if (shop.NpcType == NPCID.Painter)
            {
                shop.Add(ItemID.PainterPaintballGun);
            }
            if (shop.NpcType == NPCID.Stylist)
            {
                shop.Add(ItemID.StylistKilLaKillScissorsIWish);
            }
            if (shop.NpcType == NPCID.Mechanic)
            {
                shop.Add(ItemID.CombatWrench);
            }
            if (shop.NpcType == NPCID.Princess)
            {
                shop.Add(ItemID.PrincessWeapon);
            }
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {

            if (npc.type == NPCID.Pixie || npc.type == NPCID.Unicorn || npc.type == NPCID.Gastropod || npc.type == NPCID.LightMummy)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SoulofLight, 20));
            }
            if (npc.type == NPCID.RainbowSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SoulofLight, 1, 3, 3));
            }
            if (npc.type == NPCID.QueenSlimeBoss)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SoulofLight, 1, 5, 15));
            }
            if (npc.type == NPCID.Herpling || npc.type == NPCID.Crimslime || npc.type == NPCID.BloodJelly || npc.type == NPCID.BloodFeeder || npc.type == NPCID.BloodMummy || npc.type == NPCID.Corruptor || npc.type == NPCID.CorruptSlime || npc.type == NPCID.Slimer2 || npc.type == NPCID.DarkMummy)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SoulofNight, 20));
            }
        }
    }
}
