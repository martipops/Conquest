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


namespace Conquest.Assets.GUI
{

    public class EightTrigrams : UIState
    {

        private UIElement etElmt;
        private UIImage etImg;

        public static bool vsb = false;

        public static int tType = 0;

        public static int tLoad = 0;
        public static int tMaxLoad = 4;

        public static string loadInfoNow = tLoad.ToString();
        public static string loadInfoMax = tMaxLoad.ToString();

        public static UIImage infoImg = new UIImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointInfo"));
        private void SetRectangle(UIElement uiElmt, float left, float top, float width, float height)
        {
            uiElmt.Left.Set(left, 0f);
            uiElmt.Top.Set(top, 0f);
            uiElmt.Width.Set(width, 0f);
            uiElmt.Height.Set(height, 0f);
        }

        public override void OnInitialize()
        {
            etElmt = new UIElement();

            SetRectangle(etElmt, left: 320f, top: 0f, width: 1024f, height: 768f);


            etImg = new UIImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/EightTrigrams"));

            SetRectangle(etImg, left: 320f, top: 0f, width: 384f, height: 384f);

            Append(etElmt);
            etElmt.Append(etImg);


            Asset<Texture2D> etButton0 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Q");

            ETButton playButton0 = new ETButton(etButton0, "Button0");

            SetRectangle(playButton0, left: 320f, top: 0f, width: 32f, height: 32f);

            playButton0.OnLeftClick += new MouseEvent(EtButton0_OnClick);

            etElmt.Append(playButton0);


            Asset<Texture2D> etButton1 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/ETB1");

            ETButton playButton1 = new ETButton(etButton1, "Button1");

            SetRectangle(playButton1, left: 476f, top: 0f, width: 72f, height: 72f);

            playButton1.OnLeftClick += new MouseEvent(EtButton1_OnClick);

            etElmt.Append(playButton1);


            Asset<Texture2D> etButton2 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/ETB2");

            ETButton playButton2 = new ETButton(etButton2, "Button2");

            SetRectangle(playButton2, left: 368f, top: 48f, width: 72f, height: 72f);

            playButton2.OnLeftClick += new MouseEvent(EtButton2_OnClick);

            etElmt.Append(playButton2);


            Asset<Texture2D> etButton3 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/ETB3");

            ETButton playButton3 = new ETButton(etButton3, "Button3");

            SetRectangle(playButton3, left: 320f, top: 156f, width: 72f, height: 72f);

            playButton3.OnLeftClick += new MouseEvent(EtButton3_OnClick);

            etElmt.Append(playButton3);


            Asset<Texture2D> etButton4 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/ETB4");

            ETButton playButton4 = new ETButton(etButton4, "Button4");

            SetRectangle(playButton4, left: 368f, top: 262f, width: 72f, height: 72f);

            playButton4.OnLeftClick += new MouseEvent(EtButton4_OnClick);

            etElmt.Append(playButton4);


            Asset<Texture2D> etButton5 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/ETB5");

            ETButton playButton5 = new ETButton(etButton5, "Button5");

            SetRectangle(playButton5, left: 584f, top: 48f, width: 72f, height: 72f);

            playButton5.OnLeftClick += new MouseEvent(EtButton5_OnClick);

            etElmt.Append(playButton5);


            Asset<Texture2D> etButton6 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/ETB6");

            ETButton playButton6 = new ETButton(etButton6, "Button6");

            SetRectangle(playButton6, left: 632f, top: 156f, width: 72f, height: 72f);

            playButton6.OnLeftClick += new MouseEvent(EtButton6_OnClick);

            etElmt.Append(playButton6);


            Asset<Texture2D> etButton7 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/ETB7");

            ETButton playButton7 = new ETButton(etButton7, "Button7");

            SetRectangle(playButton7, left: 584f, top: 262f, width: 72f, height: 72f);

            playButton7.OnLeftClick += new MouseEvent(EtButton7_OnClick);

            etElmt.Append(playButton7);


            Asset<Texture2D> etButton8 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/ETB8");

            ETButton playButton8 = new ETButton(etButton8, "Button8");

            SetRectangle(playButton8, left: 476f, top: 312f, width: 72f, height: 72f);

            playButton8.OnLeftClick += new MouseEvent(EtButton8_OnClick);

            etElmt.Append(playButton8);
        }
        private void EtButton0_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            infoImg.Remove();
            tType = 0;
            vsb = false;
        }
        private void EtButton1_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            if (vsb == false)
                return;
            tType = 1;
        }
        private void EtButton2_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            tType = 2;
        }
        private void EtButton3_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            tType = 3;
        }
        private void EtButton4_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            tType = 4;
        }
        private void EtButton5_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            tType = 5;
        }
        private void EtButton6_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            tType = 6;
        }
        private void EtButton7_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            tType = 7;
        }
        private void EtButton8_OnClick(UIMouseEvent evt, UIElement listeningElement)
        {
            tType = 8;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (vsb != true)
                return;
            Main.LocalPlayer.mouseInterface = true;


            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (vsb != true)
                return;


            loadInfoNow = tLoad.ToString();
            loadInfoMax = tMaxLoad.ToString();

            base.Update(gameTime);
        }
    }

    internal class ETButton : SoundlessButton
    {
        internal string etHv;
        public ETButton(Asset<Texture2D> texture, string hoverText) : base(texture)
        {
            etHv = hoverText;
        }
    }
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

}


