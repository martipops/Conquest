using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;


namespace Conquest.Items.Vanity.Kobold
{
    public class KoboldGem : ModItem
    {
        public override void Load()
        {
            if (Main.netMode == NetmodeID.Server)
                return;
            EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Head}", EquipType.Head, this, equipTexture: new KoboldHead());
            EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Body}", EquipType.Body, this);
            EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);


        }
        public override void SetStaticDefaults()
        {
            if (Main.netMode == NetmodeID.Server)
                return;

            int equipSlotHead = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head);
            int equipSlotBody = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
            int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);

            ArmorIDs.Head.Sets.DrawHead[equipSlotHead] = false;
            ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
            ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
            ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 20;
            Item.accessory = true;
            Item.value = 10000000;
            Item.rare = ItemRarityID.Expert;
            Item.hasVanityEffects = true;
        }

        public override void UpdateVanity(Player player)
        {
            player.GetModPlayer<KoboldEffects>().KoboldVisuals = true;
        }
    }

    public class KoboldHead : EquipTexture
    {
        public override bool IsVanitySet(int head, int body, int legs) => true;

        public override void UpdateVanitySet(Player player)
        {

        }
    }

    internal class KoboldEffects : ModPlayer
    {
        internal bool KoboldVisuals;
        public override void ResetEffects()
        {
            KoboldVisuals = false;
        }

        public override void FrameEffects()
        {
            if (KoboldVisuals)
            {

                var gem = ModContent.GetInstance<KoboldGem>();
                Player.head = EquipLoader.GetEquipSlot(Mod, gem.Name, EquipType.Head);
                Player.body = EquipLoader.GetEquipSlot(Mod, gem.Name, EquipType.Body);
                Player.legs = EquipLoader.GetEquipSlot(Mod, gem.Name, EquipType.Legs);
                Player.handon = -1;
                Player.handoff = -1;
                Player.front = -1;
                Player.neck = -1;
                Player.faceFlower = -1;
                Player.faceHead = -1;
                Player.shoe = -1;
                Player.tail = -1;
                Player.waist = -1;
                Player.back = -1;
                Player.backpack = -1;
                Player.balloon = -1;
                Player.balloonFront = -1;
                Player.beard = -1;

            }
        }
    }
}