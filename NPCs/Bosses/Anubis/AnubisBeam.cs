
using Conquest.Assets.Common;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.NPCs.Bosses.Anubis
{
    public class AnubisBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 50;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.width = 22;               //The width of projectile hitbox
            Projectile.height = 22;              //The height of projectile hitbox
            Projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
            Projectile.hostile = true;         //Can the projectile deal damage to the player?
                                               //projectile.minion = true;           //Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 900;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255;           
            Projectile.light = 0.5f;          
            Projectile.ignoreWater = true;          
            Projectile.tileCollide = false;          
            Projectile.extraUpdates = 1;            
            AIType = ProjectileID.Bullet;           
        }
        public override bool PreDraw(ref Color lightColor)
        {
            default(Effects.PurpleTrail).Draw(Projectile);

            return true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            return false;
        }

    }
}
