using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ModLoader.UI.Elements;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;

namespace Conquest.Dusts
{
    internal class Wind : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.alpha = 127;
            dust.frame = new Rectangle(0, 0, 24, 10);
        }

        private int frameCounter = 0;
        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;

            if (++frameCounter >= 5)
            {
                frameCounter = 0;
                dust.frame.Y += 10;
                if (dust.frame.Y > 40)
                {
                    dust.active = false;
                }
            }


            return true;
        }
    }
}
