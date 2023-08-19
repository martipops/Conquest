using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using System;
using static Conquest.Assets.GUI.ETData;
using ReLogic.Content;

namespace Conquest.Assets.GUI
{

    public class EightTrigrams : UIState
    {
        private static readonly Asset<Texture2D> etImgAsset = ModContent.Request<Texture2D>("Conquest/Assets/GUI/EightTrigrams");
        private static readonly UIImage etUIImg = new UIImage(etImgAsset);
        private CQUIElement etElmt = new();
        public static CQTextBox infoPanel = new();
        public static CQTextBox tooltipBox = new();

        public static bool vsb = false;


        public override void OnInitialize()
        {
            etElmt.SetRectangle(etElmtDimensions);

            CQUIElement.SetRectangle(etUIImg, etElmtDimensions);
            
            infoPanel.SnapToRightOfText = true;

            Append(etElmt);
            etElmt.Append(etUIImg);

            for (int index = 0; index < buttonInfos.Length; index++)
            {
                var buttonInfo = buttonInfos[index];
                int i = index - 1;
                var Texture = ModContent.Request<Texture2D>($"Conquest/Assets/GUI/{buttonInfo.TextureName}");
                ETButton playButton = new ETButton(Texture, buttonInfo.HoverText);
                playButton.SetRectangle(buttonInfo.RelativeRect, etElmtDimensions);
                playButton.OnLeftClick += new MouseEvent((evt, listeningElement) => EtButton_OnClick(i));
                etElmt.Append(playButton);
            }

            for (int i = 0; i < etPoints.Length; i++)
            {
                CreateMap(i);
            }
            etElmt.Append(infoPanel);
            infoPanel.MoveToLocation(etElmtDimensions.X*3/2, 200);
            etElmt.Append(tooltipBox);
        }

        public void CreateMap(int num) {
            ETTrigram newMap = new ETTrigram(num, ModContent.Request<Texture2D>($"Conquest/Assets/GUI/T{num+1}"));
            etElmt.Append(newMap);
            foreach (ETPoint etPoint in newMap.UIPoints)
            {
                etPoint.OnLeftClick += new MouseEvent((evt, listeningElement) => EtPoint_OnClick(etPoint));
                etElmt.Append(etPoint);
            }
        }

        internal void EtPoint_OnClick(ETPoint etPoint) {
            if (!vsb || pageIndex != etPoint.triNum)
                return;
            Main.NewText($"Point {etPoint.pointNum} Clicked");
            etPoint.TryUpgrade();
        }

        public void EtButton_OnClick(int index) 
        {
            if(!vsb)
                return;
            Main.NewText($"Button {index} Clicked");
            if (index == -1) {
                vsb = false;
            }
            ChangeMap(index);
        }

        private void ChangeMap(int num)
        {
            pageIndex = num;
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

            base.Update(gameTime);
        }
    }

}


