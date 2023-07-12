using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Projectiles.Melee
{
    public class GloriousSpearProj : SpearProjectile
    {
        public GloriousSpearProj() : base(40, 44, 170) { }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];
            var settings = new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center,
                MovementVector = Projectile.velocity
            };
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.Excalibur, settings);
        }
       
      



    }
}
