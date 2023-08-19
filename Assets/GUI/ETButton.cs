using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.UI;

namespace Conquest.Assets.GUI{
internal class ETButton : SoundlessButton
    {
        private string etHvTxt;

        public ETButton(Asset<Texture2D> texture) : base(texture)
        {
            etHvTxt = "";
        }
        public ETButton(Asset<Texture2D> texture, string hoverText) : base(texture)
        {
            etHvTxt = hoverText;
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            EightTrigrams.tooltipBox.Text = "";
            base.MouseOut(evt);
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            if (!etHvTxt.Equals(""))
                EightTrigrams.tooltipBox.Text = etHvTxt;
            base.MouseOver(evt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(!visible)
                return;
            base.Draw(spriteBatch);
            if (!etHvTxt.Equals(""))
                EightTrigrams.tooltipBox.MoveToLocation(Main.mouseX+24, Main.mouseY+24);
        }
    }
}

