using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Conquest.Assets.GUI;

public class CQUIElement : UIElement
{
    public bool visible = true;



    public static void SetRectangle(UIElement element, Rectangle r)
    {
        element.Left.Set(r.Left, 0f);
        element.Top.Set(r.Top, 0f);
        element.Width.Set(r.Width, 0f);
        element.Height.Set(r.Height, 0f);
    }

    public void SetRectangle(UIElement element ,float left, float top, float width, float height)
    {
        element.Left.Set(left, 0f);
        element.Top.Set(top, 0f);
        element.Width.Set(width, 0f);
        element.Height.Set(height, 0f);
    }
    public void SetRectangle(float left, float top, float width, float height)
    {
        Left.Set(left, 0f);
        Top.Set(top, 0f);
        Width.Set(width, 0f);
        Height.Set(height, 0f);
    }

    public void SetRectangle(Rectangle r)
    {
        Left.Set(r.Left, 0f);
        Top.Set(r.Top, 0f);
        Width.Set(r.Width, 0f);
        Height.Set(r.Height, 0f);
    }

    public void SetRectangle(Rectangle r, Rectangle relative)
    {
        Left.Set(r.Left + relative.Left, 0f);
        Top.Set(r.Top + relative.Top, 0f);
        Width.Set(r.Width, 0f);
        Height.Set(r.Height, 0f);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if(visible)
            base.Draw(spriteBatch);
    }

    public override void Update(GameTime gameTime)
    {
        if(visible)
            base.Update(gameTime);
    }
    
}
