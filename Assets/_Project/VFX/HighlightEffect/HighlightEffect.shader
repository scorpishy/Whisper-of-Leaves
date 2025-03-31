Shader "Custom/HighlightEffect_URP_Transparent"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _Color("Base Color", Color) = (1,1,1,1)
        _HighlightColor("Highlight Color", Color) = (1,1,1,1)
        _HighlightWidth("Highlight Width", Range(0, 0.5)) = 0.1
        _HighlightSpeed("Highlight Speed", Float) = 1.0
        _HighlightFrequency("Highlight Frequency", Float) = 1.0
        _HighlightIntensity("Highlight Intensity", Range(0, 1)) = 0.5
        [Toggle]_HighlightEnabled("Highlight Enabled", Float) = 0 
    }

    SubShader
    {
        Tags 
        { 
            "RenderType" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Transparent"
        }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                half4 color : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                half4 color : COLOR;
            };

            sampler2D _MainTex;
            CBUFFER_START(UnityPerMaterial)
                half4 _Color;
                half4 _HighlightColor;
                float _HighlightWidth;
                float _HighlightSpeed;
                float _HighlightFrequency;
                float _HighlightIntensity;
                float _HighlightEnabled;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = IN.uv;
                OUT.color = IN.color * _Color;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 texColor = tex2D(_MainTex, IN.uv) * IN.color;

                if (_HighlightEnabled == 0)
                {
                    return texColor;
                }

                float highlightPos = frac(_Time.y * _HighlightFrequency) * _HighlightSpeed;
                
                float highlight = smoothstep(
                    highlightPos - _HighlightWidth, 
                    highlightPos,
                    IN.uv.y
                ) * (1.0 - smoothstep(
                    highlightPos,
                    highlightPos + _HighlightWidth,
                    IN.uv.y
                ));

                half4 blendedColor = lerp(texColor, _HighlightColor, _HighlightIntensity);

                half4 finalColor = lerp(texColor, blendedColor, highlight);
                finalColor.a = texColor.a;

                return finalColor;
            }
            ENDHLSL
        }
    }
}
