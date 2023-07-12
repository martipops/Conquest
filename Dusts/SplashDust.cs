using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Conquest.Dusts
{
    public class SplashDust : ModDust
    {
        public override void SetStaticDefaults()
        {
            UpdateType = 110;
        }
    }
}
