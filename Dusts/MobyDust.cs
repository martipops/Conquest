using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Dusts
{
    public class MobyDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true; // Makes the dust have no gravity.
            dust.noLight = true;

        }
    }
}
