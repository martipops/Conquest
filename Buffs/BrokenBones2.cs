using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Buffs
{
    public class BrokenBones2 : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Broken Bones!");
            // Description.SetDefault("0 Defense\nNo Life Regen\n+50% Damage");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += 0.50f;
            player.lifeRegenTime = 0;
        }

    }
}

