Shader "Unlit/KeyS"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _DisolveTex ("DisolveTex (RGB)", 2D) = "white" {}
        _Threshold("Threshold", Range(0,1))= 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _DisolveTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _Threshold;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 m = tex2D(_DisolveTex, i.uv);
                half g = m.r * 0.2 + m.g * 0.7 + m.b * 0.1;
                if (g < _Threshold)
                {
                    discard;
                }

                fixed4 c = tex2D(_MainTex, i.uv) * _Color;
                return c;
            }
            ENDCG
        }
    }
}