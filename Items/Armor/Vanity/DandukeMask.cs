using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace Conquest.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    internal class DandukeMask : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;

            Item.rare = ItemRarityID.Blue;
            Item.value = 75000;
            Item.vanity = true;
            Item.maxStack = 1;
        }
    }
}
