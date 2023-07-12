sampler uImage0 : register(s0);
float uTime;
float4 Gradient(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 curCol = tex2D(uImage0, coords);
    float t = coords.x * 8 + coords.y * 8 + uTime;
    t %= 3;
    //important to multiply by the alpha so that the edges don't become awkwardly sharp
    float4 red = float4(0.98039215686, 0.98039215686, 0.82352941176, 1) * curCol.a;
    float4 blue = float4(0.85490196078, 0.64705882352, 0.12549019607, 1) * curCol.a;
    float4 yellow = float4(1, 0.796875, 0.5703125, 1) * curCol.a;
    if (t < 1)
        return yellow;
    if (t < 2)
        return red;
    return blue;
}

technique Technique1
{
    pass HslScrollPass
    {
        PixelShader = compile ps_2_0 Gradient();
    }
}
