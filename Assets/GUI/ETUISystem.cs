using Terraria.ModLoader;
using Terraria.UI;

using Conquest.Assets.GUI;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

class ETUISystem : ModSystem
{
    private UserInterface etItfc;

    internal EightTrigrams eightTrigrams;
    public override void Load()
    {
        if (!Main.dedServ)
        {
            eightTrigrams = new();
            etItfc = new();
            etItfc.SetState(eightTrigrams);
        }
    }
    public override void UpdateUI(GameTime gameTime)
    {
        etItfc?.Update(gameTime);
    }
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        int etIdx = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars")) + 9;

        if (etIdx != -1)
        {
            layers.Insert(etIdx, new LegacyGameInterfaceLayer(
                "Conquest: EightTrigrams",
                delegate
                {
                    etItfc.Draw(Main.spriteBatch, new GameTime());
                    return true;
                },
                InterfaceScaleType.UI
                )
            );
        }
    }
}

