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
using Conquest.Assets.GUI;

namespace Conquest.Assets.GUI
{
    internal class T3 : UIState
    {
        SoundStyle Selected = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/Selected");
        private UIElement t3Elmt;
        private UIImage t3Img;

        public static Asset<Texture2D> t3p0;
        public static Asset<Texture2D> t3p1;
        public static Asset<Texture2D> t3p2;
        public static Asset<Texture2D> t3p3;
        public static Asset<Texture2D> t3p4;
        public static Asset<Texture2D> t3p5;
        public static Asset<Texture2D> t3p6;

        public static bool p21On = false;
        public static bool p22On = false;
        public static bool p23On = false;
        public static bool p24On = false;
        public static bool p25On = false;
        public static bool p26On = false;
        public static bool p27On = false;

        public override void OnInitialize()
        {
            t3Elmt = new UIElement();

            SetRectangle(t3Elmt, left: 320f, top: 0f, width: 1024f, height: 768f);


            t3Img = new UIImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/T3"));


            SetRectangle(t3Img, left: 320f, top: 0f, width: 384f, height: 384f);

            Append(t3Elmt);
            t3Elmt.Append(t3Img);
        }

        private void T3P0InfoClose(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 3)
                return;

            EightTrigrams.infoImg.Remove();
        }

