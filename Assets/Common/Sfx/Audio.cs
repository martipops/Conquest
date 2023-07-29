using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;

namespace Conquest.Assets.Common.Sfx
{
    public class Audio : ModSystem
    {
        public static readonly SoundStyle PrimeGun;

        public static readonly SoundStyle Overheat;
        static Audio()
        {
            PrimeGun = new SoundStyle("Conquest/Assets/Common/Sfx/PrimeGun", (SoundType)0);

            Overheat = new SoundStyle("Conquest/Assets/Common/Sfx/Overheat", (SoundType)0);
        }
    }
}
