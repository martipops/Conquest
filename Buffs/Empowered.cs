using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Buffs
{


    public class Empowered : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Empowered");
            //Description.SetDefault("You slowly lose health but gain damage");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;

        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += .15f;

        }
        
    }


    public class EmpoweredPlayer : ModPlayer
    {
        // Flag checking when life regen debuff should be activated
        public bool lifeRegenDebuff;
        private bool AmountHurt;

        public override void ResetEffects()
        {
            lifeRegenDebuff = true;

        }

        // Allows you to give the player a negative life regeneration based on its state (for example, the "On Fire!" debuff makes the player take damage-over-time)
        // This is typically done by setting player.lifeRegen to 0 if it is positive, setting player.lifeRegenTime to 0, and subtracting a number from player.lifeRegen
        // The player will take damage at a rate of half the number you subtract per second
        public override void UpdateBadLifeRegen()
        {
            if (lifeRegenDebuff)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects
                if (Player.lifeRegen > 0)
                    Player.lifeRegen = 0;
                // Player.lifeRegenTime uses to increase the speed at which the player reaches its maximum natural life regeneration
                // So we set it to 0, and while this debuff is active, it never reaches it
                Player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second
                Player.lifeRegen -= 3;
            }

        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            
        }

    }
}