        private void T3P0Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 3)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 504f, top: 110f, width: 160f, height: 240f);

            if (p21On != true)
            {
                T1.txt1.SetText("Anger：\n+2% Ranged Damage\n+2% Crit Rate\n\n\n\nLeft Click to activate\n+1 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }
            else
            {
                T1.txt1.SetText("Anger：\n+2% Ranged Damage\n+2% Crit Rate\n\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }
            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T3P0On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 1 > EightTrigrams.tMaxLoad || p21On == true)
                return;

            p21On = true;
            SoundEngine.PlaySound(Selected);
            EightTrigrams.tLoad += 1;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void T3P1Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 3)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p22On != true)
            {
                if (p21On == true && NPC.downedBoss1 == true)
                {
                    T1.txt1.SetText("Charge Shot：\nThe longer the interval\nbetween ranged weapon\nattacks the higher\nthe damage\n\nLeft Click to activate\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (NPC.downedBoss1 != true)
                {
                    T1.txt1.SetText("Charge Shot：\nThe longer the interval\nbetween ranged weapon\nattacks the higher\nthe damage\nLocked！：\nSlay the Eye Of Cthulu\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p21On != true)
                {
                    T1.txt1.SetText("Charge Shot：\nThe longer the interval\nbetween ranged weapon\nattacks the higher\nthe damage\nLocked！：\nYou need to unlock the\nthe previous talent first\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Charge Shot：\nThe longer the interval\nbetween ranged weapon\nattacks the higher\nthe damage\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T3P1On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 2 > EightTrigrams.tMaxLoad || p22On == true || p21On == false || NPC.downedBoss1 == false)
                return;

            p22On = true;
            SoundEngine.PlaySound(Selected);
            EightTrigrams.tLoad += 2;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void T3P2Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 3)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p23On != true)
            {
                if (p21On == true && NPC.downedBoss1 == true)
                {
                    T1.txt1.SetText("Savings：\nAll ranged weapons\nhave a chance to\nnot consume ammo\nLeft click to activate\n\n\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (NPC.downedBoss1 != true)
                {
                    T1.txt1.SetText("Savings：\nAll ranged weapons\nhave a chance to\nnot consume ammo\n\nLocked！：\nSlay the Eye of Cthulu\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p21On != true)
                {
                    T1.txt1.SetText("Savings：\nAll ranged weapons\nhave a chance to\nnot consume ammo\nLocked！：\nYou need to unlock the\nthe previous talent first\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Savings：\nAll ranged weapons\nhave a chance to\nnot consume ammo\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T3P2On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 2 > EightTrigrams.tMaxLoad || p23On == true || p21On == false || NPC.downedBoss1 == false)
                return;

            p23On = true;
            SoundEngine.PlaySound(Selected);
            EightTrigrams.tLoad += 2;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }


        private void T3P3Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 3)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p24On != true)
            {
                if (p22On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Weak Points：\nDeal extra damage\nto enemy weakpoints\n\n\n\nLeft CLick to activate\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Weak Points：\nDeal extra damage\nto enemy weakpoints\n\n\nLocked！：\nHard Mode!\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p22On != true)
                {
                    T1.txt1.SetText("Weak Points：\nDeal extra damage\nto enemy weakpoints\nLocked！：\n\nYou need to unlock the\nthe previous talent first\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Weak Points：\nDeal extra damage\nto enemy weakpoints\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }


        private void T3P3On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 3 > EightTrigrams.tMaxLoad || p24On == true || p22On == false || Main.hardMode == false)
                return;

            p24On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 3;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }


        private void T3P4Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 3)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p25On != true)
            {
                if (p23On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Arms Master：\n+10% Crit Chance\nfor ranged weapons\n\n\nLeft Click to activate\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Arms Master：\n10% Crit Chance\nfor ranged weapons\n\n\nLocked！：\nHard Mode!\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p23On != true)
                {
                    T1.txt1.SetText("Arms Master：\n10% Crit Chance\nfor ranged weapons\nLocked！：\nYou need to unlock the\nthe previous talent first\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Arms Master：\n10% Crit Chance\nfor ranged weapons\n\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T3P4On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 3 > EightTrigrams.tMaxLoad || p25On == true || p23On == false || Main.hardMode == false)
                return;

            p25On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 3;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void T3P5Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 3)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p26On != true)
            {
                if (p24On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Patience：\nSlow Weapons gain\n25% more damage\nLeft Click to activate\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Patience：\nSlow Weapons gain\n25% more damage\n\n\nLocked！：\nHard Mode\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p24On != true)
                {
                    T1.txt1.SetText("Patience：\nSlow Weapons gain\n25% more damage\nLocked！\n\nYou need to unlock the\nthe previous talent first\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Patience：\nSlow Weapons gain\n25% more damage\n\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T3P5On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 4 > EightTrigrams.tMaxLoad || p26On == true || p24On == false || Main.hardMode == false)
                return;

            p26On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 4;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }


        private void T3P6Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 3)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p27On != true)
            {
                if (p25On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Hat Trick：\nChance to fire\na random ranged\nprojectile\nLeft Click to activate\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Hat Trick：\nChance to fire\na random ranged\nprojectile\nLocked！：\n\nHard Mode\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p25On != true)
                {
                    T1.txt1.SetText("Hat Trick：\nChance to fire\na random ranged\nprojectile\nLocked！：\nYou need to unlock the\nthe previous talent first\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Hat Trick：\nChance to fire\na random ranged\nprojectile\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }


        private void T3P6On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 4 > EightTrigrams.tMaxLoad || p27On == true || p25On == false || Main.hardMode == false)
                return;

            p27On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 4;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void SetRectangle(UIElement uiElmt, float left, float top, float width, float height)
        {
            uiElmt.Left.Set(left, 0f);
            uiElmt.Top.Set(top, 0f);
            uiElmt.Width.Set(width, 0f);
            uiElmt.Height.Set(height, 0f);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (EightTrigrams.tType != 3 || EightTrigrams.vsb == false)
                return;

            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (EightTrigrams.tType != 3 || EightTrigrams.vsb == false)
                return;


            if (p21On != true)
            {
                t3p0 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t3p0 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT3P0 = new ETButton(t3p0, "T3P0");

            SetRectangle(playT3P0, left: 416f, top: 214f, width: 14f, height: 14f);

            playT3P0.OnMouseOver += new MouseEvent(T3P0Info);
            playT3P0.OnMouseOut += new MouseEvent(T3P0InfoClose);

            playT3P0.OnLeftClick += new MouseEvent(T3P0On);

            t3Elmt.Append(playT3P0);


            if (p22On != true)
            {
                t3p1 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t3p1 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT3P1 = new ETButton(t3p1, "T3P1");

            SetRectangle(playT3P1, left: 456f, top: 162f, width: 14f, height: 14f);

            playT3P1.OnMouseOver += new MouseEvent(T3P1Info);
            playT3P1.OnMouseOut += new MouseEvent(T3P0InfoClose);

            playT3P1.OnLeftClick += new MouseEvent(T3P1On);

            t3Elmt.Append(playT3P1);


            if (p23On != true)
            {
                t3p2 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t3p2 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }


            ETButton playT3P2 = new ETButton(t3p2, "T3P2");

            SetRectangle(playT3P2, left: 462f, top: 236f, width: 14f, height: 14f);

            playT3P2.OnMouseOver += new MouseEvent(T3P2Info);
            playT3P2.OnMouseOut += new MouseEvent(T3P0InfoClose);

            playT3P2.OnLeftClick += new MouseEvent(T3P2On);

            t3Elmt.Append(playT3P2);


            if (p24On != true)
            {
                t3p3 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t3p3 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }


            ETButton playT3P3 = new ETButton(t3p3, "T3P3");

            SetRectangle(playT3P3, left: 492f, top: 184f, width: 14f, height: 14f);

            playT3P3.OnMouseOver += new MouseEvent(T3P3Info);
            playT3P3.OnMouseOut += new MouseEvent(T3P0InfoClose);

            playT3P3.OnLeftClick += new MouseEvent(T3P3On);

            t3Elmt.Append(playT3P3);


            if (p25On != true)
            {
                t3p4 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t3p4 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }


            ETButton playT3P4 = new ETButton(t3p4, "T3P4");

            SetRectangle(playT3P4, left: 508f, top: 242f, width: 14f, height: 14f);

            playT3P4.OnMouseOver += new MouseEvent(T3P4Info);
            playT3P4.OnMouseOut += new MouseEvent(T3P0InfoClose);

            playT3P4.OnLeftClick += new MouseEvent(T3P4On);

            t3Elmt.Append(playT3P4);


            if (p26On != true)
            {
                t3p5 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t3p5 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }


            ETButton playT3P5 = new ETButton(t3p5, "T3P5");

            SetRectangle(playT3P5, left: 518f, top: 134f, width: 14f, height: 14f);

            playT3P5.OnMouseOver += new MouseEvent(T3P5Info);
            playT3P5.OnMouseOut += new MouseEvent(T3P0InfoClose);

            playT3P5.OnLeftClick += new MouseEvent(T3P5On);

            t3Elmt.Append(playT3P5);


            if (p27On != true)
            {
                t3p6 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t3p6 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }


            ETButton playT3P6 = new ETButton(t3p6, "T3P6");

            SetRectangle(playT3P6, left: 558f, top: 216f, width: 14f, height: 14f);

            playT3P6.OnMouseOver += new MouseEvent(T3P6Info);
            playT3P6.OnMouseOut += new MouseEvent(T3P0InfoClose);

            playT3P6.OnLeftClick += new MouseEvent(T3P6On);

            t3Elmt.Append(playT3P6);
        }
    }

    class T3UISystem : ModSystem
    {
        private UserInterface t3Itfc;

        internal T3 eT3;
        public override void Load()
        {
            if (!Main.dedServ)
            {
                eT3 = new();
                t3Itfc = new();
                t3Itfc.SetState(eT3);
            }
        }
        public override void UpdateUI(GameTime gameTime)
        {
            t3Itfc?.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int etIdx = layers.FindIndex(layer => layer.Name.Equals("Conquest: EightTrigrams")) + 1;
            if (etIdx != -1)
            {
                layers.Insert(etIdx, new LegacyGameInterfaceLayer(
                    "Conquest: Trigram3",
                    delegate
                    {
                        t3Itfc.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI
                    )
                );
            }
        }
    }
}
