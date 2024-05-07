Shader "Shaders/Mask"
{
    Properties
    {
        [IntRange] _StencilRef ("Stencil Ref", Range(0, 255)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque"  "Queue" = "Geometry-1"}
        LOD 100

        Blend Zero One
        Zwrite Off
        
        Stencil
        {
            Ref [_StencilRef]
            Comp Always
            Pass Replace
        }
        
        Pass
        {
       
        }
    }
}
