using SubworldLibrary;
using System.Collections.Generic;
using Terraria;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;
using Point16 = Terraria.DataStructures.Point16;
using StructureHelper;

namespace Conquest.Subworlds
{
    public class DesertTemple : Subworld
    {
        public override int Width => 800;
        public override int Height => 500;
        public override bool NormalUpdates => false;
        public override bool ShouldSave => true;
        public override bool NoPlayerSaving => false;

        public override List<GenPass> Tasks => new List<GenPass>()
        { 
               new PassLegacy ("Generating thing", (progress, _) =>
                {
                    progress.Message = "Generating Desert Temple";
                    Main.spawnTileX = 280;
                    Main.spawnTileY = 173;

                     Main.worldSurface = 0;
                     Main.rockLayer = 1;
                     int x = 50;
                     int y = 120;
                     Point16 point = new Point16(x, y);
                    Generator.GenerateStructure("Structures/DesertTemple", point, Conquest.Instance, false);
                },90f),
              
        };
        public override void OnEnter()
        {
            SubworldSystem.hideUnderworld = true;

        }
     
        public override void OnExit()
        {
            base.OnExit();
        }

    }

}    
