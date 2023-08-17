
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Assets.Common
{
    public class ArtifactSlot : ModAccessorySlot
    {
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override bool IsEnabled()
        {
            return true;
        }
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            return checkItem.rare == ModContent.RarityType<ArtifactRarity>();
        }
        public override void OnMouseHover(AccessorySlotType context)
        {
            Main.hoverItemName = "Artifact Slot";
        }
    }
}
