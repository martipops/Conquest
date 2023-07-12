using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Conquest.Assets.GUI.HollowKnight
{
    public class HollowGauge : ModPlayer
    {
        public int HollowGaugeResourceCurrent; // Current value of our example resource
        public const int HollowGaugeResourceMax = 100; // Default maximum value of example resource
        public int HollowGaugeMax; // Buffer variable that is used to reset maximum resource to default value in ResetDefaults().
        public int HollowGaugeResourceMax2; // Maximum amount of our example resource. We will change that variable to increase maximum amount of our resource
        public float HollowGaugeResourceRegenRate; // By changing that variable we can increase/decrease regeneration rate of our resource
        internal int HollowGaugeResourceTimer = 0; // A variable that is required for our timer
        public static readonly Color HealExampleResource = new(0, 0, 0); // We can use this for CombatText, if you create an item that replenishes exampleResourceCurrent\
        public override void Initialize()
        {
            HollowGaugeMax = HollowGaugeResourceMax;
        }

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        // We need this to ensure that regeneration rate and maximum amount are reset to default values after increasing when conditions are no longer satisfied (e.g. we unequip an accessory that increaces our recource)
        private void ResetVariables()
        {
            HollowGaugeResourceRegenRate = 1f;
            HollowGaugeResourceMax2 = HollowGaugeMax;
        }

        public override void PostUpdateMiscEffects()
        {
            UpdateResource();
        }

        // Lets do all our logic for the custom resource here, such as limiting it, increasing it and so on.
        private void UpdateResource()
        {

            HollowGaugeResourceCurrent = Utils.Clamp(HollowGaugeResourceCurrent, 0, HollowGaugeResourceMax2);
        }
    }
}


