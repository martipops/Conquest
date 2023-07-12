using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Buffs
{
    public class HunnySickness : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hunny Sickness");
            // Description.SetDefault("");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
        }

    }
}

