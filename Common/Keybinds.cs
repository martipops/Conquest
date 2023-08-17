using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Conquest.Assets.Common
{
    public class Keybinds : ModSystem
    {
        public static ModKeybind CursedTrident { get; private set; }
        public static ModKeybind HunnyPot { get; private set; }
        public static ModKeybind Legendary { get; private set; }
        public static ModKeybind Reload { get; private set; }


        public override void Load()
        {
            CursedTrident = KeybindLoader.RegisterKeybind(Mod, "Cursed Trident Activation", "P");
            HunnyPot = KeybindLoader.RegisterKeybind(Mod, "Hunny Pot Activation", "J");
            Legendary = KeybindLoader.RegisterKeybind(Mod, "Legendary Armament Activation", "K");
            Reload = KeybindLoader.RegisterKeybind(Mod, "Reload Weapon", "R");
        }
        public override void Unload()
        {
            CursedTrident = null;
            HunnyPot = null;
            Legendary = null;
            Reload = null;
        }
    }
}
