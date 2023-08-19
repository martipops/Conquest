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
    public class SoundlessButton : CQUIElement
    {
        private Asset<Texture2D> _texture;

        private float _visibilityActive = 1f;

        private float _visibilityInactive = 0.4f;

        private Asset<Texture2D> _borderTexture;

        public bool hoverOverride = false;

        public SoundlessButton(Asset<Texture2D> texture) =>
            _texture = texture;

        public void SetHoverImage(Asset<Texture2D> texture) =>
            _borderTexture = texture;

        public void BindTextureSize() {
            Width.Set(_texture.Width(), 0f);
            Height.Set(_texture.Height(), 0f);
        }
        public void SetImage(Asset<Texture2D> texture)
        {
            _texture = texture;
            BindTextureSize();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            CalculatedStyle dimensions = GetDimensions();
            spriteBatch.Draw(_texture.Value, dimensions.Position(), Color.White * (base.IsMouseHovering ? _visibilityActive : _visibilityInactive));
            if (_borderTexture != null && (IsMouseHovering || hoverOverride))
            {
                spriteBatch.Draw(_borderTexture.Value, dimensions.Position(), Color.White);
            }
        }

        public void SetVisibility(float whenActive, float whenInactive)
        {
            _visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
            _visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
        }
    }
}
