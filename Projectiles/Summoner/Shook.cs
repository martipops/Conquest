using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Conquest.Buffs;

namespace Conquest.Projectiles.Summoner
{
    internal class Shook : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("舒克");
            Main.projFrames[Projectile.type] = 3;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.tileCollide = false;
            Projectile.width = 38;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.minion = true;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.minionSlots = 1;
            Projectile.penetrate = -1;
        }

        private int shootCounter = 0;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (!player.dead && player.HasBuff(ModContent.BuffType<ShookBuff>()))
            {
                Projectile.timeLeft = 2;
            }
            else
            {
                Projectile.timeLeft = 0;
            }

            if (++Projectile.frameCounter >= 5)
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;

                }
            }
            Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;

            if (!player.HasMinionAttackTargetNPC)
            {
                if (Projectile.Center.X < player.Center.X - 1)
                {
                    Projectile.velocity = (player.Center + new Vector2(-1, -50) - Projectile.Center) / Projectile.Center.Distance(player.Center) * 10;

                }
                else if (Projectile.Center.X > player.Center.X + 1)
                {
                    Projectile.velocity = (player.Center + new Vector2(1, -50) - Projectile.Center) / Projectile.Center.Distance(player.Center) * 10;

                }

            }

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];

                if (npc.CanBeChasedBy())
                {
                    if (Vector2.Distance(player.Center, npc.Center) <= 1000 && !npc.friendly)
                    {
                        player.MinionAttackTargetNPC = npc.whoAmI;
                    }
                }
            }

            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if (Vector2.Distance(player.Center, npc.Center) <= 1000)
                {
                    if (Projectile.Center.X < npc.Center.X - 100)
                    {
                        Projectile.velocity = (npc.Center + new Vector2(-100, -50) - Projectile.Center) / npc.Center.Distance(Projectile.Center) * 10;

                    }
                    else if (Projectile.Center.X >= npc.Center.X + 100)
                    {
                        Projectile.velocity = (npc.Center + new Vector2(100, -50) - Projectile.Center) / npc.Center.Distance(Projectile.Center) * 10;

                    }
                    shootCounter++;
                    if (shootCounter == 10 || shootCounter == 20 || shootCounter == 30)
                    {
                        Shoot(player);

                    }
                    if (shootCounter >= 60)
                    {
                        shootCounter = 0;
                    }
                    else
                    {
                        if (Projectile.Center.X < player.Center.X - 1)
                        {
                            Projectile.velocity = (player.Center + new Vector2(-1, -50) - Projectile.Center) / Projectile.Center.Distance(player.Center) * 10;

                        }
                        else if (Projectile.Center.X > player.Center.X + 1)
                        {
                            Projectile.velocity = (player.Center + new Vector2(1, -50) - Projectile.Center) / Projectile.Center.Distance(player.Center) * 10;

                        }
                    }
                }



            }
        }
        private void Shoot(Player player)
        {
            if (Main.myPlayer != Projectile.owner)
            {
                return;
            }
            NPC npc = Main.npc[player.MinionAttackTargetNPC];
            Item item = player.inventory[54];

            //PickAmmo pulls stats from the provided weapon and the automatically associated ammo item
            if (!player.PickAmmo(item, out int projToShoot, out float speed, out int damage, out float knockBack, out int usedAmmoItemId))
            {
                return;
            }

            var source = player.GetSource_ItemUse_WithPotentialAmmo(item, usedAmmoItemId);


            Projectile.NewProjectile(source, Projectile.Center, (npc.Center - Projectile.Center) / npc.Center.Distance(Projectile.Center) * 20, projToShoot, Projectile.damage, knockBack, Projectile.owner);
        }
        public override bool? CanDamage()
        {
            return false;
        }
    }
}
