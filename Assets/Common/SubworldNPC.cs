using Conquest.Subworlds;
using SubworldLibrary;
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
    public class SubworldNPC : GlobalNPC
    {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (SubworldSystem.IsActive<AntlionNest>())
            {
                pool.Clear();
                pool.Add(NPCID.FlyingAntlion, 0.10f);
                pool.Add(NPCID.WalkingAntlion, 0.10f);
                pool.Add(NPCID.GiantWalkingAntlion, 0.05f);
                pool.Add(NPCID.GiantFlyingAntlion, 0.05f);

            }
            if (SubworldSystem.IsActive<FlowerField>())
            {
                pool.Clear();
                pool.Add(NPCID.Dandelion, 0.10f);
                pool.Add(NPCID.BlueSlime, 0.10f);
            }
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            base.EditSpawnRate(player, ref spawnRate, ref maxSpawns);
        }
    }
}
