using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ModLoader.UI.Elements;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Terraria.GameContent.UI.ResourceSets;
using ReLogic.Graphics;
using Microsoft.VisualBasic;
using Conquest.Assets.Common;

namespace Conquest.Assets.GUI
{
    internal class LostLifeBar : UIState
    {
        private UIElement llElmt;
        private UIImage llImg;

        private UIElement ll1Elmt;
        private UIImage ll1Img = new UIImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/LostHeart"));

        private UIElement ll2Elmt;
        private UIImage ll2Img = new UIImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/LostHeart"));

        public float x;
        public float y;
        public float z;
        public float xyz;
        public int xyzInt;
        public float xz;
        public int xzInt;

        public override void OnInitialize()
        {
            llElmt = new UIElement();
            SetRectangle(llElmt, left: Main.screenWidth - 300 + 4, top: 15f, width: 0f, height: 0f);
            llImg = new UIImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/LostHeart"));
            SetRectangle(llImg, left: 0, top: 0, width: 248f, height: 62f);
            Append(llElmt);
            llElmt.Append(llImg);

            ll1Elmt = new UIElement();
            SetRectangle(ll1Elmt, left: Main.screenWidth - 300 + 4, top: 15f, width: 0f, height: 0f);
            Append(ll1Elmt);

            ll2Elmt = new UIElement();
            SetRectangle(ll2Elmt, left: Main.screenWidth - 300 + 4, top: 15f, width: 0f, height: 0f);
            Append(ll2Elmt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().lostLife <= 0)
                return;



            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().lostLife <= 0)
                return;


            x = Main.LocalPlayer.statLife;
            y = Main.LocalPlayer.GetModPlayer<MyPlayer>().lostLife;
            z = Main.LocalPlayer.statLifeMax2;
            xyz = (float)((x + y) / z) * 40f;
            xyzInt = (int)xyz;
            xz = (float)(x / z) * 40f;
            xzInt = (int)xz;

            if (xyzInt > 40)
            {
                xyzInt = 40;
            }
            if (xyzInt < 1)
            {
                xyzInt = 1;
            }

            if (xzInt > 40)
            {
                xzInt = 40;
            }
            if (xzInt < 1)
            {
                xzInt = 1;
            }


            ll1Img.SetImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/LostHeart_Layer" + xyzInt.ToString()));

            ll2Img.SetImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/LostHeart_LayerLife" + xzInt.ToString()));


            ll1Elmt.Append(ll1Img);

            ll2Elmt.Append(ll2Img);

            base.Update(gameTime);
        }

        private void SetRectangle(UIElement uiElmt, float left, float top, float width, float height)
        {
            uiElmt.Left.Set(left, 0f);
            uiElmt.Top.Set(top, 0f);
            uiElmt.Width.Set(width, 0f);
            uiElmt.Height.Set(height, 0f);
        }
    }

    class LostLifeSystem : ModSystem
    {
        private UserInterface llbItfc;
        internal LostLifeBar lLB;

        private UserInterface llb1Itfc;
        internal LostLifeBar lLB1;

        private UserInterface llb2Itfc;
        internal LostLifeBar lLB2;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                lLB = new();
                llbItfc = new();
                llbItfc.SetState(lLB);

                lLB1 = new();
                llb1Itfc = new();
                llb1Itfc.SetState(lLB1);

                lLB2 = new();
                llb2Itfc = new();
                llb2Itfc.SetState(lLB2);

            }
        }
        public override void UpdateUI(GameTime gameTime)
        {
            llbItfc?.Update(gameTime);
            llb1Itfc?.Update(gameTime);
            llb2Itfc?.Update(gameTime);

        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int llbIdx = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars")) + 1;
            if (llbIdx != -1)
            {
                layers.Insert(llbIdx, new LegacyGameInterfaceLayer(
                    "Conquest: LostLifeBar",
                    delegate
                    {
                        llbItfc.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI
                    )
                );
            }

            int llb1Idx = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars")) + 2;
            if (llb1Idx != -1)
            {
                layers.Insert(llb1Idx, new LegacyGameInterfaceLayer(
                    "Conquest: LostLifeBarLayer1",
                    delegate
                    {
                        llb1Itfc.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI
                    )
                );
            }

            int llb2Idx = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars")) + 3;
            if (llb2Idx != -1)
            {
                layers.Insert(llb2Idx, new LegacyGameInterfaceLayer(
                    "Conquest: LostLifeBarLayer2",
                    delegate
                    {
                        llb2Itfc.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI
                    )
                );
            }
        }
    }
}
