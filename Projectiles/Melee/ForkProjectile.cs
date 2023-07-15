using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Drawing;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace Conquest.Projectiles.Melee
{
    public class ForkProjectile : SpearProjectile
    {
        public ForkProjectile() : base(40, 44, 170) { }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];
            if (Main.rand.NextBool(10))
            {
                player.Heal(damageDone);
                player.HealEffect(damageDone, true);
                SoundEngine.PlaySound(SoundID.Item2);
            }
        }




    }
}
