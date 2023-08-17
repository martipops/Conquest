using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Assets.Common
{
    public class ConsumableGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item entity)
        {
            if (entity.type == ItemID.LifeCrystal)
            {
                entity.autoReuse = true;
                entity.useTime = 5;
                entity.useAnimation = 5;
            }
            if (entity.type == ItemID.ManaCrystal)
            {
                entity.autoReuse = true;
                entity.useTime = 5;
                entity.useAnimation = 5;

            }
            if (entity.type == ItemID.LifeFruit)
            {
                entity.autoReuse = true;
                entity.useTime = 5;
                entity.useAnimation = 5;
            }

        }
    }
}
