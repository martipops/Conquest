using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.UI;
using Terraria;

namespace Conquest.Assets.GUI
{
    public class SoundlessButton : UIElement
    {
        private Asset<Texture2D> _texture;

        private float _visibilityActive = 1f;

        private float _visibilityInactive = 0.4f;

        private Asset<Texture2D> _borderTexture;

        public SoundlessButton(Asset<Texture2D> texture)
        {
            _texture = texture;
            Width.Set(_texture.Width(), 0f);
            Height.Set(_texture.Height(), 0f);
        }

        public void SetHoverImage(Asset<Texture2D> texture)
        {
            _borderTexture = texture;
        }

        public void SetImage(Asset<Texture2D> texture)
        {
            _texture = texture;
            Width.Set(_texture.Width(), 0f);
            Height.Set(_texture.Height(), 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            spriteBatch.Draw(_texture.Value, dimensions.Position(), Color.White * (base.IsMouseHovering ? _visibilityActive : _visibilityInactive));
            if (_borderTexture != null && base.IsMouseHovering)
            {
                spriteBatch.Draw(_borderTexture.Value, dimensions.Position(), Color.White);
            }
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            base.MouseOut(evt);
        }

        public void SetVisibility(float whenActive, float whenInactive)
        {
            _visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
            _visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
        }
    }
}
