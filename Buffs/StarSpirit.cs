using Assortedarmaments.Projectiles;
using Conquest.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Buffs.Minion
{
    public class StarSpirit : ModBuff
    {
            public override void SetStaticDefaults()
            {
                Main.buffNoSave[Type] = true;
                Main.buffNoTimeDisplay[Type] = true;
            }

            public override void Update(Player player, ref int buffIndex)
            {
                if (player.ownedProjectileCounts[ModContent.ProjectileType<SupportStar>()] > 0)
                {
                    player.buffTime[buffIndex] = 18000;
                }
                else
                {
                    player.DelBuff(buffIndex);
                    buffIndex--;
                }
            bool unused = false;
            player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<SupportStar>());
        }

    }
}
