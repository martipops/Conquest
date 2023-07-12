using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;
using Terraria.Graphics.Shaders;
using Terraria;
using Terraria.Graphics;
namespace Conquest.Assets.Common
{
    internal class Effects
    {
        [StructLayout(LayoutKind.Sequential, Size = 1)]
       
            public struct PurpleTrail
            {
                private static VertexStrip _vertexStrip = new VertexStrip();

                public void Draw(Projectile proj)
                {
                    MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
                    miscShaderData.UseSaturation(-2.8f);
                    miscShaderData.UseOpacity(4f);
                    miscShaderData.Apply();
                    PurpleTrail._vertexStrip.PrepareStripWithProceduralPadding(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f);
                    PurpleTrail._vertexStrip.DrawTrail();
                    Main.pixelShader.CurrentTechnique.Passes[0].Apply();
                }

                private Color StripColors(float progressOnStrip)
                {
                    Color value = Main.hslToRgb(.225f, .39f, 0.7f);
                    Color result = Color.Purple;
                    result.A = 0;
                    return result;
                }

                private float StripWidth(float progressOnStrip)
                {
                    float num = 2f;
                    float lerpValue = Utils.GetLerpValue(-0f, 0.2f, progressOnStrip, clamped: true);
                    num *= 1f - (1f - lerpValue) * (1f - lerpValue);
                    return MathHelper.Lerp(0f, 32f, num);
                }
            }
            public struct WhiteTrail
            {
                private static VertexStrip _vertexStrip = new VertexStrip();

                public void Draw(Projectile proj)
                {
                    MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
                    miscShaderData.UseSaturation(-2.8f);
                    miscShaderData.UseOpacity(4f);
                    miscShaderData.Apply();
                    _vertexStrip.PrepareStripWithProceduralPadding(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f);
                    _vertexStrip.DrawTrail();
                    Main.pixelShader.CurrentTechnique.Passes[0].Apply();
                }

                private Color StripColors(float progressOnStrip)
                {
                    Color value = Main.hslToRgb(.225f, .39f, 0.7f);
                    Color result = Color.White;
                    result.A = 0;
                    return result;
                }

                private float StripWidth(float progressOnStrip)
                {
                    float num = 0.5f;
                    float lerpValue = Utils.GetLerpValue(-0f, 0.2f, progressOnStrip, clamped: true);
                    num *= 1f - (1f - lerpValue) * (1f - lerpValue);
                    return MathHelper.Lerp(0f, 32f, num);
                }
            }
            public struct RedTrail
            {
                private static VertexStrip _vertexStrip = new VertexStrip();

                public void Draw(Projectile proj)
                {
                    MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
                    miscShaderData.UseSaturation(-2.8f);
                    miscShaderData.UseOpacity(4f);
                    miscShaderData.Apply();
                    _vertexStrip.PrepareStripWithProceduralPadding(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f);
                    _vertexStrip.DrawTrail();
                    Main.pixelShader.CurrentTechnique.Passes[0].Apply();
                }

                private Color StripColors(float progressOnStrip)
                {
                    Color value = Main.hslToRgb(.225f, .39f, 0.7f);
                    Color result = Color.Red;
                    result.A = 0;
                    return result;
                }

                private float StripWidth(float progressOnStrip)
                {
                    float num = 1f;
                    float lerpValue = Utils.GetLerpValue(-0f, 0.2f, progressOnStrip, clamped: true);
                    num *= 1f - (1f - lerpValue) * (1f - lerpValue);
                    return MathHelper.Lerp(0f, 32f, num);
                }
            }
            public struct RoyalBlueTrail
            {
                private static VertexStrip _vertexStrip = new VertexStrip();

                public void Draw(Projectile proj)
                {
                    MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
                    miscShaderData.UseSaturation(-2.8f);
                    miscShaderData.UseOpacity(4f);
                    miscShaderData.Apply();
                    _vertexStrip.PrepareStripWithProceduralPadding(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f);
                    _vertexStrip.DrawTrail();
                    Main.pixelShader.CurrentTechnique.Passes[0].Apply();
                }

                private Color StripColors(float progressOnStrip)
                {
                    Color value = Main.hslToRgb(.225f, .39f, 0.7f);
                    Color result = Color.RoyalBlue;
                    result.A = 0;
                    return result;
                }

                private float StripWidth(float progressOnStrip)
                {
                    float num = 0.5f;
                    float lerpValue = Utils.GetLerpValue(-0f, 0.2f, progressOnStrip, clamped: true);
                    num *= 1f - (1f - lerpValue) * (1f - lerpValue);
                    return MathHelper.Lerp(0f, 32f, num);
                }
            }
            public struct GoldTrail
            {
                private static VertexStrip _vertexStrip = new VertexStrip();

                public void Draw(Projectile proj)
                {
                    MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
                    miscShaderData.UseSaturation(-2.8f);
                    miscShaderData.UseOpacity(4f);
                    miscShaderData.Apply();
                    _vertexStrip.PrepareStripWithProceduralPadding(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f);
                    _vertexStrip.DrawTrail();
                    Main.pixelShader.CurrentTechnique.Passes[0].Apply();
                }

                private Color StripColors(float progressOnStrip)
                {
                    Color value = Main.hslToRgb(.225f, .39f, 0.7f);
                    Color result = Color.Gold;
                    result.A = 0;
                    return result;
                }

                private float StripWidth(float progressOnStrip)
                {
                    float num = 0.2f;
                    float lerpValue = Utils.GetLerpValue(-0f, 0.2f, progressOnStrip, clamped: true);
                    num *= 1f - (1f - lerpValue) * (1f - lerpValue);
                    return MathHelper.Lerp(0f, 32f, num);
                }
            }
            public struct BlackTrail
            {
                private static VertexStrip _vertexStrip = new VertexStrip();

                public void Draw(Projectile proj)
                {
                    MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
                    miscShaderData.UseSaturation(-2.8f);
                    miscShaderData.UseOpacity(4f);
                    miscShaderData.Apply();
                    _vertexStrip.PrepareStripWithProceduralPadding(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f);
                    _vertexStrip.DrawTrail();
                    Main.pixelShader.CurrentTechnique.Passes[0].Apply();
                }

                private Color StripColors(float progressOnStrip)
                {
                    Color value = Main.hslToRgb(.225f, .39f, 0.7f);
                    Color result = Color.Black;
                    result.A = 0;
                    return result;
                }

                private float StripWidth(float progressOnStrip)
                {
                    float num = 0.2f;
                    float lerpValue = Utils.GetLerpValue(-0f, 0.2f, progressOnStrip, clamped: true);
                    num *= 1f - (1f - lerpValue) * (1f - lerpValue);
                    return MathHelper.Lerp(0f, 32f, num);
                }
            }
        }
    }

