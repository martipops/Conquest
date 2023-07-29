using Conquest.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Buffs
{ 
    public class Electrified : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;  
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ElectrifiedPlayer>().Electrified1 = true;
        }
    }

    public class ElectrifiedPlayer : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool Electrified1;

        public override void ResetEffects(NPC npc)
        {
            Electrified1 = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (Electrified1)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= 32;

                int dddust = Dust.NewDust(npc.Center, 0, 0, DustID.Electric);
                Main.dust[dddust].scale = 0.7f;
                Main.dust[dddust].noGravity = false;
            }

        }
    }
}

