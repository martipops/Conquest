using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Dusts
{
    public class LightningDust : ModDust
    {
        public override void SetStaticDefaults()
        {
            Dust.CloneDust(DustID.Electric);
        }

    }
}
