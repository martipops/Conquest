
using Conquest.Items.Accessory;
using Conquest.Items.Weapons.Magic;
using Conquest.Items.Weapons.Melee;
using Conquest.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Conquest.Assets.Common
{
    public class MyItem : GlobalItem
    {
      
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {

            if (item.type == ItemID.EaterOfWorldsBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CorruptedJoustingLance>(), 4));

            }
            if (item.type == ItemID.EyeOfCthulhuBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<OccularRepeater>(), 4));

            }
            if (item.type == ItemID.QueenBeeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HunnyPot>(), 5));

            }
            if (item.type == ItemID.SkeletronPrimeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Polyute>(), 15));

            }
            if (item.type == ItemID.TwinsBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Polyute>(), 15));

            }
            if (item.type == ItemID.PlanteraBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Breakneck>(), 15));

            }
            if (item.type == ItemID.DestroyerBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Polyute>(), 15));

            }
            if (item.type == ItemID.QueenSlimeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Infinity>(), 10));

            }
            if (item.type == ItemID.EyeOfCthulhuBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DiplopiaItem>(), 10));

            }
            if (item.type == ItemID.BrainOfCthulhuBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Brainstalks>(), 10));

            }
         
            if (item.type == ItemID.SkeletronBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrittleBones>(), 10));

            }
            if (item.type == ItemID.WallOfFleshBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedT>(), 10));
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EternalFlames>(), 5));

            }
            if (item.type == ItemID.QueenSlimeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ItemID.SoulofLight, 1, 5, 15));
            }
        }
       
      
    }
    
}

