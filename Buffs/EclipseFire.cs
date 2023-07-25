using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Conquest.Items.Weapons.Magic;

namespace Conquest.Buffs {
    public class EclipseFire : ModBuff {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }
        public override void Update(NPC target, ref int buffIndex) {
            DarkDawn.sunEnergy++;
            target.lifeRegen -= 2000;
        }
       
    }
}