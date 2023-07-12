using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Conquest.Assets.Common.Helpers;

namespace Conquest.Projectiles.Melee
{
    public class DragonHornsProj : Boomerang
    {
        int timer;

        public override void SetDefaults()
        {
            Projectile.ignoreWater = true;
            Projectile.width = 50;
            Projectile.height = 62;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = -1;

            ReturnSpeed = 60f;
            HomingOnOwnerStrength = 1.2f;
            TravelOutFrames = 30;
            DoTurn = true;
        }

    }
}
