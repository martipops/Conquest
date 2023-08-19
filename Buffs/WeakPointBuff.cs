
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Conquest.Assets.GUI;
using Conquest.Projectiles;

namespace Conquest.Buffs {
    public class WeakPointBuff : ModBuff {
        private float timer;
        public override void SetStaticDefaults() {
            // Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {

            WeakPoint.pointDamage = 0;

            timer++;

            if(timer >= 120) {
                timer = 0;
                if (Main.rand.NextBool(3))
                {
                    Projectile.NewProjectile(Entity.GetSource_None(), player.Center, Vector2.Zero, ModContent.ProjectileType<WeakPoint>(), 0, 0, player.whoAmI);
                }
            }

            if (!ETData.etPoints[2][3].unlocked) {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
        
    }
}