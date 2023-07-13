
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Conquest.Assets.Common;
using Assortedarmaments.Projectiles;

namespace Conquest.Buffs {
    public class WeakPointDeBuff : ModBuff {
        public static bool letsExplode;
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(NPC target, ref int buffIndex) {
            if (letsExplode) {
                WeakPoint.pointDamage = MyPlayer.damageGivenForWeakPoints; // this is damage of the passive!
                letsExplode = false;
            }
        }
        
    }
}