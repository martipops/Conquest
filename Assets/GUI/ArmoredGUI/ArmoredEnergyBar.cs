using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

using Terraria.GameContent;
using System.Collections.Generic;
using Conquest.Items.Weapons.Ranged;

namespace Conquest.Assets.GUI.ArmoredGUI
{
    internal class ArmoredEnergyBar : UIState
    {
        private bool chargeIsReady;
        private float useTimeCoolDown;
        private float infoTextTimer;
        private bool startAnime;
        private float fillTimer;
        public static float blasterCharge;
        private static int frameY;
        private UIElement barArea;
        private UIElement infoArea;
        private UIText isEnoughInfo;
        private UIImage barFrame;

        public override void OnInitialize()
        {

            // area settings, where bar is drawing
            barArea = new UIElement();
            SetRectangle(barArea, 0f, 0f, 236f, 56f);
            barArea.HAlign = 0f;
            barArea.VAlign = 0.5f;
            barArea.OverflowHidden = true;

            // area settings, where info text is drawing
            infoArea = new UIElement();
            SetRectangle(infoArea, 0f, 0f, 500f, 500f);
            infoArea.HAlign = 0.5f;
            infoArea.VAlign = 0.5f;

            // info text settings, nothing inside string value, because it's setting much below (Update() hook)
            isEnoughInfo = new UIText("", 1f);
            SetRectangle(isEnoughInfo, 0f, 0f, 0f, 0f);
            isEnoughInfo.HAlign = 0.5f;
            isEnoughInfo.VAlign = 0.5f;

            barFrame = new UIImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/ArmoredGUI/ArmoredEnergyBar"));
            SetRectangle(barFrame, 0f, 0f, 236f, 896f);

            barArea.Append(barFrame);
            Append(barArea);
            Append(infoArea);
        }

        // this function is for better rectangle setting; simple and useful
        private void SetRectangle(UIElement uiElement, float left, float top, float width, float height)
        {
            uiElement.Left.Set(left, 0f);
            uiElement.Top.Set(top, 0f);
            uiElement.Width.Set(width, 0f);
            uiElement.Height.Set(height, 0f);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Main.LocalPlayer.HeldItem.ModItem is not Armored)
                return;
            base.Draw(spriteBatch);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {

            if (Main.LocalPlayer.HeldItem.ModItem is not Armored)
                return;

            fillTimer++;

            // charge count, needed below and in ModItem class
            blasterCharge = -frameY / 56;

            if (blasterCharge == 15 && !chargeIsReady)
            {
                SoundEngine.PlaySound(SoundID.Item92);
                chargeIsReady = true;
            }

            // number of charges can be shown if player is hovering energy bar in game
            if (barArea.IsMouseHovering)
            {
                Main.instance.MouseText(blasterCharge + "/15");
            }

            // here is frame counting
            // nothing special, just moving spitesheet from top to bottom and from-to cycle
            SetRectangle(barFrame, 0f, frameY - 1f, 236f, 896f);

            if (fillTimer >= Armored.armoredUseTime)
            {
                fillTimer = 0;
                if (frameY == -896 + 56)
                    frameY = -896 + 56;
                else
                    frameY -= 56;
            }

            useTimeCoolDown++;

            // because gun has to types of attack, code below works with charges of the gun
            // first part for left click:
            if (Main.mouseLeft && blasterCharge >= 1f && useTimeCoolDown >= Armored.armoredUseTime)
            {
                useTimeCoolDown = 0;
                if (frameY < 0)
                    frameY += 56;
            }

            // second part for the right one:
            if (Main.mouseRight && blasterCharge >= 15f && useTimeCoolDown >= Armored.armoredUseTime && Armored.heavyShot)
            {
                useTimeCoolDown = 0;
                if (frameY < 0)
                    frameY = 0;
                Armored.heavyShot = false;
                chargeIsReady = false;
            }
            else if (Main.mouseRight && blasterCharge < 15f && blasterCharge > 1f)
            {
                startAnime = true;
            }

            // function below is about info text animation when player has no energy "no energy, pork!"
            infoTextAnime();

            base.Update(gameTime);
        }
        void infoTextAnime()
        {
            if (startAnime)
            {

                infoTextTimer++;

                if (infoTextTimer > 60f)
                {
                    infoArea.RemoveAllChildren();
                    infoTextTimer = 0f;
                    startAnime = false;
                }
                else if (infoTextTimer <= 60f)
                {
                    // some operations with text
                    // if you need to add localisation, change string below
                    infoArea.Append(isEnoughInfo);
                    SetRectangle(isEnoughInfo, 0f, -50f - infoTextTimer, 0f, 0f);
                    isEnoughInfo.SetText("Not enough energy", 1f + infoTextTimer / 480f, false);
                    isEnoughInfo.TextColor = new Color(1 - infoTextTimer / 60f, 1f - infoTextTimer / 60f, 1f - infoTextTimer / 60f, 1f - infoTextTimer / 60f);
                }
            }
        }
    }

    // i've no idea what is this, i just copied it from my old project lmao
    class ArmoredUISystem : ModSystem
    {
        private UserInterface ArmoredUserInterface;
        internal ArmoredEnergyBar ArmoredUI;
        public void ShowMyUI()
        {
            ArmoredUserInterface?.SetState(ArmoredUI);
        }
        public void HideMyUI()
        {
            ArmoredUserInterface?.SetState(null);
        }
        public override void Load()
        {
            if (!Main.dedServ)
            {
                ArmoredUI = new();
                ArmoredUserInterface = new();
                ArmoredUserInterface.SetState(ArmoredUI);
            }
        }
        public override void UpdateUI(GameTime gameTime)
        {
            ArmoredUserInterface?.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1)
            {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "Conquest: Armored Energy Bar",
                    delegate
                    {
                        ArmoredUserInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}